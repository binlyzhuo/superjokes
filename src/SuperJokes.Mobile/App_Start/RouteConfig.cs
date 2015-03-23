using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SuperJokes.Mobile
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "latestJokesPaging",
                url: "latest/{page}.html",
                defaults: new { controller = "Home", action = "Index", page = 1 }
            );

            routes.MapRoute(
                name: "JokeDetail",
                url: "joke{jokeid}.html",
                defaults: new { controller = "Home", action = "JokeDetail", jokeid = UrlParameter.Optional }
            );

            

            routes.MapRoute(
                name: "CategoryJokesPaging",
                url: "{pinyin}/{page}.html",
                defaults: new { controller = "Home", action = "JokeCategoryList", pinyin = "lengxiaohua",page=1 }
            );

            routes.MapRoute(
                name: "CategoryJokes",
                url: "{pinyin}.html",
                defaults: new { controller = "Home", action = "JokeCategoryList", pinyin = "lengxiaohua" }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
