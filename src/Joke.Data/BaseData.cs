using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Joke.Data
{
    public class BaseData<T>
        where T:class
    {
        protected Database jokeDatabase;
        public BaseData()
        {
            this.jokeDatabase = new Database("Joke");
        }

        public void BulkInsert(List<T> items)
        {
            this.jokeDatabase.InsertBulk<T>(items);
        }

        public int Add(T item)
        {
           int id=Convert.ToInt32(this.jokeDatabase.Insert<T>(item));
           return id;
        }

        public int Count()
        {
            string sql = string.Format("select count(1) from {0} with(nolock)", typeof(T).Name);
            int obj = this.jokeDatabase.ExecuteScalar<int>(sql);
            return obj;
        }

        public virtual int Count(Sql sqlWhere)
        {
            Sql countSql = Sql.Builder.Select("count(1)").From(typeof(T).Name).Append(sqlWhere);
            return jokeDatabase.ExecuteScalar<int>(countSql);
        }

        public T SingleOrDefault(int id)
        {
            return this.jokeDatabase.SingleOrDefaultById<T>(id);
        }

        public bool Update(T item)
        {
            return this.jokeDatabase.Update(item)>0;
        }

        public bool Delete(object id)
        {
            return this.jokeDatabase.Delete<T>(id)>0;
        }


    }
}
