using Joke.BusinessLogic;
using Joke.Common;
using Joke.Model.Domain;
using Joke.Model.ViewModel;
using Joke.Web.Helpers;
using Joke.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Joke.Web.Auth;
using Microsoft.Security.Application;

namespace Joke.Web.Controllers
{
    public class HomeController : BaseController
    {
        JokeBusinessLogic jokeLogic = new JokeBusinessLogic();
        UserBusinessLogic userBusinessLogic = new UserBusinessLogic();

        // GET: Home
        [OutputCache(Duration=2000)]
        public ActionResult Index()
        {
            SetPageSeo(SiteTitle, SiteKeyWords, SiteDescription);
            ViewBag.BgClass = "indexPage-body";
            return View();
        }

        //
        public ActionResult Login()
        {
            ViewBag.BgClass = "indexPage-body";
            if(Request.IsAuthenticated)
            {
                return RedirectToAction("Profile","User",null);
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel userLoginModel)
        {
            SetPageSeo("用户登录");
            if(!ModelState.IsValid)
            {
                return View();
            }
            List<string> msgList = new List<string>();
            string verifyCode = Session["ValidateCode"] as string;
            if (userLoginModel.VerifyCode != verifyCode)
            {
                msgList.Add("验证码输入错误");
            }

            userLoginModel = new UserLoginModel() {
                VerifyCode = Sanitizer.GetSafeHtmlFragment(userLoginModel.VerifyCode),
                UserName = Sanitizer.GetSafeHtmlFragment(userLoginModel.UserName),
                Password = userLoginModel.Password
            };

            var userinfo = userBusinessLogic.GetUserInfo(userLoginModel.UserName, Md5.GetMd5(userLoginModel.Password));
            if(userinfo!=null)
            {
                UserInfo user = new UserInfo(userinfo.ID, userinfo.UserName, userinfo.IsAdmin);
                var userJson = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(1, userinfo.UserName, DateTime.Now, DateTime.Now.AddDays(1), true, userJson);
                string cookieString = FormsAuthentication.Encrypt(ticket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName,cookieString);
                authCookie.Expires = ticket.Expiration;
                authCookie.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(authCookie);


                //FormsAuthentication.SetAuthCookie(userLoginModel.UserName,true);
                //var uname = User.Identity.Name;
                

                bool isAuth = Request.IsAuthenticated;
                return RedirectToAction("Profile", "User", null);
            }
            else
            {
                msgList.Add("用户名或密码错误");
                ViewBag.MsgList = msgList;
                return View();
            }

            
        }

        public ActionResult LoginResult()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.BgClass = "indexPage-body";
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel userRegister)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            List<string> msgList = new List<string>();
            string verifyCode = Session["ValidateCode"] as string;
            if (userRegister.VerifyCode != verifyCode)
            {
                msgList.Add("验证码输入错误");
            }

            
            var userinfo = userBusinessLogic.GetUserInfoByUserName(userRegister.UserName);
            if(userinfo!=null)
            {
                msgList.Add("用户名已存在");
            }

            userinfo = userBusinessLogic.GetUserInfoByEmail(userRegister.Email);
            if(userinfo!=null)
            {
                msgList.Add("Email已存在");
            }

            if(msgList.Count>0)
            {
                ViewBag.MsgList = msgList;
                return View();
            }
            T_User userDomain = new T_User()
            {
                UserName = Sanitizer.GetSafeHtmlFragment(userRegister.UserName),
                Email = Sanitizer.GetSafeHtmlFragment(userRegister.Email),
                LastLogin = DateTime.Now,
                NikeName = "",
                Password = Md5.GetMd5(userRegister.Password),
                Photo = "",
                RegisterDate = DateTime.Now, IsAdmin=0, State=1
            };
            int userId = userBusinessLogic.AddUser(userDomain);
            if(userId>0)
            {
                return RedirectToAction("Profile","User",null);
            }
            return View();
        }

        public ActionResult RegisterResult()
        {
            return View();
        }

        
        public ActionResult Latest(int page=1)
        {
            SetPageSeo("最新冷笑话_最新成人笑话_最新笑话_笑话大全_超级冷笑话", SiteKeyWords, SiteDescription);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.SearchType = JokeSearchType.Latest;
            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = "latest";
            return View("~/Views/Home/JokeList.cshtml", pageResult);
        }

        public ActionResult LengXiaoHua(int page = 1)
        {
            SetPageSeo("最新冷笑话_最新成人笑话_最新笑话_笑话大全", SiteKeyWords, SiteDescription);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.SearchType = JokeSearchType.LengXioaHua;
            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = "lengxiaohua";
            return View("~/Views/Home/JokeList.cshtml", pageResult);
        }

        public ActionResult Images(int page = 1)
        {
            
            SetPageSeo("最新冷笑话_最新成人笑话_最新笑话_笑话大全_超级冷笑话", SiteKeyWords, SiteDescription);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.SearchType = JokeSearchType.ImageJokes;
            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = "images";
            return View("~/Views/Home/JokeList.cshtml", pageResult);
            
        }

        public ActionResult JokeCategoryList(string pinyin,int page=1,int pagesize=20)
        {
            
            pinyin = Sanitizer.GetSafeHtmlFragment(pinyin);
            var category = jokeLogic.CategoryGet(pinyin);
            string title = string.Format("{0}笑话大全_超级冷笑话",category.Name);
            string keywords = string.Format("{0}，{1}",category.Name,SiteKeyWords);
            string description = string.Format("{0}笑话，{1}", category.Name, SiteDescription);
            SetPageSeo(title,keywords,description);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.PageSize = pagesize;
            search.CategoryPinyin = pinyin;
            search.CategoryID = category.ID;
            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = pinyin;
            return View("~/Views/Home/JokeList.cshtml", pageResult);
        }

        public ActionResult CategorySummary()
        {
            var items = jokeLogic.CategorySummaryInfo();
            return View(items);
        }

        public ActionResult LatestJokes()
        {
            var item = jokeLogic.LatestJokesGet();
            return View(item);
        }

        public ActionResult LikeMostJokes()
        {
            var jokes = jokeLogic.LikeMostJokesGet(20,null);
            return View(jokes);
        }

        public ActionResult JokeImgList()
        {
            var jokeImgs = jokeLogic.GetJokes(10, 1);
            return View(jokeImgs);
        }

        public ActionResult GetVerifyCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        

        public ActionResult CategoryJokeList()
        {
            var items = jokeLogic.GetCategoryList();
            return View(items);
        }

        public ActionResult PageError()
        {
            return View();
        }
    }
}