using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Joke.Common
{
    public class LogHelper
    {
        private static readonly ILog logerror = LogManager.GetLogger("logerror");
        private static readonly ILog logdebug = LogManager.GetLogger("logdebug");
        private static readonly ILog loginfo = LogManager.GetLogger("loginfo");

        /// <summary>
        /// 加载配置文件
        /// </summary>
        public static void LogConfig(string fileName)
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(fileName));
        }

        public static void Error(string errorMessage, Exception ex)
        {
            logerror.Error(errorMessage, ex);
        }

        public static void Error(string errorMessage)
        {
            logerror.Error(errorMessage);
        }

        public static void Error(Exception ex)
        {
            logerror.Error(ex);
        }

        public static void Info(string info)
        {
            loginfo.Info(info);
        }

        public static void Debug(string debug)
        {
            logdebug.Debug(debug);
        }
    }
}
