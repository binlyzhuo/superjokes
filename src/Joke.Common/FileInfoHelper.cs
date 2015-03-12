using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Common
{
    public class FileInfoHelper
    {
        public static string GetFileName(string fullName)
        {
            var names = fullName.Split('\\');
            var name = names[names.Length - 1];
            return name;
        }

        public static string GetFileExtend(string fileName)
        {
            string ext = fileName.Substring(fileName.LastIndexOf(".")+1, fileName.Length - fileName.LastIndexOf(".")-1);
            return ext;
        }

        public static string GetNewName(string fileName)
        {
            string newName = string.Format("{0}.{1}",DateTime.Now.ToString("yyyyMMddHHmmssfff"),GetFileExtend(fileName));
            return newName;
        }
    }
}
