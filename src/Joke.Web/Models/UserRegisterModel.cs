using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Joke.Web.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string UserName { set; get; }

        [Required]
        public string Email { set; get; }

        [Required]
        public string Password { set; get; }

        [Required]
        public string RepeatPwd { set; get; }

        [Required]
        public string VerifyCode { set; get; }
    }
}