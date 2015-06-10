using Joke.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Joke.Web.Auth;

namespace Joke.Web.Controllers
{
    public class BaseController:Controller
    {
        protected UserInfoPrincipal user = System.Web.HttpContext.Current.User as UserInfoPrincipal;
        protected string JokeImgUpload = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["JokeImgUpload"]);
        protected string JokeImgUploadConfig = ConfigurationManager.AppSettings["JokeImgUpload"];
        protected string SiteTitle = ConfigurationManager.AppSettings["SiteTitle"];
        protected string SiteKeyWords = ConfigurationManager.AppSettings["SiteKeyWords"];
        protected string SiteDescription = ConfigurationManager.AppSettings["SiteDescription"];
        

        protected void SetPageSeo(string title,string keywords="",string description="")
        {
            ViewBag.Title = title;
            ViewBag.KeyWords = keywords;
            ViewBag.Description = description;
        }

        protected void RedirectUrl(string url)
        {
            Response.Clear();
            Response.BufferOutput = true;
            if(Response.IsRequestBeingRedirected)
            {
                Response.Redirect(url,true);
            }
        }
    }
}