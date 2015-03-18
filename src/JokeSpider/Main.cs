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
using System.Threading;
using Joke.Common;

namespace JokeSpider
{
    public partial class mainForm : Form, IMessageFilter
    {
        JokeBusinessLogic jokeLogic = new JokeBusinessLogic();
        bool isOk = false;
        string encoding = "";
        public mainForm()
        {

            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false; 
            DtoMapper.AutoMapper();
            LogHelper.LogConfig("Config\\log4net.config");
            Application.AddMessageFilter(this);
            var rules = Spider.GetRules();
            rules.Insert(0,new SpiderRule()
            {
                Name = "--请选择来源--",
                Url = ""
            });
            cboRules.DataSource = rules;
            cboRules.SelectedIndex = 0;
            cboRules.SelectedIndexChanged += cboRules_SelectedIndexChanged;
            cmbCategory.DataSource = jokeLogic.GetCategoryList();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "正在执行请等待";
            if (!isOk)
            {
                lblMsg.Text = "请填写合法的数据";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            //==========
            CheckForIllegalCrossThreadCalls = false;
            btnRequest.Enabled = false;
            Thread myThread = new Thread(CatchJokes);
            myThread.IsBackground = true;
            myThread.Start();
            //==========

            

            
            //jokeLogic.AddJokes();
        }

        private void cboRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRequest.Enabled = true;
            lblMsg.Text = "";
            txtRepContent.Text = "";
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
            encoding = rule.Encoding;
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
                    Category = cmbCategory.SelectedValue.ToString().ToInt32(),
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

        private void CatchJokes()
        {
            CatchJokesAction(SetCatchProgress);

        }

        private void SetCatchProgress(string msg)
        {
            pgCatchStatus.Value = 0;
            pgCatchStatus.Maximum = 100;
            
            for (int i = 0; i < 100; i++)
            {
                pgCatchStatus.Value = i;
                Thread.Sleep(1);
            }

            lblCatchStatus.Text = msg;
        }

        private void CatchJokesAction(Action<string> action)
        {
            int endPage = 1;
            int startPage = 1;
            if (cbIsRepeat.Checked)
            {
                startPage = txtStart.Text.ToInt32();
                endPage = txtEndPage.Text.ToInt32();

                for (int i = startPage; i <= endPage; i++)
                {
                    action(string.Format("正在抓取:{0}", string.Format(txtRequestUrl.Text, i)));
                    List<JokeInfo> jokes = new List<JokeInfo>();
                    var content = Spider.GetHtmlContent(string.Format(txtRequestUrl.Text, i), encoding);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(content);
                    string jokelistXPath = txtListRule.Text.Trim();
                    var nodes = doc.DocumentNode.SelectNodes(jokelistXPath);

                    if (nodes == null || nodes.Count == 0)
                    {
                        lblMsg.Text = "没有抓取到集合数据，请重新定义规则";
                        continue;
                    }
                    else
                    {
                        lblMsg.Text = nodes.Count.ToString();
                        txtRepContent.Text = nodes[0].InnerHtml;
                        //return;
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
                    if (jokes.Count == 0)
                    {
                        lblMsg.Text = "没有抓取到数据，请重新定义规则!";
                        return;
                    }

                    jokeLogic.AddJokes(ToJokes(jokes));
                    lblMsg.Text = "抓取数据成功";
                }
            }
            else
            {
                action(string.Format("正在抓取:{0}", txtRequestUrl.Text));
                List<JokeInfo> jokes = new List<JokeInfo>();
                var content = Spider.GetHtmlContent(txtRequestUrl.Text, encoding);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(content);
                string jokelistXPath = txtListRule.Text.Trim();
                var nodes = doc.DocumentNode.SelectNodes(jokelistXPath);

                if (nodes == null || nodes.Count == 0)
                {
                    lblMsg.Text = "没有抓取到集合数据，请重新定义规则";
                    return;
                }
                else
                {
                    lblMsg.Text = nodes.Count.ToString();
                    txtRepContent.Text = nodes[0].InnerHtml;
                    //return;
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
                if (jokes.Count == 0)
                {
                    lblMsg.Text = "没有抓取到数据，请重新定义规则!";
                    return;
                }

                jokeLogic.AddJokes(ToJokes(jokes));
                lblMsg.Text = "抓取数据成功";
            }

            btnRequest.Enabled = true;
            lblCatchStatus.Text = "";
           
        }
    }
}
