using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Joke.BusinessLogic;
using Joke.Common;
using Joke.Web.Auth;
using Newtonsoft.Json;
using Joke.Web.App_Start;
using StackExchange.Profiling;
using Travelling.Web.Helpers;
using System.Web.Optimization;

namespace Joke.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            //AreaRegistration.RegisterAllAreas();
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LogHelper.LogConfig(Server.MapPath(@"~\App_Data\log4net.config"));
            DtoMapper.AutoMapper();

            QiniuUpload.Config();
        }

        /// <summary>
        /// 系统请求事件
        /// </summary>
        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                StackExchange.Profiling.MiniProfiler.Start();
            }
        }

        protected void Application_AuthenticateRequest(object sender,EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if(authCookie!=null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                UserInfo userinfo = JsonConvert.DeserializeObject<UserInfo>(authTicket.UserData);
                UserInfoPrincipal newUser = new UserInfoPrincipal(userinfo.UserName);
                newUser.UserId = userinfo.UserID;
                newUser.UserName = userinfo.UserName;
                newUser.IsAdmin = userinfo.IsAdmin;

                HttpContext.Current.User = newUser;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

            var ex = Server.GetLastError();
            LogHelper.Error(Utility.GetClientIP());
            LogHelper.Error(ex);
            var httpStatusCode = (ex is HttpException) ? (ex as HttpException).GetHttpCode() : 500;

            switch (httpStatusCode)
            {
                case 404:
                    Response.Redirect("/page404.html");
                    break;
                default:
                    Response.Redirect("/page404.html");
                    break;
            }


        }

        /// <summary>
        /// 系统结束请求事件
        /// </summary>
        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}