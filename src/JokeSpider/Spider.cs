using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;

namespace JokeSpider
{
    public class Spider
    {
        public static string GetHtmlContent(string url, string encoding = "utf-8")
        {
            string strMsg = "";
            try
            {

                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
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
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("Config\\spiderrules.xml");
            var ruleNodes = xmldoc.SelectNodes("rules/rule");
            SpiderRule rule;
            List<SpiderRule> rules = new List<SpiderRule>();
            foreach(XmlNode n in ruleNodes)
            {
                rule = new SpiderRule();
                rule.Name = n.SelectSingleNode("name").InnerText;
                rule.TitleRule = n.SelectSingleNode("titlerule").InnerText;
                rule.ListRule = n.SelectSingleNode("listrule").InnerText;
                rule.Url = n.SelectSingleNode("url").InnerText;
                rule.ContentRule = n.SelectSingleNode("contentrule").InnerText;
                rule.Encoding = n.SelectSingleNode("encoding").InnerText;
                rules.Add(rule);
            }
            return rules;
        }

        public static SpiderRule GetRuleByName(string name)
        {
            var rule = GetRules().SingleOrDefault(u => u.Name == name);
            return rule;
        }
    }
}
