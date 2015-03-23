using SuperJokes.Mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperJokes.Mobile
{
    public class FilterConfig
    {
        /// <summary>
        /// 注册过滤器
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GZipCompressAttribute());
        }
    }
}