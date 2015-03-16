using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Joke.Common;

namespace JokeSpider
{
    public class AppConfig
    {
        public readonly static int UserID;
        public readonly static int Category;
        static AppConfig()
        {
            UserID = ConfigurationManager.AppSettings["UserID"].ToInt32();
            Category = ConfigurationManager.AppSettings["UserID"].ToInt32();
        }
    }
}
