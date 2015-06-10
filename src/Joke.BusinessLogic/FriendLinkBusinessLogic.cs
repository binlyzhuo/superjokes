using Joke.Data;
using Joke.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using Joke.Model.ViewModel;

namespace Joke.BusinessLogic
{
    public class FriendLinkBusinessLogic : BaseLogic
    {
        private FriendLinkDataProvider friendLinkData = new FriendLinkDataProvider();
        public FriendLinkBusinessLogic()
        {

        }

        public bool AddFriendLink(T_FriendLink link)
        {
            return friendLinkData.Add(link)>0;
        }

        public bool DeleteFriendLink(int linkId)
        {
            return friendLinkData.Delete(linkId);
        }

        public bool UpdateFriendLink(T_FriendLink link)
        {
            return friendLinkData.Update(link);
        }

        public T_FriendLink GetFriendLink(int id)
        {
            return friendLinkData.SingleOrDefault(id);
        }

        public Page<T_FriendLink> FriendLinkSearch(FriendLinkSearch search)
        {
            return friendLinkData.SearchResult(search);
        }

        public List<T_FriendLink> GetFriendLinks()
        {

            return friendLinkData.GetFriendLinks();
        }
    }
}
