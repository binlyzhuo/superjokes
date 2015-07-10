using Joke.BusinessLogic;
using Joke.Common;
using Joke.Model.Domain;
using Joke.Model.ViewModel;
using Joke.Web.Auth;
using Joke.Web.Helpers;
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
        FriendLinkBusinessLogic friendLinkLogic = new FriendLinkBusinessLogic();
        // GET: Account
        public ActionResult Index()
        {
            int jokeToVerifyCount = jokeLogic.JokesStateCount(0);
            return View(jokeToVerifyCount);
        }

        public ActionResult VerifyList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JokeList(int page = 1, int pagesize = 20, int state = 0)
        {
            UserJokesSearchModel userSearch = new UserJokesSearchModel();
            userSearch.JokeState = state;
            var pageViewResult = jokeLogic.UserJokesSearch(userSearch);
            return View(pageViewResult);
        }

        public JsonResult Verify(int jokeid, int type)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            var jokeinfo = jokeLogic.JokeDetailGet(jokeid);
            if (jokeinfo == null || jokeinfo.State == 1)
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


                // 发送审核
                var userinfo = userLogic.GetUserInfo(jokeinfo.PostID);
                string jokeUrl = string.Format("http://{0}/joke{1}.html", Request.Url.Authority, jokeinfo.ID);
                NoticeMail.VerifyNotice(userinfo.UserName, userinfo.Email, jokeinfo.Title, jokeUrl);

            }
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteJoke(int jokeid)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            jsonViewResult.Success = jokeLogic.DeleteJoke(jokeid);
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

        public JsonResult UpdateUserState(int uid, int state)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            var userinfo = userLogic.GetUserInfo(uid);
            userinfo.State = state;
            jsonViewResult.Success = userLogic.UpdateUserInfo(userinfo);
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UserSearchList(int page = 1)
        {
            UserSearchModel search = new UserSearchModel();
            search.Page = page;
            var pageResult = userLogic.UserSearch(search);
            return View(pageResult);
        }

        [HttpPost]
        public ActionResult DeleteUser(int uid)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            int userJokesCount = jokeLogic.JokesCount(uid);
            var userinfo = userLogic.GetUserInfo(uid);
            if (userinfo.IsAdmin > 0)
            {
                jsonViewResult.Success = false;
                jsonViewResult.Message = "不能删除管理员";
                return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
            }
            if (userJokesCount > 0)
            {
                jsonViewResult.Success = false;
                jsonViewResult.Message = "该会员已发表过笑话，不能删除该会员！";
            }
            else
            {
                jsonViewResult.Success = userLogic.DeleteUser(uid);

            }
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UpdateJoke(int jokeid)
        {
            var jokeinfo = jokeLogic.JokeDetailGet(jokeid);
            ////
            return View(jokeinfo);
        }

        public ActionResult UpdateJoke(int jokeId, string title, string content, int categoryid)
        {
            return View();
        }

        public ActionResult UserLog()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UserLogResult(int page = 1)
        {
            UserLogSearchModel search = new UserLogSearchModel();
            search.Page = page;
            var pageResult = userLogic.UserLogSearch(search);
            return View(pageResult);
        }

        public ActionResult Links()
        {
            return View();
        }

        public ActionResult LinkEdit(int id = 0)
        {
            LinkEditModel linkModel;
            if (id == 0)
            {
                linkModel = new LinkEditModel();
            }
            else
            {
                var link = friendLinkLogic.GetFriendLink(id);
                linkModel = new LinkEditModel()
                {
                    ID = link.ID,
                    KeyWords = link.Remark,
                    LinkMan = link.LinkMan,
                    LinkUrl = link.LinkUrl,
                    SiteName = link.Name
                };
            }
            return View(linkModel);
        }

        [HttpPost]
        public ActionResult LinkEdit(LinkEditModel linkModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            T_FriendLink link;
            bool result = false;
            if (linkModel.ID == 0)
            {
                link = new T_FriendLink()
                {
                    AddDate = DateTime.Now,
                    AddUserID = user.UserId,
                    LinkMan = linkModel.LinkMan,
                    LinkUrl = linkModel.LinkUrl,
                    Name = linkModel.SiteName,
                    State = 1,
                    Remark = linkModel.KeyWords
                };

                result = friendLinkLogic.AddFriendLink(link);
                return RedirectToAction("Links");
            }
            else
            {
                link = friendLinkLogic.GetFriendLink(linkModel.ID);
                link.Name = linkModel.SiteName;
                link.LinkUrl = linkModel.LinkUrl;
                link.Remark = linkModel.KeyWords;
                link.LinkMan = linkModel.LinkMan;

                result=friendLinkLogic.UpdateFriendLink(link);
            }
            if(result)
            {
                WebCache.Remove(friendLinkLogic.FriendLinksKey);
                return RedirectToAction("links");
            }
            return View();
        }

        public ActionResult LinkResult(int page = 1)
        {
            FriendLinkSearch search = new FriendLinkSearch();
            search.Page = page;
            var pageResult = friendLinkLogic.FriendLinkSearch(search);
            return View(pageResult);
        }

        [HttpPost]
        public JsonResult DeleteLink(int id)
        {
            JsonViewResult json = new JsonViewResult();
            json.Success = friendLinkLogic.DeleteFriendLink(id);
            if(json.Success)
            {
                WebCache.Remove(friendLinkLogic.FriendLinksKey);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Comments()
        {
            return View();
        }

        public ActionResult CommentResult(CommentManageSearch search)
        {
            var items = jokeLogic.CommentManageSearch(search);
            return View(items);
        }
    }
}