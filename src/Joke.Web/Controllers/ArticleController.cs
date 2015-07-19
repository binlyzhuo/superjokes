using Joke.BusinessLogic;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}