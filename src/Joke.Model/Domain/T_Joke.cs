using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Domain
{
    /// <summary>
    /// 笑话信息
    /// </summary>
    [Serializable]
    public partial class T_Joke
    {
        public T_Joke()
        { }
        #region Model
        private int _id;
        private string _title = "";
        private string _content = "0";
        private int _type;
        private int _state = 0;
        private int _checkuserid = 0;
        private DateTime _adddate = DateTime.Now;
        private DateTime _checkdate = Convert.ToDateTime("1900-1-1");
        private int _likecount = 0;
        private int _hatecount = 0;
        private int _postid = 0;
        private int _commentcount = 0;
        private int _category = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
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
        /// 类型
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 审核人id
        /// </summary>
        public int CheckUserId
        {
            set { _checkuserid = value; }
            get { return _checkuserid; }
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime CheckDate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
        }
        /// <summary>
        /// 点赞次数
        /// </summary>
        public int LikeCount
        {
            set { _likecount = value; }
            get { return _likecount; }
        }
        /// <summary>
        /// 踩次数
        /// </summary>
        public int HateCount
        {
            set { _hatecount = value; }
            get { return _hatecount; }
        }
        /// <summary>
        /// 发布人id
        /// </summary>
        public int PostID
        {
            set { _postid = value; }
            get { return _postid; }
        }
        /// <summary>
        /// 评论次数
        /// </summary>
        public int CommentCount
        {
            set { _commentcount = value; }
            get { return _commentcount; }
        }
        /// <summary>
        /// 笑话分类
        /// </summary>
        public int Category
        {
            set { _category = value; }
            get { return _category; }
        }
        #endregion Model

    }
}
