using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Joke.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "pageerror",
                url: "page404.html",
                defaults: new { controller = "Home", action = "PageError" }
            );

            routes.MapRoute(
                name: "JokeDetail",
                url: "joke{id}.html",
                defaults: new { controller = "Joke", action = "Detail", id = 1 }
            );

            routes.MapRoute(
                name: "UserRegister",
                url: "register",
                defaults: new { controller = "Home", action = "Register" }
            );

            routes.MapRoute(
                name: "UserLogin",
                url: "login",
                defaults: new { controller = "Home", action = "Login" }
            );

            routes.MapRoute(
                name: "CategoryJokes",
                url: "{pinyin}.html",
                defaults: new { controller = "Home", action = "JokeCategoryList", pinyin="lengxiaohua" }
            );

            routes.MapRoute(
                name: "CategoryJokesPaging",
                url: "{pinyin}/{page}.html",
                defaults: new { controller = "Home", action = "JokeCategoryList", pinyin = "lengxiaohua",page=1 }
            );

            routes.MapRoute(
                name: "latestjokes",
                url: "latest",
                defaults: new { controller = "Home", action = "Latest" }
            );

            routes.MapRoute(
                name: "lengxiaohuajokies",
                url: "lengxiaohua",
                defaults: new { controller = "Home", action = "LengXiaoHua"}
            );

            routes.MapRoute(
                name: "imgjokeslist",
                url: "images",
                defaults: new { controller = "Home", action = "Images" }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            
        }
    }
}
