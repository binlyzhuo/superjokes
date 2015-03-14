using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Domain
{
    /// <summary>
    /// 系统配置
    /// </summary>
    [Serializable]
    public partial class T_AppConfig
    {
        public T_AppConfig()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _value;
        private DateTime _adddate = DateTime.Now;
        private DateTime _updatedate = Convert.ToDateTime("1900-1-1");
        private int _updateuserid;
        /// <summary>
        /// 系统配置
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value
        {
            set { _value = value; }
            get { return _value; }
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
        /// 上次修改时间
        /// </summary>
        public DateTime UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 修改人id
        /// </summary>
        public int UpdateUserId
        {
            set { _updateuserid = value; }
            get { return _updateuserid; }
        }
        #endregion Model

    }
}
