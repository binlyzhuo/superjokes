using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class UserJokesSearchModel:BaseSearchModel
    {
        public int? UserId { set; get; }
        public int? JokeType { set; get; }

        public int? JokeState { set; get; }
    }
}
