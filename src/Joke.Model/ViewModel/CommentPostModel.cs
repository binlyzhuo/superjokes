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
        [StringLength(500)]
        public string Comment { set; get; }

        [Required]
        [StringLength(5)]
        public string VerifyCode { set; get; }
    }
}
