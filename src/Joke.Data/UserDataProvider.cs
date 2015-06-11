using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joke.Model.Domain;
using Joke.Model.ViewModel;
using NPoco;

namespace Joke.Data
{
    public class UserDataProvider:BaseData<T_User>
    {
        public UserDataProvider()
        {

        }

        public T_User GetUserByUserName(string userName)
        {
            Sql where = Sql.Builder.Where("UserName=@0",userName);
            var userinfo = this.jokeDatabase.SingleOrDefault<T_User>(where);
            return userinfo;
        }

        public T_User GetUserByEmail(string email)
        {
            Sql where = Sql.Builder.Where("Email=@0", email);
            var userinfo = this.jokeDatabase.SingleOrDefault<T_User>(where);
            return userinfo;
        }

        public T_User GetUserInfo(string userName,string password)
        {
            Sql where = Sql.Builder.Where("UserName=@0 and Password=@1",userName,password);
            var userinfo = this.jokeDatabase.SingleOrDefault<T_User>(where);
            return userinfo;
        }

        public PageSearchResult<T_User> UserSearch(UserSearchModel search)
        {
            Sql where = Sql.Builder.Where("1=1").OrderBy("ID DESC");
            if(search.UserID>0)
            {
                where.Append("ID=@0",search.UserID);
            }

            var pageResult = this.jokeDatabase.Page<T_User>(search.Page,search.PageSize,where);
            PageSearchResult<T_User> pageViewResult = new PageSearchResult<T_User>() {
                Items = pageResult.Items,
                 Page = (int)pageResult.CurrentPage,
                  PageSize = (int)pageResult.ItemsPerPage, TotalCount = (int)pageResult.TotalItems
            };
            return pageViewResult;
        }
    }
}
