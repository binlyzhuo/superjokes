using HtmlAgilityPack;
using Joke.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JokeSpider
{
    public partial class mainForm : Form
    {
        JokeBusinessLogic jokeLogic = new JokeBusinessLogic();
        public mainForm()
        {
            
            InitializeComponent();
            txtRequestUrl.Text = "http://www.mahua.com/";
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            btnRequest.Enabled = false;
            List<JokeInfo> jokes = new List<JokeInfo>();
            var content = Spider.GetHtmlContent(txtRequestUrl.Text);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            string jokelistXPath = "//html[1]/body[1]/div[2]/div[1]/dl";
            var nodes = doc.DocumentNode.SelectNodes(jokelistXPath);
            JokeInfo jokeinfo;
            HtmlNode temp;
            foreach(var node in nodes)
            {
                temp = HtmlNode.CreateNode(node.OuterHtml);
                jokeinfo = new JokeInfo();
                jokeinfo.Title = temp.SelectSingleNode("//dt[1]//span[1]//a[1]").InnerText.Trim();
                jokeinfo.Content = temp.SelectSingleNode("//dd[1]").InnerText.Trim();
                if(string.IsNullOrEmpty(jokeinfo.Content)||string.IsNullOrEmpty(jokeinfo.Title))
                {
                    continue;
                }
                jokes.Add(jokeinfo);
            }

            int jokeCount = jokes.Count;
            //jokeLogic.AddJokes();
        }
    }
}
