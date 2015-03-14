using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Domain
{
    /// <summary>
    /// 评论信息
    /// </summary>
    [Serializable]
    public partial class T_Comment
    {
        public T_Comment()
        { }
        #region Model
        private int _id;
        private int _jokeid;
        private string _content = "";
        private DateTime _adddate = DateTime.Now;
        private int _userid = 0;
        private int _floor = 1;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int JokeId
        {
            set { _jokeid = value; }
            get { return _jokeid; }
        }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
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
        /// 发表人id
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 楼层
        /// </summary>
        public int Floor
        {
            set { _floor = value; }
            get { return _floor; }
        }
        #endregion Model

    }
}
