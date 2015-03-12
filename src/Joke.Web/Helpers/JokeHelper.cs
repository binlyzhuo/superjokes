using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

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
            return string.Format("{0}/{1}", ConfigurationManager.AppSettings["JokeImgUpload"], imgName);
        }
    }
}