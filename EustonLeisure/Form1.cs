using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EustonLeisure
{
    public partial class Form1 : Form
    {
        public static readonly Dictionary<string, string> Textwords = Utils.GetTextwords();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnTrending_Click(object sender, EventArgs e)
        {
            TrendingForm trending = new TrendingForm();
            trending.Show();

        }

        private void btnMentions_Click(object sender, EventArgs e)
        {
            MentionsForm mentions = new MentionsForm();
            mentions.Show();

        }

        private void btnSir_Click(object sender, EventArgs e)
        {
            SirForm sir = new SirForm();
            sir.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int activeTab = tabMessageSelection.SelectedIndex;
            Console.WriteLine("Active tab " + activeTab);

            string messageSender = tbSender.Text;

            switch (activeTab)
            {
                // Email message
                case 0:
                    {
                        try
                        {
                            if (tbEmailSubject.Text.StartsWith("SIR"))
                            {
                                SirEmailMessage sirEmail =
                                    new SirEmailMessage(messageSender, tbEmailSubject.Text, tbEmailBody.Text);
                                tbOutput.Text = sirEmail.Body;
                            }
                            else
                            {
                                EmailMessage email = new EmailMessage(messageSender, tbEmailSubject.Text, tbEmailBody.Text);
                                tbOutput.Text = email.Body;
                            }

                        }
                        catch (ArgumentException argException)
                        {
                            tbOutput.Text = "Invalid input";
                        }
                        catch (Exception exception)
                        {
                            tbOutput.Text = "Error";
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
                        }
                        catch (ArgumentException argException)
                        {
                            tbOutput.Text = "Invalid input";
                        }
                        catch (Exception exception)
                        {
                            tbOutput.Text = "Error";
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
                        }
                        catch (ArgumentException argException)
                        {
                            tbOutput.Text = "Invalid input";
                        }
                        catch (Exception exception)
                        {
                            tbOutput.Text = "Error";
                        }

                        break;
                    }
            }
        }

        // clear all text boxes
        private void btnClear_Click(object sender, EventArgs e)
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

            tbOutput.Clear();
        }
    }
}
