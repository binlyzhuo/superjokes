using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security.Cryptography;
namespace Joke.Common
{
    public class Md5
    {
        public static string GetMd5(string source)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(source, "MD5").ToLower(); 
        }
    }
}
