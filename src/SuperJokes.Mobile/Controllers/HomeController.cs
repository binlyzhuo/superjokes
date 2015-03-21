using Joke.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joke.Model.Domain;

namespace SuperJokes.Mobile.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        JokeBusinessLogic jokeLogic = new JokeBusinessLogic();
        public ActionResult Index()
        {
          
            var items = jokeLogic.LikeMostJokesGet(20,0);

            return View(items);
        }

        public ActionResult JokeDetail(int jokeid)
        {
            var jokeinfo = jokeLogic.GetLastNextJokes(jokeid);
            //string title = jokeinfo.Item1.Title;
            string title = string.Format("{0}，冷笑话，成人笑话_超级冷笑话", jokeinfo.Item1.Title);
            string description = title;
            //SetPageSeo(title, SiteKeyWords, SiteDescription);
            return View(jokeinfo);
        }

        public ActionResult CatrgoryList()
        {
            var category = jokeLogic.GetCategoryList();
            return View(category);
        }
    }
}