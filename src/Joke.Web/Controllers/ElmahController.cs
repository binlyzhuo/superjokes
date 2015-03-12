using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Elmah;
using Elmah.Mvc;
using Joke.Web.Helpers;


namespace Joke.Web.Controllers
{
    public class ElmahController:Controller
    {
        public ActionResult Index(string type)
        {
            return new ElmahResult(type);
        }

        public ActionResult detail(string id)
        {
            return new ElmahResult(id);
        }
    }
}
