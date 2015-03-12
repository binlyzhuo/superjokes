using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joke.Web.Helpers
{
    public class SafeFilterAttribute:System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}