using Joke.Model.Domain;
using Joke.Model.ViewModel;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Data
{
    public class UserLogDataProvider : BaseData<T_UserLog>
    {
        public UserLogDataProvider()
        {

        }

        public PageSearchResult<T_UserLog> UserLogSearch(UserLogSearchModel search)
        {
            Sql where = Sql.Builder.Where("1=1").OrderBy("ID DESC");
            var pageResult = this.jokeDatabase.Page<T_UserLog>(search.Page,search.PageSize,where);
            PageSearchResult<T_UserLog> pageViewResult = new PageSearchResult<T_UserLog>()
            {
                Items = pageResult.Items,
                Page = (int)pageResult.CurrentPage,
                PageSize = (int)pageResult.ItemsPerPage,
                TotalCount = (int)pageResult.TotalItems
            };
            return pageViewResult;
        }
    }
}
