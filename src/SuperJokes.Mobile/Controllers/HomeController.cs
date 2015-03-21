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
    }
}