using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Joke.Model.Domain
{
    /// <summary>
    /// 分类
    /// </summary>
    [Serializable]
    [PrimaryKey("ID", AutoIncrement = false)]
    public partial class T_Category
    {
        public T_Category()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private DateTime _adddate = DateTime.Now;
        private int _state = 1;
        private string _pinyin = "";
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        /// 有效状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 分类拼音
        /// </summary>
        public string PinYin
        {
            set { _pinyin = value; }
            get { return _pinyin; }
        }
        #endregion Model

    }
}
