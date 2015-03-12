using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Joke.Web.Models
{
    public class UserUpdatePwdModel
    {
        [Required]
        public string OldPwd { set; get; }

        [Required]
        public string Password { set; get; }

        [Required]
        public string ConfirmPwd { set; get; }
    }
}