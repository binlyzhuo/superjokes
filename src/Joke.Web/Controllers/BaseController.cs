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

        protected void UserLogin()
        {
            //user = UserInfo.GetUserInfo();
        }

        protected void SetPageSeo(string title,string keywords="",string description="")
        {
            ViewBag.Title = title;
            ViewBag.KeyWords = keywords;
            ViewBag.Description = description;
        }
    }
}