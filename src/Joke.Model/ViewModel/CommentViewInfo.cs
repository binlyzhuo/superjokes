using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class CommentViewInfo
    {
        public int JokeId { set; get; }
        public int CommentId { set; get; }
        public string Comment { get; set; }
        public int UsrId { set; get; }
        public string UserName { set; get; }
        public int Floor { set; get; }
    }
}
