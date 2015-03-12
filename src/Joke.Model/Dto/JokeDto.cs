using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke.Model.Dto
{
    public class JokeDto
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
        /// 标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get;
            set;
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type
        {
            get;
            set;
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int State
        {
            get;
            set;
        }
        /// <summary>
        /// 审核人id
        /// </summary>
        public int CheckUserId
        {
            get;
            set;
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AddDate
        {
            get;
            set;
        }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime CheckDate
        {
            get;
            set;
        }
        /// <summary>
        /// 点赞次数
        /// </summary>
        public int LikeCount
        {
            get;
            set;
        }
        /// <summary>
        /// 踩次数
        /// </summary>
        public int HateCount
        {
            get;
            set;
        }
        /// <summary>
        /// 发布人id
        /// </summary>
        public int PostID
        {
            get;
            set;
        }
        /// <summary>
        /// 评论次数
        /// </summary>
        public int CommentCount
        {
            get;
            set;
        }
        /// <summary>
        /// 笑话分类
        /// </summary>
        public int Category
        {
            get;
            set;
        }
    }
}
