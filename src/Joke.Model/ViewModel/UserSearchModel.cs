using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.ViewModel
{
    public class UserSearchModel:BaseSearchModel
    {
        public int UserID { set; get; }
        public string UserName { set; get; }

        public int? State { set; get; }
    }
}
