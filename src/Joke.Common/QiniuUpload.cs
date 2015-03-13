using Qiniu.IO;
using Qiniu.RS;
using Qiniu.RSF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Travelling.Web.Helpers
{
    public class QiniuUpload
    {
        public static bool PutFile(string key, string fname)
        {
            var policy = new PutPolicy(bucket, 3600);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();
            var putFile = client.PutFile(upToken, key, fname, extra);
            return putFile.OK;
        }

        public static DumpRet GetUEditorFileUploadToday()
        {
            var policy = new PutPolicy(bucket, 3600);
            RSFClient client = new RSFClient(bucket);

            var picColl = client.ListPrefix(bucket, "", "");
            return picColl;
        }

        private readonly static string bucket;
        //private readonly static string ueditImgPrefix;
        private readonly static string cloudUrl;
        
        static QiniuUpload()
        {
            bucket = ConfigurationManager.AppSettings["QiniuBucket"];
            //ueditImgPrefix = string.Format("article{0}", DateTime.Now.ToString("yyyyMMdd"));
            cloudUrl = ConfigurationManager.AppSettings["QiniuCloudUrl"];
        }

        //public static string GetUEditorUploadImgName(string ext)
        //{
        //    return string.Format("{0}{1}.{2}", ueditImgPrefix, DateTime.Now.ToString("yyyyMMddHHmmssfff"), ext);
        //}

        public static string QiniuCloudUrl
        {
            get
            {
                return cloudUrl;
            }
        }

        public static void Config()
        {
            Qiniu.Conf.Config.ACCESS_KEY = ConfigurationManager.AppSettings["ACCESS_KEY"];
            Qiniu.Conf.Config.SECRET_KEY = ConfigurationManager.AppSettings["SECRET_KEY"];
            Qiniu.Conf.Config.UP_HOST = ConfigurationManager.AppSettings["UP_HOST"];
            Qiniu.Conf.Config.USER_AGENT = ConfigurationManager.AppSettings["USER_AGENT"];
            Qiniu.Conf.Config.API_HOST = ConfigurationManager.AppSettings["API_HOST"];
            Qiniu.Conf.Config.RSF_HOST = ConfigurationManager.AppSettings["RSF_HOST"];
            Qiniu.Conf.Config.PREFETCH_HOST = ConfigurationManager.AppSettings["PREFETCH_HOST"];
        }
    }
}
