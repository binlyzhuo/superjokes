using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class JokePrimaryInfo
    {
        public int JokeId { set; get; }
        public string Title { set; get; }
        public string CategoryId { set; get; }
        public string CategoryName { set; get; }
        public string PinYin { set; get; }
        public string Content { set; get; }
        public DateTime AddDate { set; get; }
    }
}
