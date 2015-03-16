using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeSpider
{
    public class SpiderRule
    {
        public string Name { set; get; }
        public string Url { set; get; }

        public string ListRule { set; get; }

        public string TitleRule { set; get; }
        public string ContentRule { set; get; }
    }
}
