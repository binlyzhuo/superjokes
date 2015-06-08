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
    }
}
