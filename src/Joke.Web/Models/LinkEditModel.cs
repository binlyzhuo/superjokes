using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Joke.Web.Models
{
    public class LinkEditModel
    {
        [Required(ErrorMessage="必填")]
        public string SiteName { set; get; }

        [Required(ErrorMessage = "必填")]
        public string LinkUrl { set; get; }

        [Required(ErrorMessage = "必填")]
        public string LinkMan { set; get; }

        [Required(ErrorMessage = "必填")]
        public string KeyWords { set; get; }

        public int ID { set; get; }

    }
}