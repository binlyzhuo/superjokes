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
    public class CategoryDataProvider : BaseData<T_Category>
    {
        public CategoryDataProvider()
        {

        }

        public List<T_Category> CategoryGet()
        {
            Sql where = Sql.Builder.Where("State=1");
            var items = jokeDatabase.Fetch<T_Category>(where);
            return items;
        }

        public List<CategorySummaryInfo> CategorySummaryInfo()
        {
            string sql = @"select count(j.ID) as JokeCount,g.Name as CategoryName,g.PinYin,g.ID as CategoryId from T_Category g
                            left join T_Joke j on g.ID = j.Category and j.State=1
                            group by g.ID,j.Category,g.Name,g.PinYin
                            order by JokeCount desc";

            var items = this.jokeDatabase.Fetch<CategorySummaryInfo>(sql);
            return items;
        }

        public T_Category CategoryGet(string pinyin)
        {
            Sql where = Sql.Builder.Where("pinyin=@0",pinyin);
            var item = this.jokeDatabase.SingleOrDefault<T_Category>(where);
            return item;
        }
    }
}
