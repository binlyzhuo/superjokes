using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class CategorySummaryInfo
    {
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }
        public string PinYin { set; get; }
        public int JokeCount { set; get; }
    }
}
