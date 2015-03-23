using Joke.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using Joke.Model.Domain;
using Joke.Model.ViewModel;
using Microsoft.Security.Application;

namespace SuperJokes.Mobile.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private string SiteKeyWords = ConfigurationManager.AppSettings["SiteKeyWords"];
        private string SiteDescription = ConfigurationManager.AppSettings["SiteDescription"];

        JokeBusinessLogic jokeLogic = new JokeBusinessLogic();
        public ActionResult Index(UserJokesSearchModel userSearch)
        {
            userSearch.JokeType = 0;
            userSearch.JokeState = 1;
            userSearch.UserId = null;
            var items = jokeLogic.UserJokesSearch(userSearch);
            items.Data = "latest";
            items.Data1 = "最新";
            return View(items);
        }

        public ActionResult JokeDetail(int jokeid)
        {
            var jokeinfo = jokeLogic.GetLastNextJokes(jokeid,0);
            
            string title = string.Format("{0}，冷笑话，成人笑话_超级冷笑话", jokeinfo.Item1.Title);
            string description = title;
            SetPageSeo(title, SiteKeyWords, SiteDescription);
            return View(jokeinfo);
        }

        public ActionResult CatrgoryList()
        {
            var category = jokeLogic.GetCategoryList();
            return View(category);
        }

        public ActionResult JokeCategoryList(string pinyin, int page = 1, int pagesize = 20)
        {

            pinyin = Sanitizer.GetSafeHtmlFragment(pinyin);
            var category = jokeLogic.CategoryGet(pinyin);
            string title = string.Format("{0}笑话大全_超级冷笑话", category.Name);
            string keywords = string.Format("{0}，{1}", category.Name, SiteKeyWords);
            string description = string.Format("{0}笑话，{1}", category.Name, SiteDescription);
            SetPageSeo(title, keywords, description);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.PageSize = pagesize;
            search.CategoryPinyin = pinyin;
            search.CategoryID = category.ID;

            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = pinyin;
            pageResult.Data1 = category.Name;
            return View("~/Views/Home/JokeList.cshtml", pageResult);
        }

        private void SetPageSeo(string title, string keywords = "", string description = "")
        {
            ViewBag.Title = title;
            ViewBag.KeyWords = keywords;
            ViewBag.Description = description;
        }
    }
}