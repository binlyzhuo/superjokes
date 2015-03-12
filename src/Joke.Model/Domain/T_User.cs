using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Domain
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Serializable]
    public partial class T_User
    {
        public T_User()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _nikename;
        private string _email;
        private string _password;
        private DateTime _registerdate = DateTime.Now;
        private DateTime _lastlogin = Convert.ToDateTime("1900-01-01");
        private string _photo = "";
        private int _state = 1;
        private int _isadmin = 0;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        ///  用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NikeName
        {
            set { _nikename = value; }
            get { return _nikename; }
        }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLogin
        {
            set { _lastlogin = value; }
            get { return _lastlogin; }
        }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        /// <summary>
        /// 用户状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 是否是管理员
        /// </summary>
        public int IsAdmin
        {
            set { _isadmin = value; }
            get { return _isadmin; }
        }
        #endregion Model

    }
}
