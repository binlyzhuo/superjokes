using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class JokeSearchModel : BaseSearchModel
    {
        public int PostUserId = 0;
        public string CategoryPinyin = "";
        public JokeSearchType SearchType = JokeSearchType.Latest;
    }
}
