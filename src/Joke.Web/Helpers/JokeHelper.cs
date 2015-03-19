using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Travelling.Web.Helpers;
using Joke.Common;
using Joke.Model.ViewModel;
using Microsoft.Security.Application;

namespace Joke.Web.Helpers
{
    public class JokeHelper
    {
        public static string GetJokeDetail(int jokeid)
        {
            return string.Format("/joke{0}.html",jokeid);
        }

        public static string GetCategoryJokes(string pinyin)
        {
            return string.Format("/{0}.html",pinyin.ToLower());
        }

        public static string GetJokeImg(string imgName)
        {
            if(AppConfig.IsQiniuUpload>0)
            {
                return string.Format("{0}/{1}", QiniuUpload.QiniuCloudUrl, FileInfoHelper.GetFileName(imgName));
            }
            else
            {
                return string.Format("{1}/{0}", imgName,AppConfig.JokeImgUpload);
            }
        }

        public static string GetShareContent(JokePostInfo jokeinfo)
        {
            string content = "超级冷笑话";
            if(jokeinfo.JokeType==0)
            {
                content = jokeinfo.Content.Replace("'","\"");
            }
            else
            {
                content = ConfigurationManager.AppSettings["SiteDescription"];
            }
            return content;
        }

        public static string GetShareImg(JokePostInfo jokeinfo)
        {
            if(AppConfig.IsQiniuUpload>0)
            {
                return string.Format("{0}/{1}", QiniuUpload.QiniuCloudUrl, jokeinfo.JokeType == 1 ? FileInfoHelper.GetFileName(jokeinfo.Content) : "shareimg.png");
            }
            else
            {
               return string.Format("{0}", jokeinfo.JokeType == 1 ? string.Format("{0}//{1}",AppConfig.JokeImgUpload,jokeinfo.Content) : "/imgs/shareimg.png");
            }
        }

        public static string RemoveHtml(string content)
        {
            return Sanitizer.GetSafeHtmlFragment(content);
        }
    }
}