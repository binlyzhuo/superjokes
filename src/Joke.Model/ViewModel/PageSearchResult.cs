using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class PageSearchResult<T>
        where T:class
    {
        public List<T> Items { set; get; }
        public int TotalCount { set; get; }
        public int PageSize { set; get; }
        public int Page { set; get; }

        public string Data { set; get; }
        public string Data1 { set; get; }

        public int TotalPages
        {
            get
            {
                return this.TotalCount % this.PageSize == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1;
            }
        }
    }
}
