using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class JokeCategoryJokesModel
    {
        public int CategoryID { set; get; }
        public string CategoryName { set; get; }

        public string PinYin { set; get; }

        public List<JokePrimaryInfo> JokeInfos { set; get; }
        public int TotalCount { set; get; }
    }
}
