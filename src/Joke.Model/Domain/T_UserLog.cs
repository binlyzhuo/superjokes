using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Domain
{
    /// <summary>
    /// 用户操作日志
    /// </summary>
    [Serializable]
    public partial class T_UserLog
    {
        public T_UserLog()
        { }
        #region Model
        private int _id;
        private int _userid = 0;
        private string _username = "";
        private DateTime _adddate = DateTime.Now;
        private string _content = "";
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 操作备注
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        #endregion Model

    }
}
