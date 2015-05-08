using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Joke.Common;

namespace Joke.Web.Helpers
{
    public class AppConfig
    {
        public static readonly int IsQiniuUpload;
        public static readonly string QiniuCloudUrl;
        public static readonly string JokeImgUpload;
        public static readonly int IsEnableComment;
        public static readonly string HotCategories;
        static AppConfig()
        {
            IsQiniuUpload = ConfigurationManager.AppSettings["IsQiniuUpload"].ToInt32();
            QiniuCloudUrl = ConfigurationManager.AppSettings["QiniuCloudUrl"];
            JokeImgUpload = ConfigurationManager.AppSettings["JokeImgUpload"];
            IsEnableComment = ConfigurationManager.AppSettings["IsEnableComment"].ToInt32();
            HotCategories = ConfigurationManager.AppSettings["HotCategories"];
        }
    }
}