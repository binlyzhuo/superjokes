using Joke.BusinessLogic;
using Joke.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joke.Web.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Article
        ArticleBusinessLogic articleLogic = new ArticleBusinessLogic();
        JokeBusinessLogic jokeBusinessLogic = new JokeBusinessLogic();

        public ActionResult Index()
        {
            return View();
        }

        [UserAuthorize(Roles = "Admin")]
        public ActionResult Post()
        {
            var categoryDtos = jokeBusinessLogic.GetCategoryList();
            return View(categoryDtos);
        }

        [HttpPost]
        [UserAuthorize(Roles = "Admin")]
        [ValidateInput(false)]
        public ActionResult Post(string joketitle, string jokecontent, int jokecategory)
        {
            return RedirectToAction("PostResult");
        }

        //[HttpPost]
        public ActionResult PostResult()
        {
            return View();
        }
    }
}