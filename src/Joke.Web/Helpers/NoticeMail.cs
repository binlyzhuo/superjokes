using CodeScales.Http;
using CodeScales.Http.Entity;
using CodeScales.Http.Entity.Mime;
using CodeScales.Http.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Joke.Web.Helpers
{
    public class NoticeMail
    {
        public static void SendWelcomeMail(string userName,string email)
        {
            HttpClient client = new HttpClient();
            HttpPost postMethod = new HttpPost(new Uri("http://sendcloud.sohu.com/webapi/mail.send_template.xml"));
            MultipartEntity multipartEntity = new MultipartEntity();
            postMethod.Entity = multipartEntity;
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "template_invoke_name", "superjokes_register"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "substitution_vars", "{\"to\": [\"" + email + "\"], \"sub\" : { \"%username%\" : [\"" + userName + "\"]}}"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_user", "super"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_key", "XueQ6S20K8v4BTdg"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "from", "welcome@superjokes.cn"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "fromname", "超级冷笑话"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "subject", "超级冷笑话注册邮件"));
            CodeScales.Http.Methods.HttpResponse response = client.Execute(postMethod);

            var repCode = response.ResponseCode;

            //Console.WriteLine("Response Code: " + response.ResponseCode);
            //Console.WriteLine("Response Content: " + EntityUtils.ToString(response.Entity));

            //Response.Write("Response Code: " + response.ResponseCode);
            //Response.Write("<br/>");
            //Response.Write("Response Content: " + EntityUtils.ToString(response.Entity));
        }

        public static void VerifyNotice()
        {

        }

        public static void GetPassword()
        {

        }
    }
}