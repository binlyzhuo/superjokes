using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Joke.Web.Models
{
    public class JokeUpdateModel
    {
        [Required]
        public int ID { set; get; }

        [Required]
        public string Title { set; get; }

        [Required]
        public string Content { set; get; }
        public int Type { set; get; }
        public int Category { set; get; }
    }
}