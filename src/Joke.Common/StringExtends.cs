using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Joke.Common
{
    public static class StringExtends
    {
        /// <summary>
        /// 转成Int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt32(this string str)
        {
            int num = 0;
            if (int.TryParse(str, out num))
            {
                return num;
            }
            return num;
        }

        /// <summary>
        /// 转成Decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str)
        {
            return Convert.ToDecimal(str);
        }

        /// <summary>
        /// 转成Float
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float ToFloat(this string str)
        {
            float d = 0;
            float.TryParse(str, out d);
            return d;

        }

        /// <summary>
        /// 默认时间1900-1-1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            DateTime dt = DateTime.Parse("1900-1-1");
            if (DateTime.TryParse(str, out dt))
            {
                return dt;
            }
            else
            {
                return DateTime.Parse("1900-1-1");
            }

        }

        /// <summary>
        /// 转Xml
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static XmlDocument ToXml(this string str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            return xmlDoc;
        }

        public static string SubString(this string str,int len)
        {
            return str.Length>len?str.Substring(0,len)+"...":str;
        }
    }
}
