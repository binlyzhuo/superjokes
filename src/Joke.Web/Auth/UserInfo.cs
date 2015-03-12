using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joke.Web.Auth
{
    public class UserInfo
    {
        private int userId;
        private string userName;
        private int isAdmin;

        public UserInfo(int userid, string userName, int isAdmin)
        {
            this.userId = userid;
            this.userName = userName;
            this.isAdmin = isAdmin;
        }


        public int UserID
        {
            get
            {
                return this.userId;
            }
        }
        public string UserName
        {
            get
            {
                return this.userName;
            }
        }
        public int IsAdmin
        {
            get
            {
                return this.isAdmin;
            }
        }
    }
}