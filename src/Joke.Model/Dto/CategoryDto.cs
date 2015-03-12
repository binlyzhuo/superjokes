using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Dto
{
    public class CategoryDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get;
            set;
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            get;
            set;
        }

        public string PinYin
        {
            get;
            set;
        }
    }
}
