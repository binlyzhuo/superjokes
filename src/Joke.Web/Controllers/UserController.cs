using Joke.BusinessLogic;
using Joke.Common;
using Joke.Model.ViewModel;
using Joke.Web.Auth;
using Joke.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Joke.Web.Controllers
{
    [UserAuthorize(Roles="User,Admin")]
    public class UserController : BaseController
    {
        // GET: User

        private UserBusinessLogic userLogic = new UserBusinessLogic();
        private JokeBusinessLogic jokeLogic = new JokeBusinessLogic();

        public ActionResult Index()
        {
            SetPageSeo("个人中心");
            return View();
        }

        public new ActionResult Profile()
        {
            SetPageSeo("个人信息");
            
            if(user==null)
            {
                return RedirectToAction("Login","Home",null);
            }
            var userinfo = userLogic.GetUserInfo(user.UserId);
            return View(userinfo);
        }

        public ActionResult UpdatePwd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePwd(UserUpdatePwdModel userUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userinfo = userLogic.GetUserInfo(user.UserId);
            List<string> msgList = new List<string>();
            if(userinfo.Password!=userUpdate.OldPwd)
            {
                msgList.Add("旧密码不正确");
            }
            if(userUpdate.Password!=userUpdate.ConfirmPwd)
            {
                msgList.Add("两次输入密码不一致");
            }

            if(msgList.Count>0)
            {
                ViewBag.MsgList = msgList;
                return View();
            }

            userinfo.Password = Md5.GetMd5(userUpdate.Password);
            bool updateResult = userLogic.UpdateUserPwd(userinfo.ID,userinfo.Password);
            ViewBag.Msg = updateResult ? "修改成功" : "修改失败";
            return View();
        }

        public ActionResult Collect()
        {
            return View();
        }

        public ActionResult PostList(UserJokesSearchModel search)
        {
            search.UserId = user.UserId;
            
            var pageViewResult = jokeLogic.UserJokesSearch(search);
            return View(pageViewResult);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/home/index");
            //return RedirectToAction("Index","Home",null);
        }
    }
}