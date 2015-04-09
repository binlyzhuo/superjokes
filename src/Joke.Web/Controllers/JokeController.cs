using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading;
using Joke.BusinessLogic;
using Joke.Model.Domain;
using Joke.Web.Models;
using Joke.Model.ViewModel;
using Joke.Common;
using Joke.Web.Auth;
using Microsoft.Security.Application;
using Travelling.Web.Helpers;
using Joke.Web.Helpers;

namespace Joke.Web.Controllers
{
    public class JokeController : BaseController
    {
        JokeBusinessLogic jokeBusinessLogic = new JokeBusinessLogic();
        UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
        // GET: Joke
        public ActionResult Index()
        {
            return View();
        }

        [UserAuthorize(Roles="User,Admin")]
        [HttpGet]
        public ActionResult PostJoke()
        {
            SetPageSeo("发布笑话");
            var categoryDtos = jokeBusinessLogic.GetCategoryList();
            return View(categoryDtos);
        }

        [UserAuthorize(Roles="User,Admin")]
        [HttpPost]
        public ActionResult PostJoke(string joketitle, string jokecontent, int joketype, int jokecategory,HttpPostedFileBase jokeImgFile)
        {
            string content = "";
            if(joketype==0)
            {
                content = jokecontent;
            }
            else if(joketype==1)
            {
                FileInfoHelper.GetFileName(jokeImgFile.FileName);
                FileInfoHelper.GetFileExtend(jokeImgFile.FileName);
                string newName = FileInfoHelper.GetNewName(jokeImgFile.FileName);
                if (Request.IsLocal)
                {
                    newName = string.Format("local_{0}",newName);
                }
                else
                {
                    newName = string.Format("online_{0}", newName);
                }
                string uploadFolder = string.Format("{3}\\{0}\\{1}\\{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, JokeImgUpload);
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                //
                jokeImgFile.SaveAs(uploadFolder + "\\" + newName);
                Thread.Sleep(1);
                string fileName = jokeImgFile.FileName;
                content = string.Format("{0}\\{1}\\{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) + "\\" + newName;
                if(AppConfig.IsQiniuUpload>0)
                {
                    bool updateResult = QiniuUpload.PutFile(newName, uploadFolder + "\\" + newName);
                }
                
            }
          
            T_Joke jokeinfo = new T_Joke()
            {
                AddDate = DateTime.Now,
                Category = jokecategory,
                CheckDate = DateTime.Parse("1900-01-01"),
                CheckUserId = 0,
                CommentCount = 0,
                Content = content,
                HateCount = 0,
                LikeCount = 0,
                PostID = user.UserId,
                State = 0,
                Title = joketitle,
                Type = joketype
            };

            if(user.IsAdmin>0)
            {
                jokeinfo.State = 1;
                jokeinfo.CheckDate = DateTime.Now;
                jokeinfo.CheckUserId = user.UserId;
            }
            int jokeId=jokeBusinessLogic.AddJoke(jokeinfo);
            PostJokeResult postResult = new PostJokeResult() {
                Success = jokeId>0?true:false,
                Message = jokeId>0?"发表成功":"发表失败"
            };

            return RedirectToAction("PostJokeResult", postResult);

        }

        [UserAuthorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult PostJokeResult(PostJokeResult postResult)
        {
            return View(postResult);
        }

        public ActionResult Detail(int id)
        {
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            if (!string.IsNullOrEmpty(strUserAgent))
            {
                if(Request.Browser.IsMobileDevice)
                {
                    Response.StatusCode = 301;
                    Response.RedirectLocation = string.Format("http://m.superjokes.cn/joke{0}.html", id);
                    Response.End(); 
                }
                
            }

            var jokeinfo = jokeBusinessLogic.GetLastNextJokes(id);
            string title = string.Format("冷笑话_超级冷笑话_{0}_冷笑话大全_成人笑话_糗事百科_十万个冷笑话", jokeinfo.Item1.Title);
            string description = title;
            SetPageSeo(title,SiteKeyWords,SiteDescription);
            return View(jokeinfo);
        }

        public ActionResult ReadMostJokes()
        {
            var jokes = jokeBusinessLogic.MostReadJokesGet(12);
            return View(jokes);
        }

        public ActionResult CategoryList()
        {
            var items = jokeBusinessLogic.GetCategoryList();
            return View(items);
        }

        public ActionResult JokeList(string pinyin)
        {
            JokeSearchModel search = new JokeSearchModel();
            search.Page = 1;
            search.PageSize = 20;
            var pageResult = jokeBusinessLogic.JokePostInfo(search);
            return View(pageResult);
        }

        public ActionResult CategoryJokeList()
        {
            var items = jokeBusinessLogic.GetCategoryList();
            return View(items);
        }

        public ActionResult Last20HourJokes()
        {
            var items = jokeBusinessLogic.GetLast20HoursJokes();
            return View(items);
        }

        public JsonResult JokeFollow(int jokeid,int type)
        {
            JsonViewResult jsonResult = new JsonViewResult();
            var jokeinfo = jokeBusinessLogic.JokeDetailGet(jokeid);
            if(type==1)
            {
                jokeinfo.LikeCount = jokeinfo.LikeCount + 1;
            }
            else if(type==2)
            {
                jokeinfo.HateCount = jokeinfo.HateCount + 1;
            }
            jokeBusinessLogic.UpdateJoke(jokeinfo);
            jsonResult.Success = true;
            return Json(jsonResult,JsonRequestBehavior.AllowGet);
        }

        public ActionResult LikeMostImages()
        {
            var items = jokeBusinessLogic.LikeMostJokesGet(10, 1);
            return View(items);
        }

        [UserAuthorize(Roles = "Admin")]
        public ActionResult UpdateJoke(int jokeid)
        {
            var jokeinfo = jokeBusinessLogic.JokeDetailGet(jokeid);
            JokeUpdateModel jokeModel = new JokeUpdateModel() { 
              ID = jokeinfo.ID, Title = jokeinfo.Title,Content = jokeinfo.Content,Type = jokeinfo.Type,Category = jokeinfo.Category
            };
            var categoryDtos = jokeBusinessLogic.GetCategoryList();
            ViewBag.Categories = categoryDtos;
            return View(jokeModel);
        }

        [UserAuthorize(Roles = "Admin")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateJoke(JokeUpdateModel jokeModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var jokeinfo = jokeBusinessLogic.JokeDetailGet(jokeModel.ID);
            jokeinfo.Title =jokeModel.Title;
            jokeinfo.Content = jokeModel.Content;
            jokeinfo.Category = jokeModel.Category;

            bool updateResult=jokeBusinessLogic.UpdateJoke(jokeinfo);
            return RedirectToAction("Detail", new { id=jokeModel.ID});
        }

        public ActionResult Comments(CommentSearchModel search)
        {
            var items = jokeBusinessLogic.CommentSearchResult(search);
            return View(items);
        }

        [HttpPost]
        [UserAuthorize(Roles = "User,Admin")]
        public ActionResult PostComment(CommentPostModel commentPost)
        {
            JsonViewResult json = new JsonViewResult() { Success = false };
            if(!ModelState.IsValid)
            {
                json.Success = false;
                json.Message = "输入错误";
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            string verifyCode = Session["ValidateCode"] as string;
            if(verifyCode.ToLower()!=commentPost.VerifyCode)
            {
                json.Success = false;
                json.Message = "验证码输入错误";
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            var jokeinfo = jokeBusinessLogic.JokeDetailGet(commentPost.JokeID);
            
            T_Comment commentDomain = new T_Comment();
            commentDomain.AddDate = DateTime.Now;
            commentDomain.Content = commentPost.Comment;
            commentDomain.Floor = jokeinfo.CommentCount+1;
            commentDomain.JokeId = commentPost.JokeID;
            commentDomain.UserID = user.UserId;
            jokeinfo.CommentCount = jokeinfo.CommentCount + 1;
            jokeBusinessLogic.UpdateJoke(jokeinfo);
            json.Success = jokeBusinessLogic.AddComment(commentDomain);
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [UserAuthorize(Roles = "User,Admin")]
        public ActionResult CommentList(CommentSearchModel search)
        {
            var items = jokeBusinessLogic.CommentSearchResult(search);
            return View(items);
        }

        [HttpPost]
        [UserAuthorize(Roles = "Admin")]
        public JsonResult DeleteComment(int commentid)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success = jokeBusinessLogic.CommentDelete(commentid);
            return Json(jsonViewResult,JsonRequestBehavior.AllowGet);
        }
    }
}