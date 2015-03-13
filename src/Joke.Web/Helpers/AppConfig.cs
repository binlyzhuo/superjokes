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
        static AppConfig()
        {
            IsQiniuUpload = ConfigurationManager.AppSettings["IsQiniuUpload"].ToInt32();
            QiniuCloudUrl = ConfigurationManager.AppSettings["QiniuCloudUrl"];
        }
    }
}