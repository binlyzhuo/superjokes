using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Domain
{
    /// <summary>
    /// 友情链接
    /// </summary>
    [Serializable]
    public partial class T_FriendLink
    {
        public T_FriendLink()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private string _linkurl;
        private string _linkman = "";
        private int _state = 1;
        private DateTime _adddate = DateTime.Now;
        private int _adduserid = 0;
        private string _remark = "";
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 链接
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
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
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }


        /// <summary>
        /// 添加人id
        /// </summary>
        public int AddUserID
        {
            set { _adduserid = value; }
            get { return _adduserid; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

