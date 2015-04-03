using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Joke.Common
{
    public class WebCache
    {
        public static void CacheInsert(object data,string cachekey)
        {
            HttpContext.Current.Cache.Insert(cachekey,data);
        }

        public static T GetCacheObject<T>(string cacheKey)
            where T:class
        {
            var data = HttpContext.Current.Cache.Get(cacheKey) as T;
            return data;
        }

        public static void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }
}
