using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class CommentPostModel
    {
        
        public int JokeID { set; get; }

        [Required]
        public string Comment { set; get; }

        [Required]
        public string VerifyCode { set; get; }
    }
}
