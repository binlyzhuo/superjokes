using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joke.Model.Domain;
using Joke.Model.ViewModel;
using NPoco;

namespace Joke.Data
{
    public class JokeDataProvider : BaseData<T_Joke>
    {
        public JokeDataProvider()
        {

        }

        public int JokesCount()
        {
            Sql where = Sql.Builder.Where("state=1");
            return Count(where);
        }

        public int JokesCount(int userid, int? state)
        {
            Sql where = Sql.Builder.Where("PostID=@0",userid);
            if(state!=null)
            {
                where.Append(" and State=@0",state);
            }
            return Count(where);
        }

        public Tuple<int, List<JokePrimaryInfo>> LatestJokesGet()
        {
            string sql = @"select count(1) from T_Joke with(NOLOCK) where State=1;
                           select top 16 j.ID as JokeId,Title,j.Category as CategoryId,c.Name as CategoryName,c.PinYin,j.Content,j.AddDate from T_Joke j with(NOLOCK)
                            inner join T_Category c on c.ID = j.Category
                            where j.State=1 and type=0 order by j.ID desc";

            var items = this.jokeDatabase.FetchMultiple<int, JokePrimaryInfo>(sql);
            Tuple<int, List<JokePrimaryInfo>> data = new Tuple<int, List<JokePrimaryInfo>>(items.Item1[0], items.Item2);
            return data;
        }

        public List<T_Joke> LikeMostJokesGet(int count=20,int? type=1)
        {
            string where = "";
            if(type!=null)
            {
                where = string.Format(" and type={0}",type);
            }
            string sql = string.Format("SELECT top {0} * from T_Joke with(NOLOCK) where State=1 {1} order by LikeCount desc",count,where);
            var items = this.jokeDatabase.Fetch<T_Joke>(sql);
            return items;
        }

        public Tuple<JokePostInfo, T_Joke, T_Joke> GetLastNextJokes(int jokeid,int? type=null)
        {
            string detailSQL = string.Format(@"select j.ID as JokeId,j.Title,j.Content,j.LikeCount,j.HateCount,u.NikeName,u.id as UserID,u.UserName,j.Type as JokeType,j.State as JokeState,j.AddDate as PostDate,c.Name as Category,c.PinYin as CategoryPinyin from T_Joke j 
                            inner join T_User u on u.ID = j.PostID
                            inner join T_Category c on c.ID = j.Category
                            where j.State=1 and j.ID = {0}", jokeid);
            string where = "";
            if(type!=null)
            {
                where = string.Format(" and Type={0}",type);
            }
            string querySQL = string.Format(@"{1}
                        select top 1 * from T_Joke where ID>{0} {2} and state=1 order by ID asc
                        select top 1 * from T_Joke where ID<{0} {2} and state=1 order by ID desc", jokeid, detailSQL,where);

            var item = this.jokeDatabase.FetchMultiple<JokePostInfo, T_Joke, T_Joke>(querySQL);
            var data = new Tuple<JokePostInfo, T_Joke, T_Joke>(item.Item1 != null && item.Item1.Count>0? item.Item1[0] : null, item.Item2 != null && item.Item2.Count > 0 ? item.Item2[0] : null, item.Item3 != null && item.Item3.Count > 0 ? item.Item3[0] : null);
            return data;
        }

        public List<T_Joke> MostReadJokesGet()
        {
            string sql = "SELECT top 10 * from T_Joke order by readcount desc";
            var items = this.jokeDatabase.Fetch<T_Joke>(sql);
            return items;
        }

        public PageSearchResult<JokePostInfo> JokePostInfo(JokeSearchModel search)
        {
            StringBuilder where = new StringBuilder();
            if(search.SearchType == JokeSearchType.Latest)
            {
                where.AppendFormat(" and j.Type={0}",0);
            }
            else if(search.SearchType == JokeSearchType.ImageJokes)
            {
                where.AppendFormat(" and j.Type={0}", 1);
            }
            if(search.CategoryID>0)
            {
                where.AppendFormat(" and j.Category={0}",search.CategoryID);
            }

            string sql = string.Format(@"declare @@pagenum int=@0;
                        declare @@pagesize int = @1;
                        with tmp as
                        (
                        SELECT ROW_NUMBER() over(order by j.ID DESC) as Num, j.ID as JokeId,j.Title,j.Content,j.LikeCount,j.HateCount,u.NikeName,u.ID as UserId,j.Type as JokeType,j.AddDate as PostDate,u.UserName,c.Name as Category,c.PinYin as CategoryPinyin from T_Joke j with(NOLOCK)
                        inner join T_User u on u.ID = j.PostID
                        inner join T_Category c on c.ID = j.Category
                        where j.State=1 {0}
                        )
                        SELECT JokeId,Title,Content,LikeCount,HateCount,NikeName,UserId,JokeType,PostDate,UserName,Category,CategoryPinyin from tmp where Num>(@@pagenum-1)*@@pagesize and Num<=@@pagenum*@@pagesize;
                        select COUNT(1) from T_Joke j where State=1 {0}", where.ToString());

            var items = this.jokeDatabase.FetchMultiple<JokePostInfo, int>(sql, search.Page, search.PageSize);
            PageSearchResult<JokePostInfo> pageResult = new PageSearchResult<JokePostInfo>()
            {
                Items = items.Item1,
                Page = search.Page,
                PageSize = search.PageSize,
                TotalCount = items.Item2[0]
            };
            return pageResult;
        }

        public List<T_Joke> GetLast20HoursJokes(int count)
        {
            string sql = string.Format("SELECT top {0} * from T_Joke with(NOLOCK) where datediff(hour,AddDate,GETDATE())<=24",count);
            var items = this.jokeDatabase.Fetch<T_Joke>(sql);
            if(items==null||items.Count==0)
            {
                items = GetJokes(10,0);
            }
            return items;
        }

        public List<T_Joke> GetJokes(int topCount=10,int type=0)
        {
            string sql = string.Format("select top {0} * from T_Joke where Type={1} and state=1 order by ID desc",topCount,type);
            return this.jokeDatabase.Fetch<T_Joke>(sql);
        }

        public PageSearchResult<JokePostInfo> UserJokesSearch(UserJokesSearchModel search)
        {
            StringBuilder where = new StringBuilder();
            if(search.UserId!=null)
            {
                where.AppendFormat(" and j.postid={0}", search.UserId);
            }
            
            if (search.JokeState!=null)
            {
                where.AppendFormat(" and j.State={0}", search.JokeState);
            }
            if(search.JokeType!=null)
            {
                where.AppendFormat(" and j.Type={0}", search.JokeType);
            }
            string sql = string.Format(@"declare @@pagenum int=@0;
                        declare @@pagesize int = @1;
                        with tmp as
                        (
                        SELECT ROW_NUMBER() over(order by j.ID DESC) as Num, j.ID as JokeId,j.Title,j.Content,j.LikeCount,j.HateCount,u.NikeName,u.ID as UserId,j.Type as JokeType,j.AddDate as PostDate,u.UserName,j.State as JokeState,c.Name as Category,c.Pinyin as CategoryPinyin from T_Joke j with(NOLOCK)
                        inner join T_User u on u.ID = j.PostID
                        inner join T_Category c on c.ID = j.Category
                        where 1=1 {0}
                        )
                        SELECT JokeId,Title,Content,LikeCount,HateCount,NikeName,UserId,JokeType,PostDate,UserName,JokeState,CategoryPinyin,Category from tmp where Num>(@@pagenum-1)*@@pagesize and Num<=@@pagenum*@@pagesize;
                        select COUNT(1) from T_Joke j where 1=1 {0}", where.ToString());

            var items = this.jokeDatabase.FetchMultiple<JokePostInfo, int>(sql, search.Page, search.PageSize);
            PageSearchResult<JokePostInfo> pageResult = new PageSearchResult<JokePostInfo>()
            {
                Items = items.Item1,
                Page = search.Page,
                PageSize = search.PageSize,
                TotalCount = items.Item2[0]
            };
            return pageResult;
        }

        public JokePostInfo GetPostJokeInfo(int jokeid)
        {
            string sql = string.Format(@"select j.ID as JokeId,j.Title,j.Content,j.LikeCount,j.HateCount,u.NikeName,u.id as UserID,j.Type as JokeType,j.State as JokeState,j.AddDate as PostDate,c.Name as Category,c.PinYin as CategoryPinyin,u.UserName from T_Joke j 
                            inner join T_User u on u.ID = j.PostID
                            inner join T_Category c on c.ID = j.Category
                            where j.State=1 and j.ID = {0}",jokeid);
            return this.jokeDatabase.SingleOrDefault<JokePostInfo>(sql);
        }
    }
}
