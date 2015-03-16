using HtmlAgilityPack;
using Joke.BusinessLogic;
using Joke.Model.Domain;
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
    public partial class mainForm : Form, IMessageFilter
    {
        JokeBusinessLogic jokeLogic = new JokeBusinessLogic();
        bool isOk = false;
        public mainForm()
        {

            InitializeComponent();
            Application.AddMessageFilter(this);
            //txtRequestUrl.Text = "http://www.mahua.com/";
            var rules = Spider.GetRules();
            rules.Add(new SpiderRule()
            {
                Name = "--请选择来源--",
                Url = ""
            });
            cboRules.DataSource = rules;
            cboRules.SelectedIndex = rules.Count - 1;
            cboRules.SelectedIndexChanged += cboRules_SelectedIndexChanged;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (!isOk)
            {
                lblMsg.Text = "请填写合法的数据";
                lblMsg.ForeColor = Color.Red;
                return;
            }
            btnRequest.Enabled = false;
            List<JokeInfo> jokes = new List<JokeInfo>();
            var content = Spider.GetHtmlContent(txtRequestUrl.Text);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            string jokelistXPath = txtListRule.Text.Trim();
            var nodes = doc.DocumentNode.SelectNodes(jokelistXPath);
            if(nodes.Count==0)
            {
                lblMsg.Text = "没有抓取到数据，请重新定义规则";
                return;
            }
            JokeInfo jokeinfo;
            HtmlNode temp;
            foreach (var node in nodes)
            {
                temp = HtmlNode.CreateNode(node.OuterHtml);
                jokeinfo = new JokeInfo();
                jokeinfo.Title = temp.SelectSingleNode(txtTitleRule.Text.Trim()).InnerText.Trim();
                jokeinfo.Content = temp.SelectSingleNode(txtContentRule.Text.Trim()).InnerText.Trim();
                if (string.IsNullOrEmpty(jokeinfo.Content) || string.IsNullOrEmpty(jokeinfo.Title))
                {
                    continue;
                }
                jokes.Add(jokeinfo);
            }
            if(jokes.Count==0)
            {
                lblMsg.Text = "没有抓取到数据，请重新定义规则!";
                return;
            }

            jokeLogic.AddJokes(ToJokes(jokes));
            lblMsg.Text = "抓取数据成功";
            //jokeLogic.AddJokes();
        }

        private void cboRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cboRules.SelectedValue.ToString()))
            {
                txtTitleRule.Text = "";
                txtContentRule.Text = "";
                txtListRule.Text = "";
                txtRequestUrl.Text = "";
                isOk = false;
                return;
            }
            isOk = true;
            txtRequestUrl.Text = this.cboRules.SelectedValue.ToString();
            var rule = Spider.GetRuleByName(this.cboRules.Text);
            txtTitleRule.Text = rule.TitleRule;
            txtContentRule.Text = rule.ContentRule;
            txtListRule.Text = rule.ListRule;
            //MessageBox.Show(selectValue.ToString());
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 522)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<T_Joke> ToJokes(List<JokeInfo> jokeinfos)
        {
            var jokes = jokeinfos.Select(u =>
            {
                return new T_Joke()
                {
                    AddDate = DateTime.Now,
                    Category = AppConfig.Category,
                    CheckDate = DateTime.Now,
                    CheckUserId = AppConfig.UserID,
                    CommentCount = 0,
                    Content = u.Content,
                    HateCount = 0,
                    LikeCount = 0,
                    PostID = AppConfig.UserID,
                    State = 1,
                    Title = u.Title,
                    Type = 0
                };
            }).ToList();
            return jokes;
        }
    }
}
