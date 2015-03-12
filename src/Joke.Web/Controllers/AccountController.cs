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
    [UserAuthorize(Roles = "Admin")]
    public class AccountController : BaseController
    {
        UserBusinessLogic userLogic = new UserBusinessLogic();
        JokeBusinessLogic jokeLogic = new JokeBusinessLogic();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerifyList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JokeList(int page=1,int pagesize=20,int state=0)
        {
            UserJokesSearchModel userSearch = new UserJokesSearchModel();
            userSearch.JokeState = state;
            var pageViewResult = jokeLogic.UserJokesSearch(userSearch);
            return View(pageViewResult);
        }

        public JsonResult Verify(int jokeid,int type)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            var jokeinfo = jokeLogic.JokeDetailGet(jokeid);
            if(jokeinfo==null||jokeinfo.State==1)
            {
                jsonViewResult.Success = false;
            }
            else
            {
                jokeinfo.State = 1;
                jokeinfo.CheckDate = DateTime.Now;
                jokeinfo.CheckUserId = user.UserId;
                jokeLogic.UpdateJoke(jokeinfo);
                jsonViewResult.Success = true;
            }
            return Json(jsonViewResult,JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteJoke(int jokeid)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            bool deleteResult = jokeLogic.DeleteJoke(jokeid);
            jsonViewResult.Success = deleteResult;
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JokeDetail(int jokeid)
        {
            var jokeinfo = jokeLogic.JokeDetailGet(jokeid);
            return View(jokeinfo);
        }

        public ActionResult UserList(UserSearchModel search)
        {
            var pageResult = userLogic.UserSearch(search);
            return View(pageResult);
        }

        public JsonResult UpdateUserState(int uid,int state)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            var userinfo = userLogic.GetUserInfo(uid);
            userinfo.State = state;
            jsonViewResult.Success = userLogic.UpdateUserInfo(userinfo);
            return Json(jsonViewResult,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UserSearchList(UserSearchModel search)
        {
            var pageResult = userLogic.UserSearch(search);
            return View(pageResult);
        }

        [HttpPost]
        public ActionResult DeleteUser(int uid)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            int userJokesCount = jokeLogic.JokesCount(uid);
            if(userJokesCount>0)
            {
                jsonViewResult.Success = false;
                jsonViewResult.Message = "该会员已发表过笑话，不能删除该会员！";
            }
            else
            {
                jsonViewResult.Success = userLogic.DeleteUser(uid);
            }
            return Json(jsonViewResult,JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateJoke(int jokeid)
        {
            var jokeinfo = jokeLogic.JokeDetailGet(jokeid);
            ////
            return View(jokeinfo);
        }
    }
}