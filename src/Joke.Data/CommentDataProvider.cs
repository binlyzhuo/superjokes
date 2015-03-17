using Joke.Model.Domain;
using Joke.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Data
{
    public class CommentDataProvider:BaseData<T_Comment>
    {
        public CommentDataProvider()
        {

        }

        public List<CommentViewInfo> CommentSearchResult(CommentSearchModel search)
        {
            string sql = string.Format(@"select cm.JokeId,cm.ID as CommentId,cm.Content as Comment,cm.UserID,us.UserName,cm.Floor from T_Comment cm
                            inner join T_Joke jk on cm.JokeId = jk.ID
                            inner join T_User us on us.id=cm.UserID where cm.JokeId={0}",search.JokeID);

            var items = jokeDatabase.Fetch<CommentViewInfo>(sql);
            return items;
        }
    }
}
