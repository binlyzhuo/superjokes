using Joke.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Joke.Data
{
    public class GetPwdDataProvider : BaseData<T_GetPwd>
    {
        public GetPwdDataProvider()
        {

        }

        public T_GetPwd GetPwdRecord(int userid)
        {
            Sql where = Sql.Builder.Where("userid=@0 and ExpireDate>=getdate() and State=1",userid);
            var item = this.jokeDatabase.SingleOrDefault<T_GetPwd>(where);
            return item;
        }

        public T_GetPwd GetPwdRecord(string guid)
        {
            Sql where = Sql.Builder.Where("Guid=@0 and ExpireDate>=getdate() and State=1", guid);
            var item = this.jokeDatabase.SingleOrDefault<T_GetPwd>(where);
            return item;
        }
    }
}
