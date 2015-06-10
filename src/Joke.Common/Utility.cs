using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Joke.Common
{
    public class Utility
    {
        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, "[A-Za-z0-9][@][A-Za-z0-9]+[.][A-Za-z0-9]");
        }

        public static string GetClientIP()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];
            else
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; 
        }
    }
}
