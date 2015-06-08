using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joke.Web.Models
{
    public class JsonViewResult
    {
        public bool Success { set; get; }
        public string Message { set; get; }

        public int Status { set; get; }
    }
}