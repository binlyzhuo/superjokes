﻿using CodeScales.Http;
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
            HttpPost postMethod = new HttpPost(new Uri("http://sendcloud.sohu.com/webapi/mail.send_template.json"));
            MultipartEntity multipartEntity = new MultipartEntity();
            postMethod.Entity = multipartEntity;
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "template_invoke_name", "superjokes_register"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "substitution_vars", "{\"to\": [\"" + email + "\"], \"sub\" : { \"%username%\" : [\"" + userName + "\"]}}"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_user", "superjokes_cn"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_key", "XueQ6S20K8v4BTdg"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "from", "service@superjokes.cn"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "fromname", "超级冷笑话"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "subject", "超级冷笑话注册邮件"));
            CodeScales.Http.Methods.HttpResponse response = client.Execute(postMethod);

            var repCode = response.ResponseCode;
            var repResult = EntityUtils.ToString(response.Entity);

            //Console.WriteLine("Response Code: " + response.ResponseCode);
            //Console.WriteLine("Response Content: " + EntityUtils.ToString(response.Entity));

            //Response.Write("Response Code: " + response.ResponseCode);
            //Response.Write("<br/>");
            //Response.Write("Response Content: " + EntityUtils.ToString(response.Entity));
        }

        public static void VerifyNotice(string userName,string email,string jokeTitle,int jokeId)
        {
            HttpClient client = new HttpClient();
            HttpPost postMethod = new HttpPost(new Uri("http://sendcloud.sohu.com/webapi/mail.send_template.json"));
            MultipartEntity multipartEntity = new MultipartEntity();
            postMethod.Entity = multipartEntity;
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "template_invoke_name", "superjokes_verifynotice"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "substitution_vars", "{\"to\": [\"" + email + "\"], \"sub\" : { \"%username%\" : [\"" + userName + "\"],\"joketitle\":[\""+jokeTitle+"\"],\"jokeid\":[\""+jokeId+"\"]}}"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_user", "superjokes_cn"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_key", "XueQ6S20K8v4BTdg"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "from", "service@superjokes.cn"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "fromname", "超级冷笑话"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "subject", "超级冷笑话审核通知"));
            CodeScales.Http.Methods.HttpResponse response = client.Execute(postMethod);

            var repCode = response.ResponseCode;
            var repResult = EntityUtils.ToString(response.Entity);

        }

        public static void GetPassword(string userName,string email,string url)
        {
            HttpClient client = new HttpClient();
            HttpPost postMethod = new HttpPost(new Uri("http://sendcloud.sohu.com/webapi/mail.send_template.json"));
            MultipartEntity multipartEntity = new MultipartEntity();
            postMethod.Entity = multipartEntity;
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "template_invoke_name", "superjokes_verifynotice"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "substitution_vars", "{\"to\": [\"" + email + "\"], \"sub\" : { \"%username%\" : [\"" + userName + "\"],\"joketitle\":[\"" + url + "\"]}}"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_user", "superjokes_cn"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_key", "XueQ6S20K8v4BTdg"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "from", "service@superjokes.cn"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "fromname", "超级冷笑话"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "subject", "超级冷笑话审核通知"));
            CodeScales.Http.Methods.HttpResponse response = client.Execute(postMethod);

            var repCode = response.ResponseCode;
            var repResult = EntityUtils.ToString(response.Entity);
        }
    }
}