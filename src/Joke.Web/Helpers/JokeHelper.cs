using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Travelling.Web.Helpers;
using Joke.Common;
using Joke.Model.ViewModel;

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

            return string.Format("{0}/{1}", QiniuUpload.QiniuCloudUrl,FileInfoHelper.GetFileName(imgName));
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
            return string.Format("{0}/{1}", QiniuUpload.QiniuCloudUrl,jokeinfo.JokeType==1?FileInfoHelper.GetFileName(jokeinfo.Content):"shareimg.png");
        }
    }
}