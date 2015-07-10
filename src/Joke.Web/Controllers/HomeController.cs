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
using Joke.Web.Filter;

namespace Joke.Web.Controllers
{
    public class HomeController : BaseController
    {
        JokeBusinessLogic jokeLogic = new JokeBusinessLogic();
        UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
        FriendLinkBusinessLogic linksLogic = new FriendLinkBusinessLogic();

        // GET: Home
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            // 初始化数据
            // 第一次运行请执行该代码来导入类型,导入后就可以删除了
            // jokeLogic.InitCategory();
            //

            // 判断是否是手机端
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            if (!string.IsNullOrEmpty(strUserAgent))
            {
                if (Request.Browser.IsMobileDevice)
                {
                    Response.StatusCode = 301;
                    Response.RedirectLocation = "http://m.superjokes.cn";
                    Response.End();
                }

            }

            //

            SetPageSeo(SiteTitle, SiteKeyWords, SiteDescription);
            return View();
        }

        //
        [LoginCheck]
        public ActionResult Login()
        {

            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Profile", "User", null);
            }

            return View();
        }

        [HttpPost]
        [LoginCheck]
        public ActionResult Login(UserLoginModel userLoginModel)
        {
            SetPageSeo("用户登录");
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<string> msgList = new List<string>();
            string verifyCode = Session["ValidateCode"] as string;
            if (userLoginModel.VerifyCode != verifyCode)
            {
                msgList.Add("验证码输入错误");
            }

            userLoginModel = new UserLoginModel()
            {
                VerifyCode = Sanitizer.GetSafeHtmlFragment(userLoginModel.VerifyCode),
                UserName = Sanitizer.GetSafeHtmlFragment(userLoginModel.UserName),
                Password = userLoginModel.Password
            };

            var userinfo = userBusinessLogic.GetUserInfo(userLoginModel.UserName, Md5.GetMd5(userLoginModel.Password));
            if (userinfo != null)
            {
                UserInfo user = new UserInfo(userinfo.ID, userinfo.UserName, userinfo.IsAdmin);
                var userJson = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(1, userinfo.UserName, DateTime.Now, DateTime.Now.AddDays(1), true, userJson);
                //FormsAuthentication.SetAuthCookie(userLoginModel.UserName, true);
                string cookieString = FormsAuthentication.Encrypt(ticket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieString);
                authCookie.Expires = ticket.Expiration;
                authCookie.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(authCookie);


                bool isAuth = Request.IsAuthenticated;

                // add log
                if (user.IsAdmin > 0)
                {
                    T_UserLog log = new T_UserLog()
                    {
                        AddDate = DateTime.Now,
                        Content = string.Format("{0}于{1}登录系统", user.UserName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        UserID = user.UserID,
                        UserName = user.UserName
                    };
                    userBusinessLogic.AddUserLog(log);
                }
                
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
        [LoginCheck]
        public ActionResult Register()
        {
            ViewBag.BgClass = "indexPage-body";

            return View();
        }

        [HttpPost]
        [LoginCheck]
        public ActionResult Register(UserRegisterModel userRegister)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            List<string> msgList = new List<string>();
            string verifyCode = Session["ValidateCode"] as string;
            if (userRegister.VerifyCode != verifyCode)
            {
                msgList.Add("验证码输入错误");
            }

            if(!Utility.IsEmail(userRegister.Email))
            {
                msgList.Add("Email输入错误");
            }

            var userinfo = userBusinessLogic.GetUserInfoByUserName(userRegister.UserName);
            if (userinfo != null)
            {
                msgList.Add("用户名已存在");
            }

            userinfo = userBusinessLogic.GetUserInfoByEmail(userRegister.Email);
            if (userinfo != null)
            {
                msgList.Add("Email已存在");
            }

            if (msgList.Count > 0)
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
                RegisterDate = DateTime.Now,
                IsAdmin = 0,
                State = 1
            };
            int userId = userBusinessLogic.AddUser(userDomain);
            if (userId > 0)
            {
                // 发送注册成功提醒邮件
                NoticeMail.SendWelcomeMail(userDomain.UserName, userDomain.Email);
                msgList.Add("注册成功!");
                ViewBag.MsgList = msgList;
                //return RedirectToAction("Profile", "User", null);
            }
            //Response.Write("<script>alert('注册成功，请登录！');</script>");
            
            return View();
        }

        public ActionResult RegisterResult()
        {
            return View();
        }


        public ActionResult Latest(int page = 1)
        {
            SetPageSeo(string.Format("{1}年最新冷笑话_最新成人笑话_超级冷笑话_第{0}页", page,DateTime.Now.Year), SiteKeyWords, SiteDescription);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.SearchType = JokeSearchType.Latest;
            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = "latest";
            pageResult.Data1 = "最新冷笑话";
            
            return View("~/Views/Home/JokeList.cshtml", pageResult);
        }

        public ActionResult LengXiaoHua(int page = 1)
        {
            SetPageSeo(string.Format("最新冷笑话_笑话大全_第{0}页", page), SiteKeyWords, SiteDescription);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.SearchType = JokeSearchType.LengXioaHua;
            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = "lengxiaohua";
            pageResult.Data1 = "冷笑话";
            return View("~/Views/Home/JokeList.cshtml", pageResult);
        }

        public ActionResult Images(int page = 1)
        {

            SetPageSeo(string.Format("搞笑图片_成人搞笑图片_超级冷笑话_第{0}页", page), SiteKeyWords, SiteDescription);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.SearchType = JokeSearchType.ImageJokes;
            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = "images";
            pageResult.Data1 = "搞笑图片";
            return View("~/Views/Home/JokeList.cshtml", pageResult);

        }

        public ActionResult JokeCategoryList(string pinyin, int page = 1, int pagesize = 20)
        {

            pinyin = Sanitizer.GetSafeHtmlFragment(pinyin);
            var category = jokeLogic.CategoryGet(pinyin);
            string title = string.Format("{0}笑话大全_超级冷笑话_第{1}页", category.Name, page);
            string keywords = string.Format("{0}笑话，{1}", category.Name, SiteKeyWords);
            string description = string.Format("{0}笑话，{1}", category.Name, SiteDescription);
            SetPageSeo(title, keywords, description);
            JokeSearchModel search = new JokeSearchModel();
            search.Page = page;
            search.PageSize = pagesize;
            search.CategoryPinyin = pinyin;
            search.CategoryID = category.ID;
            var pageResult = jokeLogic.JokePostInfo(search);
            pageResult.Data = pinyin;
            pageResult.Data1 = category.Name;
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
            var jokes = jokeLogic.LikeMostJokesGet(10, null);
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



        public ActionResult CategoryJokeList(string category="")
        {
            var items = jokeLogic.GetCategoryList();
            return View(items);
        }

        public ActionResult PageError()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult QQCallBack()
        {
            return View();
        }



        /// <summary>
        /// 热门笑话
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ActionResult HotCategoryJokes(int categoryId = 1)
        {
            var category = jokeLogic.GetCategoryInfo(categoryId);
            JokeCategoryJokesModel model = new JokeCategoryJokesModel();
            model.CategoryID = categoryId;
            model.CategoryName = category.Name;
            model.PinYin = category.PinYin;
            model.JokeInfos = jokeLogic.GetCategoryJokes(categoryId, 10);
            model.TotalCount = jokeLogic.GetJokesCount(categoryId);
            return View(model);
        }

        public ActionResult GetPwd()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetPwd(string userEmail)
        {
            JsonViewResult json = new JsonViewResult();
            if (string.IsNullOrEmpty(userEmail) || !Utility.IsEmail(userEmail))
            {
                json.Message = "邮箱格式不正确!";
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            var userinfo = userBusinessLogic.GetUserInfoByEmail(userEmail);
            if (userinfo == null)
            {
                json.Success = false;
                json.Message = "找不到用户信息，请确认邮箱输入正确！";
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            var getpwdRecord = userBusinessLogic.GetPwdRecord(userinfo.ID);
            if (getpwdRecord != null)
            {
                json.Message = "已发送,请查收邮箱";
                json.Success = true;
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            T_GetPwd getpwd = new T_GetPwd()
            {
                AddDate = DateTime.Now,
                Guid = Guid.NewGuid().ToString("N"),
                UserID = userinfo.ID,
                ExpireDate = DateTime.Now.AddHours(3),
                State = 1
            };

            json.Success = userBusinessLogic.AddGetPwdRecord(getpwd);
            json.Message = "已发送,请查收邮箱";
            string url = "http://" + Request.Url.Authority + "/home/ResetPwd?guid=" + getpwd.Guid;
            NoticeMail.GetPassword(userinfo.UserName, userinfo.Email, url);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ResetPwd(string guid)
        {
            var getpwdRecord = userBusinessLogic.GetPwdRecord(guid);
            bool checkResult = false;
            if (getpwdRecord != null)
            {
                checkResult = true;
            }
            ViewBag.CheckResult = checkResult;
            GetPasswordModel model = new GetPasswordModel();
            model.Guid = guid;
            return View(model);
        }

        [HttpPost]
        public JsonResult ResetPwd(string guid, string password, string configpwd)
        {
            JsonViewResult json = new JsonViewResult();

            if (string.IsNullOrEmpty(guid) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(configpwd))
            {
                json.Success = false;
                json.Message = "请输入密码和确认密码！";
                json.Status = 1;
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            if (password.Length < 6)
            {
                json.Success = false;
                json.Message = "密码长度小于6位！";
                json.Status = 1;
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            var getpwd = userBusinessLogic.GetPwdRecord(guid);
            if (getpwd == null)
            {
                json.Success = false;
                json.Message = "修改状态不正确，请重新提交修改申请！";
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            var userinfo = userBusinessLogic.GetUserInfo(getpwd.UserID);
            if (userinfo == null)
            {
                json.Success = false;
                json.Message = "用户状态不正确！";
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            userinfo.Password = Md5.GetMd5(password);
            json.Success = userBusinessLogic.UpdateUserPwd(userinfo.ID, userinfo.Password);
            if (json.Success)
            {
                json.Message = "密码修改成功!";
                getpwd.State = 0;
                userBusinessLogic.UpdateGetPwd(getpwd);
            }
            else
            {
                json.Message = "密码修改失败！";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 10)]
        public ActionResult FriendLinks()
        {
            var links = linksLogic.GetFriendLinks();

            //var links = WebCache.GetCacheObject<List<T_FriendLink>>(linksLogic.FriendLinksKey);
            //if (links == null || links.Count == 0)
            //{
            //    links = linksLogic.GetFriendLinks();
            //    WebCache.CacheInsert(links, linksLogic.FriendLinksKey);
            //}
            return View("~/Views/Shared/_FriendLinks.cshtml", links);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult TagsCloud()
        {
            var items = jokeLogic.GetCategoryList();
            return View(items);
        }
    }
}