using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EustonLeisure
{
    public partial class Form1 : Form
    {
        public static readonly Dictionary<string, string> Textwords = Utils.GetTextwords();
        private List<Message> _processedMessages = new List<Message>();
        private Dictionary<Utils.MessageWrapper, Message> _messagesFromFile = new Dictionary<Utils.MessageWrapper, Message>();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnTrending_Click(object sender, EventArgs e)
        {
            TrendingForm trending = new TrendingForm();
            trending.Show();
        }

        private void BtnMentions_Click(object sender, EventArgs e)
        {
            MentionsForm mentions = new MentionsForm();
            mentions.Show();
        }

        private void BtnSir_Click(object sender, EventArgs e)
        {
            SirForm sir = new SirForm();
            sir.Show();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            tbOutput.Clear();
            int activeTab = tabMessageSelection.SelectedIndex;
            string messageSender = tbSender.Text;

            switch (activeTab)
            {
                // Email message
                case 0:
                    {
                        try
                        {
                            EmailMessage email = new EmailMessage(messageSender, tbEmailSubject.Text, tbEmailBody.Text);
                            tbOutput.Text = email.Body;

                            _processedMessages.Add(email);
                        }
                        catch (ArgumentException)
                        {
                            tbOutput.Text = Properties.Resources.InvalidInput;
                        }
                        catch (Exception)
                        {
                            tbOutput.Text = Properties.Resources.GenericError;
                        }

                        break;
                    }
                // SMS message
                case 1:
                    {
                        try
                        {
                            string message = tbSmsBody.Text;

                            SmsMessage sms = new SmsMessage(messageSender, message);
                            tbOutput.Text = sms.Body;

                            _processedMessages.Add(sms);
                        }
                        catch (ArgumentException)
                        {
                            tbOutput.Text = Properties.Resources.InvalidInput;
                        }
                        catch (Exception)
                        {
                            tbOutput.Text = Properties.Resources.GenericError;
                        }

                        break;
                    }
                // Tweet message
                case 2:
                    {
                        try
                        {
                            TweetMessage tweet = new TweetMessage(messageSender, tbTweetBody.Text);
                            tbOutput.Text = tweet.Body;

                            _processedMessages.Add(tweet);
                        }
                        catch (ArgumentException)
                        {
                            tbOutput.Text = Properties.Resources.InvalidInput;
                        }
                        catch (Exception)
                        {
                            tbOutput.Text = Properties.Resources.GenericError;
                        }

                        break;
                    }

                case 3:
                    var counter = 1;
                    foreach (var message in _messagesFromFile)
                    {
                        tbOutput.AppendText("MESSAGE #" + counter++ + "\n");
                        tbOutput.AppendText(message.Value + "\r\n\r\n");

                        _processedMessages.Add(message.Value);
                    }

                    break;
            }

            tbOutput.Select(0, 0);
            tbOutput.ScrollToCaret();
        }

        // clears all text boxes
        private void BtnClear_Click(object sender, EventArgs e)
        {
            tbSender.Clear();

            if (tabMessageSelection.SelectedTab == tabEmail)
            {
                tbEmailSubject.Clear();
                tbEmailBody.Clear();
            }
            else if (tabMessageSelection.SelectedTab == tabSms)
                tbSmsBody.Clear();
            else if (tabMessageSelection.SelectedTab == tabTweet)
                tbTweetBody.Clear();
            else if (tabMessageSelection.SelectedTab == tabFile)
                tbFileUnprocessed.Clear();

            tbOutput.Clear();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            tbFileUnprocessed.Clear();

            if (_messagesFromFile.Any())
                _messagesFromFile.Clear();

            if (result == DialogResult.OK) // Test result.
            {
                var path = openFileDialog1.FileName;
                _messagesFromFile = Utils.DeserializeFromJson(path);

                var counter = 1;

                foreach (var message in _messagesFromFile)
                {
                    tbFileUnprocessed.AppendText("MESSAGE #" + counter++ + "\n");
                    tbFileUnprocessed.AppendText(message.Key + "\r\n\r\n");
                }

                tbFileUnprocessed.Select(0,0);
                tbFileUnprocessed.ScrollToCaret();
            }
        }

        private void TabMessageSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMessageSelection.SelectedTab == tabFile)
            {
                tbSender.BackColor = tbOutput.BackColor;
                tbSender.ReadOnly = true;
            }
            else
            {
                tbSender.BackColor = Color.White;
                tbSender.ReadOnly = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.SerializeToJson(_processedMessages);
        }
    }
}
