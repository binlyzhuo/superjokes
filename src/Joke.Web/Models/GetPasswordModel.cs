using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Joke.Web.Models
{
    public class GetPasswordModel
    {
        [Required]
        public string Guid { set; get; }

        [Required(ErrorMessage="必填")]
        public string Password { set; get; }

        [Required(ErrorMessage = "必填")]
        public string ConfirmPwd { set; get; }
    }
}