using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace JokeSpider
{
    public class Spider
    {
        public static string GetHtmlContent(string url)
        {
            string strMsg = "";
            try
            {

                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.GetEncoding("utf-8"));
                strMsg = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();
                return strMsg;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public static List<SpiderRule> GetRules()
        {
            return null;
        }
    }
}
