namespace EustonLeisure
{
    partial class Form1
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
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnTrendingList = new System.Windows.Forms.Button();
            this.btnMentionsList = new System.Windows.Forms.Button();
            this.btnSirList = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabSms = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSmsBody = new System.Windows.Forms.TextBox();
            this.tabEmail = new System.Windows.Forms.TabPage();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.tbEmailSubject = new System.Windows.Forms.TextBox();
            this.tbEmailBody = new System.Windows.Forms.TextBox();
            this.tabMessageSelection = new System.Windows.Forms.TabControl();
            this.tabTweet = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTweetBody = new System.Windows.Forms.TextBox();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.tbFileUnprocessed = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbSender = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelSender = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.tabSms.SuspendLayout();
            this.tabEmail.SuspendLayout();
            this.tabMessageSelection.SuspendLayout();
            this.tabTweet.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.BackColor = System.Drawing.SystemColors.Control;
            this.tbOutput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbOutput.Location = new System.Drawing.Point(12, 353);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(614, 136);
            this.tbOutput.TabIndex = 1;
            // 
            // btnTrendingList
            // 
            this.btnTrendingList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrendingList.Location = new System.Drawing.Point(12, 504);
            this.btnTrendingList.Name = "btnTrendingList";
            this.btnTrendingList.Size = new System.Drawing.Size(131, 30);
            this.btnTrendingList.TabIndex = 2;
            this.btnTrendingList.Text = "Trending list";
            this.btnTrendingList.UseVisualStyleBackColor = true;
            this.btnTrendingList.Click += new System.EventHandler(this.BtnTrending_Click);
            // 
            // btnMentionsList
            // 
            this.btnMentionsList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMentionsList.Location = new System.Drawing.Point(239, 504);
            this.btnMentionsList.Name = "btnMentionsList";
            this.btnMentionsList.Size = new System.Drawing.Size(131, 30);
            this.btnMentionsList.TabIndex = 3;
            this.btnMentionsList.Text = "Mentions list";
            this.btnMentionsList.UseVisualStyleBackColor = true;
            this.btnMentionsList.Click += new System.EventHandler(this.BtnMentions_Click);
            // 
            // btnSirList
            // 
            this.btnSirList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSirList.Location = new System.Drawing.Point(495, 504);
            this.btnSirList.Name = "btnSirList";
            this.btnSirList.Size = new System.Drawing.Size(131, 30);
            this.btnSirList.TabIndex = 4;
            this.btnSirList.Text = "SIR list";
            this.btnSirList.UseVisualStyleBackColor = true;
            this.btnSirList.Click += new System.EventHandler(this.BtnSir_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmit.Location = new System.Drawing.Point(16, 559);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(93, 38);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(524, 559);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 38);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // tabSms
            // 
            this.tabSms.BackColor = System.Drawing.Color.Transparent;
            this.tabSms.Controls.Add(this.label1);
            this.tabSms.Controls.Add(this.tbSmsBody);
            this.tabSms.Location = new System.Drawing.Point(4, 29);
            this.tabSms.Name = "tabSms";
            this.tabSms.Padding = new System.Windows.Forms.Padding(3);
            this.tabSms.Size = new System.Drawing.Size(606, 206);
            this.tabSms.TabIndex = 1;
            this.tabSms.Text = "SMS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Message body";
            // 
            // tbSmsBody
            // 
            this.tbSmsBody.Location = new System.Drawing.Point(6, 35);
            this.tbSmsBody.Multiline = true;
            this.tbSmsBody.Name = "tbSmsBody";
            this.tbSmsBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSmsBody.Size = new System.Drawing.Size(581, 159);
            this.tbSmsBody.TabIndex = 27;
            // 
            // tabEmail
            // 
            this.tabEmail.BackColor = System.Drawing.Color.Transparent;
            this.tabEmail.Controls.Add(this.labelBody);
            this.tabEmail.Controls.Add(this.labelSubject);
            this.tabEmail.Controls.Add(this.tbEmailSubject);
            this.tabEmail.Controls.Add(this.tbEmailBody);
            this.tabEmail.Location = new System.Drawing.Point(4, 29);
            this.tabEmail.Name = "tabEmail";
            this.tabEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmail.Size = new System.Drawing.Size(606, 206);
            this.tabEmail.TabIndex = 0;
            this.tabEmail.Text = "Email";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(6, 64);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(112, 20);
            this.labelBody.TabIndex = 18;
            this.labelBody.Text = "Message body";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(6, 3);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(63, 20);
            this.labelSubject.TabIndex = 17;
            this.labelSubject.Text = "Subject";
            // 
            // tbEmailSubject
            // 
            this.tbEmailSubject.Location = new System.Drawing.Point(10, 26);
            this.tbEmailSubject.Name = "tbEmailSubject";
            this.tbEmailSubject.Size = new System.Drawing.Size(577, 26);
            this.tbEmailSubject.TabIndex = 15;
            // 
            // tbEmailBody
            // 
            this.tbEmailBody.Location = new System.Drawing.Point(10, 87);
            this.tbEmailBody.Multiline = true;
            this.tbEmailBody.Name = "tbEmailBody";
            this.tbEmailBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEmailBody.Size = new System.Drawing.Size(577, 106);
            this.tbEmailBody.TabIndex = 14;
            // 
            // tabMessageSelection
            // 
            this.tabMessageSelection.Controls.Add(this.tabEmail);
            this.tabMessageSelection.Controls.Add(this.tabSms);
            this.tabMessageSelection.Controls.Add(this.tabTweet);
            this.tabMessageSelection.Controls.Add(this.tabFile);
            this.tabMessageSelection.Location = new System.Drawing.Point(12, 83);
            this.tabMessageSelection.Name = "tabMessageSelection";
            this.tabMessageSelection.SelectedIndex = 0;
            this.tabMessageSelection.Size = new System.Drawing.Size(614, 239);
            this.tabMessageSelection.TabIndex = 7;
            this.tabMessageSelection.SelectedIndexChanged += new System.EventHandler(this.TabMessageSelection_SelectedIndexChanged);
            // 
            // tabTweet
            // 
            this.tabTweet.BackColor = System.Drawing.Color.Transparent;
            this.tabTweet.Controls.Add(this.label2);
            this.tabTweet.Controls.Add(this.label3);
            this.tabTweet.Controls.Add(this.tbTweetBody);
            this.tabTweet.Location = new System.Drawing.Point(4, 29);
            this.tabTweet.Name = "tabTweet";
            this.tabTweet.Padding = new System.Windows.Forms.Padding(3);
            this.tabTweet.Size = new System.Drawing.Size(606, 206);
            this.tabTweet.TabIndex = 2;
            this.tabTweet.Text = "Tweet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Message body";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 26;
            // 
            // tbTweetBody
            // 
            this.tbTweetBody.Location = new System.Drawing.Point(6, 36);
            this.tbTweetBody.Multiline = true;
            this.tbTweetBody.Name = "tbTweetBody";
            this.tbTweetBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTweetBody.Size = new System.Drawing.Size(581, 159);
            this.tbTweetBody.TabIndex = 24;
            // 
            // tabFile
            // 
            this.tabFile.BackColor = System.Drawing.Color.Transparent;
            this.tabFile.Controls.Add(this.tbFileUnprocessed);
            this.tabFile.Controls.Add(this.btnBrowse);
            this.tabFile.Location = new System.Drawing.Point(4, 29);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(606, 206);
            this.tabFile.TabIndex = 3;
            this.tabFile.Text = "File";
            // 
            // tbFileUnprocessed
            // 
            this.tbFileUnprocessed.BackColor = System.Drawing.Color.White;
            this.tbFileUnprocessed.Location = new System.Drawing.Point(6, 6);
            this.tbFileUnprocessed.Multiline = true;
            this.tbFileUnprocessed.Name = "tbFileUnprocessed";
            this.tbFileUnprocessed.ReadOnly = true;
            this.tbFileUnprocessed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFileUnprocessed.Size = new System.Drawing.Size(594, 149);
            this.tbFileUnprocessed.TabIndex = 25;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(234, 161);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(101, 39);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // tbSender
            // 
            this.tbSender.Location = new System.Drawing.Point(16, 43);
            this.tbSender.Name = "tbSender";
            this.tbSender.Size = new System.Drawing.Size(606, 26);
            this.tbSender.TabIndex = 17;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelSender
            // 
            this.labelSender.AutoSize = true;
            this.labelSender.Location = new System.Drawing.Point(12, 20);
            this.labelSender.Name = "labelSender";
            this.labelSender.Size = new System.Drawing.Size(61, 20);
            this.labelSender.TabIndex = 18;
            this.labelSender.Text = "Sender";
            // 
            // labelOutput
            // 
            this.labelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(12, 330);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(58, 20);
            this.labelOutput.TabIndex = 19;
            this.labelOutput.Text = "Output";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 609);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelSender);
            this.Controls.Add(this.tbSender);
            this.Controls.Add(this.tabMessageSelection);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSirList);
            this.Controls.Add(this.btnMentionsList);
            this.Controls.Add(this.btnTrendingList);
            this.Controls.Add(this.tbOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabSms.ResumeLayout(false);
            this.tabSms.PerformLayout();
            this.tabEmail.ResumeLayout(false);
            this.tabEmail.PerformLayout();
            this.tabMessageSelection.ResumeLayout(false);
            this.tabTweet.ResumeLayout(false);
            this.tabTweet.PerformLayout();
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnTrendingList;
        private System.Windows.Forms.Button btnMentionsList;
        private System.Windows.Forms.Button btnSirList;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabPage tabSms;
        private System.Windows.Forms.TabPage tabEmail;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox tbEmailSubject;
        private System.Windows.Forms.TextBox tbEmailBody;
        private System.Windows.Forms.TabControl tabMessageSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSmsBody;
        private System.Windows.Forms.TextBox tbSender;
        private System.Windows.Forms.TabPage tabTweet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTweetBody;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileUnprocessed;
        private System.Windows.Forms.Label labelSender;
        private System.Windows.Forms.Label labelOutput;
    }
}

