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

        public static string RemoveHtml(string source)
        {
            string stroutput = source;
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>");
            stroutput = regex.Replace(stroutput, "");
            return stroutput;
        }

        public static string RemoveHtmlTags(string source)
        {
            if (source == null)
            {
                throw new Exception("Your input html stream is null!");
            }

            /*
             * 最好把所有的特殊HTML标记都找出来，然后把与其相对应的Unicode字符一起影射到Hash表内，最后一起都替换掉
             */

            //先单独测试,成功后,再把所有模式合并

            //注:这两个必须单独处理
            //去掉嵌套了HTML标记的JavaScript:(<script)[\\s\\S]*(</script>)
            //去掉css标记:(<style)[\\s\\S]*(</style>)
            //去掉css标记:\\..*\\{[\\s\\S]*\\}
            source = Regex.Replace(source, "(<script)[\\s\\S]*?(</script>)|(<style)[\\s\\S]*?(</style>)", " ", RegexOptions.IgnoreCase);
            //htmlStream = RemoveTag(htmlStream, "script");
            //htmlStream = RemoveTag(htmlStream, "style");

            //去掉普通HTML标记:<[^>]+>
            //替换空格:&nbsp;|&amp;|&shy;|&#160;|&#173;
            source = Regex.Replace(source, "<[^>]+>|&nbsp;|&amp;|&shy;|&#160;|&#173;|&bull;|&lt;|&gt;", " ", RegexOptions.IgnoreCase);
            //htmlStream = RemoveTag(htmlStream);

            //替换左尖括号
            //htmlStream = Regex.Replace(htmlStream, "&lt;", "<");

            //替换右尖括号
            //htmlStream = Regex.Replace(htmlStream, "&gt;", ">");

            //替换空行
            //htmlStream = Regex.Replace(htmlStream, "[\n|\r|\t]", " ");//[\n|\r][\t*| *]*[\n|\r]
            source = Regex.Replace(source, "(\r\n[\r|\n|\t| ]*\r\n)|(\n[\r|\n|\t| ]*\n)", "\r\n");
            source = Regex.Replace(source, "[\t| ]{1,}", " ");

            return source.Trim();
        }
    }
}
