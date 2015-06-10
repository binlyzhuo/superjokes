using Joke.Data;
using Joke.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
