using Joke.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Joke.Web.Auth
{
    public class UserInfoPrincipal : IPrincipal
    {
        private UserInfoIdentity identity;
        public UserInfoPrincipal(string userName)
        {
            UserBusinessLogic userLogic = new UserBusinessLogic();
            var user = userLogic.GetUserInfoByUserName(userName);
            this.identity = new UserInfoIdentity(user.ID, user.UserName, user.IsAdmin);

        }

        public int UserId { set; get; }
        public string UserName { set; get; }
        public int IsAdmin { set; get; }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public bool IsInRole(string role)
        {
            if (this.IsAdmin == 1 && role.ToLower() == "admin")
            { 
                return true; 
            }
            if (this.IsAdmin == 0 && role.ToLower() == "user")
            {
                return true;
            }
            return false;
        }
    }
}