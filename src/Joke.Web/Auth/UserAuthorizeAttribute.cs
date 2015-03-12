using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Joke.Web.Auth
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { 
                   controller="Home",action="Login",returnUrl=filterContext.HttpContext.Request.Url,returnMessage="请先登录"
                }));
            }
            base.OnAuthorization(filterContext);
        }
    }
}