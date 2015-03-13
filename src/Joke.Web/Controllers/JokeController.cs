using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Joke.BusinessLogic;
using Joke.Model.Domain;
using Joke.Web.Models;
using Joke.Model.ViewModel;
using Joke.Common;
using Joke.Web.Auth;
using Microsoft.Security.Application;

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
                string uploadFolder = string.Format("{3}\\{0}\\{1}\\{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, JokeImgUpload);
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                jokeImgFile.SaveAs(uploadFolder + "\\" + newName);
                string fileName = jokeImgFile.FileName;
                content = string.Format("{0}\\{1}\\{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) + "\\" + newName;
            }
          
            T_Joke jokeinfo = new T_Joke()
            {
                AddDate = DateTime.Now,
                Category = jokecategory,
                CheckDate = DateTime.Parse("1900-01-01"),
                CheckUserId = 0,
                CommentCount = 0,
                Content = Sanitizer.GetSafeHtmlFragment(content),
                HateCount = 0,
                LikeCount = 0,
                PostID = user.UserId,
                State = 0,
                Title = Sanitizer.GetSafeHtmlFragment(joketitle),
                Type = joketype
            };
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

            var jokeinfo = jokeBusinessLogic.GetLastNextJokes(id);
            string title = jokeinfo.Item1.Title;
            string keywords = string.Format("{0}，冷笑话，成人笑话", title);
            string description = title;
            SetPageSeo(title,keywords,description);
            return View(jokeinfo);
        }

        public ActionResult ReadMostJokes()
        {
            var jokes = jokeBusinessLogic.MostReadJokesGet();
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
    }
}