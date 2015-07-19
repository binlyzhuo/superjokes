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
        private string _title = "";
        private string _keywords = "";
        private string _content = "";
        private int _userid = 0;
        private DateTime _adddate = DateTime.Now;
        private int _category = 0;
        private int _readcount;
        private int _state = 1;
        private int _linkcount;
        private int _hatecount = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        ///  标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 添加人UserID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
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
        /// 类别
        /// </summary>
        public int Category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ReadCount
        {
            set { _readcount = value; }
            get { return _readcount; }
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 点赞次数
        /// </summary>
        public int LinkCount
        {
            set { _linkcount = value; }
            get { return _linkcount; }
        }
        /// <summary>
        /// 踩次数
        /// </summary>
        public int HateCount
        {
            set { _hatecount = value; }
            get { return _hatecount; }
        }
        #endregion Model

    }
}
