using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class CommentSearchModel:BaseSearchModel
    {
        public int UserID { set; get; }
        public int JokeID { set; get; }
    }
}
