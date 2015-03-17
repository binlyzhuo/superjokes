using Joke.Model.Domain;
using Joke.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Joke.Data
{
    public class CommentDataProvider:BaseData<T_Comment>
    {
        public CommentDataProvider()
        {

        }

        public PageSearchResult<CommentViewInfo> CommentSearchResult(CommentSearchModel search)
        {
//            string sql = string.Format(@"select cm.JokeId,cm.ID as CommentId,cm.Content as Comment,cm.UserID,us.UserName,cm.Floor from T_Comment cm
//                            inner join T_Joke jk on cm.JokeId = jk.ID
//                            inner join T_User us on us.id=cm.UserID where cm.JokeId={0}",search.JokeID);

            string sql = string.Format(@"declare @@pagenum int ={1};
                        declare @@pagesize int = {2};
                        with tmp as(
                        select ROW_NUMBER() OVER(ORDER by cm.ID desc) as Num, cm.JokeId,cm.ID as CommentId,cm.Content as Comment,cm.UserID,us.UserName,cm.Floor  from T_Comment cm
                        inner join T_Joke jk on cm.JokeId = jk.ID
                        inner join T_User us on us.id=cm.UserID
                        where cm.JokeId={0})
                        select JokeId,CommentId,Comment,UserID,UserName,UserName,Floor from tmp where Num>(@@pagenum-1)*@@pagesize and Num<=@@pagenum*@@pagesize;
                        select count(1) from T_Comment with(nolock) where JokeId={0}", search.JokeID,search.Page,search.PageSize);

            
            var items = this.jokeDatabase.FetchMultiple<CommentViewInfo, int>(sql, search.Page, search.PageSize);
            PageSearchResult<CommentViewInfo> pageResult = new PageSearchResult<CommentViewInfo>()
            {
                Items = items.Item1,
                Page = search.Page,
                PageSize = search.PageSize,
                TotalCount = items.Item2[0]
            };
            return pageResult;
            
        }
    }
}
