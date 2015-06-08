using Joke.Data;
using Joke.Model.Domain;
using Joke.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Joke.BusinessLogic
{
    public class UserBusinessLogic : BaseLogic
    {
        private readonly UserDataProvider userData;
        private readonly UserLogDataProvider userlogData;
        private readonly GetPwdDataProvider getPwdData;
        public UserBusinessLogic()
        {
            userData = new UserDataProvider();
            userlogData = new UserLogDataProvider();
            getPwdData = new GetPwdDataProvider();
        }

        public int AddUser(T_User user)
        {
            var userinfo = userData.GetUserByUserName(user.UserName);
            if (userinfo != null)
            {
                return 0;
            }
            int userId = userData.Add(user);
            return userId;
        }

        public T_User GetUserInfo(int userid)
        {
            var userinfo = userData.SingleOrDefault(userid);
            return userinfo;
        }

        public T_User GetUserInfo(string userName,string password)
        {
            var userinfo = userData.GetUserInfo(userName,password);
            return userinfo;
        }

        public T_User GetUserInfoByUserName(string userName)
        {
            var userinfo = userData.GetUserByUserName(userName);
            return userinfo;
        }

        public T_User GetUserInfoByEmail(string email)
        {
            var userinfo = userData.GetUserByEmail(email);
            return userinfo;
        }

        public bool UpdateUserPwd(int uid,string password)
        {
            var user = GetUserInfo(uid);
            user.Password = password;
            return userData.Update(user);
        }

        public PageSearchResult<T_User> UserSearch(UserSearchModel search)
        {
            var pageViewResult = userData.UserSearch(search);
            return pageViewResult;
        }

        public bool UpdateUserInfo(T_User userinfo)
        {
            return userData.Update(userinfo);
        }

        public bool DeleteUser(int uid)
        {
            return userData.Delete(uid);
        }

        public void AddUserLog(T_UserLog log)
        {
            userlogData.Add(log);
        }

        public PageSearchResult<T_UserLog> UserLogSearch(UserLogSearchModel search)
        {
            var pageViewResut = userlogData.UserLogSearch(search);
            return pageViewResut;
        }

        public bool AddGetPwdRecord(T_GetPwd getpwd)
        {
            return getPwdData.Add(getpwd)>0;
        }

        public T_GetPwd GetPwdRecord(int userid)
        {
            return getPwdData.GetPwdRecord(userid);
        }

        public T_GetPwd GetPwdRecord(string guid)
        {
            return getPwdData.GetPwdRecord(guid);
        }
    }
}
