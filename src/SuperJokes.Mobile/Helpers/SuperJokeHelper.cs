using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperJokes.Mobile.Helpers
{
    public class SuperJokeHelper
    {
        public static string GetCategoryJokes(string pinyin)
        {
            return string.Format("/{0}.html", pinyin.ToLower());
        }

        public static string GetJokeDetail(int jokeid)
        {
            return string.Format("/joke{0}.html", jokeid);
        }

        public static string GetPageLink(string flag,int page)
        {
            return string.Format("/{0}/{1}.html",flag,page);
        }
    }
}