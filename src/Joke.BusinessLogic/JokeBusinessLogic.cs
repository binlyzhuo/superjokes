using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joke.Data;
using Joke.Model.Domain;
using Joke.Model.Dto;
using System.Web;
using System.Xml;
using System.IO;
using Joke.Common;
using AutoMapper;
using Joke.Model.ViewModel;

namespace Joke.BusinessLogic
{
    public class JokeBusinessLogic:BaseLogic
    {
        private readonly CategoryDataProvider categoryData;
        private readonly JokeDataProvider jokeData;
        private readonly CommentDataProvider commentData;
        public JokeBusinessLogic()
        {
            categoryData = new CategoryDataProvider();
            jokeData = new JokeDataProvider();
            commentData = new CommentDataProvider();
        }

        public void InitCategory()
        {
            string xmlPath = System.Web.HttpContext.Current.Server.MapPath("/App_Data/CategoryData.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            List<T_Category> items = new List<T_Category>();
            T_Category category;
            var xmlNodes = xmlDoc.SelectNodes("categories/category");
            foreach(XmlNode n in xmlNodes)
            {
                category = new T_Category();
                category.ID = n.SelectSingleNode("id").InnerText.ToInt32();
                category.Name = n.SelectSingleNode("name").InnerText;
                category.PinYin = n.SelectSingleNode("pinyin").InnerText;
                category.AddDate = DateTime.Now;
                category.State = 1;
                items.Add(category);
            }

            categoryData.BulkInsert(items);
        }


        public List<CategoryDto> GetCategoryList()
        {
            var categoryDtos = WebCache.GetCacheObject<List<CategoryDto>>(CategoryCacheKey);
            if(categoryDtos==null||categoryDtos.Count==0)
            {
                var categoryDomains = categoryData.CategoryGet();
                categoryDtos = AutoMapper.Mapper.Map<List<T_Category>, List<CategoryDto>>(categoryDomains);
                WebCache.CacheInsert(categoryDtos, CategoryCacheKey);
            }
            return categoryDtos;
        }

        

        public CategoryDto GetCategoryInfo(string pinyin)
        {
            return GetCategoryList().SingleOrDefault(u => u.PinYin == pinyin);
        }

        public CategoryDto GetCategoryInfo(int id)
        {
            return GetCategoryList().SingleOrDefault(u => u.ID == id);
        }

        public int AddJoke(T_Joke joke)
        {
            int jokeid = jokeData.Add(joke);
            return jokeid;
        }

        public List<CategorySummaryInfo> CategorySummaryInfo()
        {
            var items = categoryData.CategorySummaryInfo();
            return items;
        }

        public int JokesCount()
        {
            return jokeData.JokesCount();
        }

        public int JokesStateCount(int? state)
        {
            return jokeData.JokeCount(state);
        }

        public Tuple<int, List<JokePrimaryInfo>> LatestJokesGet()
        {
            return jokeData.LatestJokesGet();
        }

        public List<T_Joke> LikeMostJokesGet(int count = 20, int? type = 1)
        {
            return jokeData.LikeMostJokesGet(count,type);
        }

        public T_Joke JokeDetailGet(int jokeid)
        {
            return jokeData.SingleOrDefault(jokeid);
        }

        public Tuple<JokePostInfo, T_Joke, T_Joke> GetLastNextJokes(int jokeid,int? type=null)
        {
            return jokeData.GetLastNextJokes(jokeid,type);
        }

        public List<T_Joke> MostReadJokesGet(int topcount)
        {
            return jokeData.MostReadJokesGet(topcount);
        }

        public PageSearchResult<JokePostInfo> JokePostInfo(JokeSearchModel search)
        {
            return jokeData.JokePostInfo(search);
        }

        public List<T_Joke> GetLast20HoursJokes(int count=20)
        {
            return jokeData.GetLast20HoursJokes(count);
        }

        public bool UpdateJoke(T_Joke joke)
        {
            return jokeData.Update(joke);
        }

        public List<T_Joke> GetJokes(int topCount=10,int type=0)
        {
            var items = jokeData.GetJokes(topCount, type);
            return items;
        }

        public PageSearchResult<JokePostInfo> UserJokesSearch(UserJokesSearchModel search)
        {
            var pageViewResult = jokeData.UserJokesSearch(search);
            return pageViewResult;
        }

        public bool DeleteJoke(int jokeId)
        {
            return jokeData.Delete(jokeId);
        }

        public T_Category CategoryGet(string pinyin)
        {
            return categoryData.CategoryGet(pinyin);
        }

        public int JokesCount(int userid, int? state=null)
        {
            return jokeData.JokesCount(userid,state);
        }

        public JokePostInfo GetPostJokeInfo(int jokeid)
        {
            return jokeData.GetPostJokeInfo(jokeid);
        }

        public void AddJokes(List<T_Joke> jokes)
        {
            jokeData.BulkInsert(jokes);
        }

        public bool AddComment(T_Comment comment)
        {
            return commentData.Add(comment)>0;
        }

        public PageSearchResult<CommentViewInfo> CommentSearchResult(CommentSearchModel search)
        {
            var items = commentData.CommentSearchResult(search);

            return items;
        }

        public bool CommentDelete(int commentId)
        {
           return commentData.Delete(commentId);
        }

        public List<T_Joke> GetCategoryJokes(int categoryId,int topCount=10)
        {
            var items = jokeData.GetLastestJokes(categoryId,topCount);
            return items;
        }
        
        public int GetJokesCount(int categoryId)
        {
            return jokeData.GetJokesCount(categoryId);
        }

    }
}
