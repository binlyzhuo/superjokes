using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Domain
{
    /// <summary>
    /// 文章信息
    /// </summary>
    [Serializable]
    public partial class T_Article
    {
        public T_Article()
        { }
        #region Model
        private int _id;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        #endregion Model

    }
}
