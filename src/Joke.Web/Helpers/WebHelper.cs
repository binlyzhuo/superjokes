using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Joke.Web.Helpers
{
    public static class WebHelper
    {
        public static HtmlString ShowPageNavigate(this HtmlHelper htmlHelper, int currentPage,int totalCount,int totalPages,string link="")
        {
            //var redirectTo = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                output.AppendFormat("<a class='pageLink' href='/{0}/1.html'>首页</a> ", link);
                if (currentPage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='pageLink' href='/{0}/{1}.html'>上一页</a> ", link, currentPage - 1);
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理                           
                            output.AppendFormat("<a class='selectpage' href='/{0}/{1}.html'>{2}</a> ", link, currentPage, currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a class='pageLink' href='/{0}/{1}.html'>{2}</a> ", link, currentPage + i - currint, currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='pageLink' href='/{0}/{1}.html'>下一页</a> ", link, currentPage + 1);
                }

                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='/{0}/{1}.html'>末页</a> ", link, totalPages);
                }
                output.Append(" ");
            }
            output.AppendFormat("<label>第{0}页 / 共{1}页</label>", currentPage, totalPages);//这个统计加不加都行

            return new HtmlString(output.ToString());
        }

        public static HtmlString AjaxPaging(this HtmlHelper htmlHelper, int currentPage, int totalCount, int totalPages, string link = "")
        {
            //var redirectTo = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                output.AppendFormat("<a class='pageLink' href='/{0}/1.html'>首页</a> ", link);
                if (currentPage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='pageLink' href='/{0}/{1}.html'>上一页</a> ", link, currentPage - 1);
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理                           
                            output.AppendFormat("<a class='selectpage' href='/{0}/{1}.html'>{2}</a> ", link, currentPage, currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a class='pageLink' href='/{0}/{1}.html'>{2}</a> ", link, currentPage + i - currint, currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='pageLink' href='/{0}/{1}.html'>下一页</a> ", link, currentPage + 1);
                }

                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='/{0}/{1}.html'>末页</a> ", link, totalPages);
                }
                output.Append(" ");
            }
            output.AppendFormat("<label>第{0}页 / 共{1}页</label>", currentPage, totalPages);//这个统计加不加都行

            return new HtmlString(output.ToString());
        }

    }

    

}