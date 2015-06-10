using Joke.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using Joke.Model.ViewModel;

namespace Joke.Data
{
    public class FriendLinkDataProvider:BaseData<T_FriendLink>
    {
        public FriendLinkDataProvider()
        {

        }

        public Page<T_FriendLink> SearchResult(FriendLinkSearch search)
        {
            Sql where = Sql.Builder.Where("1=1").OrderBy("ID Desc");
            var pageResult = this.jokeDatabase.Page<T_FriendLink>(search.Page, search.PageSize, where);
            return pageResult;
        }

        public List<T_FriendLink> GetFriendLinks()
        {
            Sql where = Sql.Builder.Where("1=1").OrderBy("ID Asc");
            var items = this.jokeDatabase.Fetch<T_FriendLink>(where);
            return items;
        }
    }
}
