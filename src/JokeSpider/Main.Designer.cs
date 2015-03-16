namespace JokeSpider
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRequest = new System.Windows.Forms.Button();
            this.txtRequestUrl = new System.Windows.Forms.TextBox();
            this.lblRequestUrl = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cboRules = new System.Windows.Forms.ComboBox();
            this.lblSiteName = new System.Windows.Forms.Label();
            this.lblTitleRule = new System.Windows.Forms.Label();
            this.txtTitleRule = new System.Windows.Forms.TextBox();
            this.lblContentRule = new System.Windows.Forms.Label();
            this.txtContentRule = new System.Windows.Forms.TextBox();
            this.lblListRule = new System.Windows.Forms.Label();
            this.txtListRule = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtRepContent = new System.Windows.Forms.TextBox();
            this.cbIsRepeat = new System.Windows.Forms.CheckBox();
            this.txtTotalPage = new System.Windows.Forms.TextBox();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(76, 276);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 0;
            this.btnRequest.Text = "发送请求";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // txtRequestUrl
            // 
            this.txtRequestUrl.Location = new System.Drawing.Point(141, 94);
            this.txtRequestUrl.Name = "txtRequestUrl";
            this.txtRequestUrl.Size = new System.Drawing.Size(217, 21);
            this.txtRequestUrl.TabIndex = 1;
            // 
            // lblRequestUrl
            // 
            this.lblRequestUrl.AutoSize = true;
            this.lblRequestUrl.Location = new System.Drawing.Point(76, 97);
            this.lblRequestUrl.Name = "lblRequestUrl";
            this.lblRequestUrl.Size = new System.Drawing.Size(59, 12);
            this.lblRequestUrl.TabIndex = 2;
            this.lblRequestUrl.Text = "请求地址:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(76, 352);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(280, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // cboRules
            // 
            this.cboRules.DisplayMember = "Name";
            this.cboRules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRules.FormattingEnabled = true;
            this.cboRules.ItemHeight = 12;
            this.cboRules.Location = new System.Drawing.Point(141, 28);
            this.cboRules.Name = "cboRules";
            this.cboRules.Size = new System.Drawing.Size(217, 20);
            this.cboRules.TabIndex = 4;
            this.cboRules.ValueMember = "Url";
            // 
            // lblSiteName
            // 
            this.lblSiteName.AutoSize = true;
            this.lblSiteName.Location = new System.Drawing.Point(78, 28);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(59, 12);
            this.lblSiteName.TabIndex = 5;
            this.lblSiteName.Text = "网站名称:";
            // 
            // lblTitleRule
            // 
            this.lblTitleRule.AutoSize = true;
            this.lblTitleRule.Location = new System.Drawing.Point(76, 137);
            this.lblTitleRule.Name = "lblTitleRule";
            this.lblTitleRule.Size = new System.Drawing.Size(59, 12);
            this.lblTitleRule.TabIndex = 6;
            this.lblTitleRule.Text = "标题规则:";
            // 
            // txtTitleRule
            // 
            this.txtTitleRule.Location = new System.Drawing.Point(141, 134);
            this.txtTitleRule.Name = "txtTitleRule";
            this.txtTitleRule.Size = new System.Drawing.Size(217, 21);
            this.txtTitleRule.TabIndex = 7;
            // 
            // lblContentRule
            // 
            this.lblContentRule.AutoSize = true;
            this.lblContentRule.Location = new System.Drawing.Point(76, 177);
            this.lblContentRule.Name = "lblContentRule";
            this.lblContentRule.Size = new System.Drawing.Size(59, 12);
            this.lblContentRule.TabIndex = 8;
            this.lblContentRule.Text = "内容规则:";
            // 
            // txtContentRule
            // 
            this.txtContentRule.Location = new System.Drawing.Point(141, 168);
            this.txtContentRule.Name = "txtContentRule";
            this.txtContentRule.Size = new System.Drawing.Size(217, 21);
            this.txtContentRule.TabIndex = 9;
            // 
            // lblListRule
            // 
            this.lblListRule.AutoSize = true;
            this.lblListRule.Location = new System.Drawing.Point(78, 65);
            this.lblListRule.Name = "lblListRule";
            this.lblListRule.Size = new System.Drawing.Size(59, 12);
            this.lblListRule.TabIndex = 10;
            this.lblListRule.Text = "集合规则:";
            // 
            // txtListRule
            // 
            this.txtListRule.Location = new System.Drawing.Point(141, 62);
            this.txtListRule.Name = "txtListRule";
            this.txtListRule.Size = new System.Drawing.Size(217, 21);
            this.txtListRule.TabIndex = 11;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(172, 281);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 12;
            this.lblMsg.Text = "待抓取";
            // 
            // txtRepContent
            // 
            this.txtRepContent.Location = new System.Drawing.Point(388, 28);
            this.txtRepContent.Multiline = true;
            this.txtRepContent.Name = "txtRepContent";
            this.txtRepContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRepContent.Size = new System.Drawing.Size(474, 250);
            this.txtRepContent.TabIndex = 13;
            // 
            // cbIsRepeat
            // 
            this.cbIsRepeat.AutoSize = true;
            this.cbIsRepeat.Location = new System.Drawing.Point(141, 244);
            this.cbIsRepeat.Name = "cbIsRepeat";
            this.cbIsRepeat.Size = new System.Drawing.Size(72, 16);
            this.cbIsRepeat.TabIndex = 15;
            this.cbIsRepeat.Text = "是否循环";
            this.cbIsRepeat.UseVisualStyleBackColor = true;
            // 
            // txtTotalPage
            // 
            this.txtTotalPage.Location = new System.Drawing.Point(283, 239);
            this.txtTotalPage.Name = "txtTotalPage";
            this.txtTotalPage.Size = new System.Drawing.Size(75, 21);
            this.txtTotalPage.TabIndex = 16;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(237, 244);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(35, 12);
            this.lblPageNumber.TabIndex = 17;
            this.lblPageNumber.Text = "页码:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(141, 200);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(215, 20);
            this.cmbCategory.TabIndex = 18;
            this.cmbCategory.ValueMember = "ID";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(100, 208);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(35, 12);
            this.lblCategory.TabIndex = 19;
            this.lblCategory.Text = "类型:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 468);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.txtTotalPage);
            this.Controls.Add(this.cbIsRepeat);
            this.Controls.Add(this.txtRepContent);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtListRule);
            this.Controls.Add(this.lblListRule);
            this.Controls.Add(this.txtContentRule);
            this.Controls.Add(this.lblContentRule);
            this.Controls.Add(this.txtTitleRule);
            this.Controls.Add(this.lblTitleRule);
            this.Controls.Add(this.lblSiteName);
            this.Controls.Add(this.cboRules);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblRequestUrl);
            this.Controls.Add(this.txtRequestUrl);
            this.Controls.Add(this.btnRequest);
            this.Name = "mainForm";
            this.Text = "超级冷笑话爬虫";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox txtRequestUrl;
        private System.Windows.Forms.Label lblRequestUrl;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox cboRules;
        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.Label lblTitleRule;
        private System.Windows.Forms.TextBox txtTitleRule;
        private System.Windows.Forms.Label lblContentRule;
        private System.Windows.Forms.TextBox txtContentRule;
        private System.Windows.Forms.Label lblListRule;
        private System.Windows.Forms.TextBox txtListRule;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtRepContent;
        private System.Windows.Forms.CheckBox cbIsRepeat;
        private System.Windows.Forms.TextBox txtTotalPage;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
    }
}

