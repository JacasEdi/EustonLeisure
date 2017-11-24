using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EustonLeisure
{
    /// <summary>
    /// Main class that handles user interaction with the program, reads the input and displays processed messages.
    /// </summary>
    public partial class MainForm : Form
    {
        // stores Textspeak abbreviations that are then used by SmsMessage and TweetMessage classes
        public static readonly Dictionary<string, string> Textwords = Utils.GetTextwords();

        // stores all processed messages from current input session so that they can be saved to a file at the end of it
        private List<Message> _processedMessages = new List<Message>();

        // stores key-value pairs of unproccessed messages from a file and their processed version of a specific type
        private Dictionary<Utils.MessageWrapper, Message> _messagesFromFile = new Dictionary<Utils.MessageWrapper, Message>();

        public MainForm()
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

        /// <summary>
        /// Determines which type of message user attempts to send once "Submit" button is clicked and
        /// attempts to object of this type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            tbOutput.Clear();
            int activeTab = tabMessageSelection.SelectedIndex;
            string messageSender = tbSender.Text;

            switch (activeTab)
            {
                // User attempts to send email
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
                // User attempts to send SMS
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
                // User attempts to send Tweet
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
                // user attempts to load input from a file
                case 3:
                    // check whether file contains any valid messages
                    if (_messagesFromFile.Any())
                    {
                        var counter = 1;

                        // sort messages by MessageId to display them in groups
                        var sortedDict = _messagesFromFile.OrderBy(o => o.Key.MessageId);
                        var firstEmail = sortedDict.First(o => o.Key.MessageId.Contains("E"));
                        var firstSms = sortedDict.First(o => o.Key.MessageId.Contains("S"));
                        var firstTweet = sortedDict.First(o => o.Key.MessageId.Contains("T"));

                        foreach (var message in sortedDict)
                        {
                            if (message.Equals(firstEmail))
                                tbOutput.AppendText("---------------EMAIL MESSAGES---------------\n");
                            if (message.Equals(firstSms))
                                tbOutput.AppendText("----------------SMS MESSAGES----------------\n");
                            if (message.Equals(firstTweet))
                                tbOutput.AppendText("---------------TWEET MESSAGES---------------\n");

                            tbOutput.AppendText("MESSAGE #" + counter++ + "\n");

                            if (message.Value == null)
                            {
                                tbOutput.AppendText("Invalid message format\r\n\r\n");
                                _processedMessages.Add(message.Value);
                            }
                            else
                            {
                                tbOutput.AppendText(message.Value + "\r\n\r\n");

                                _processedMessages.Add(message.Value);
                            }
                        }

                       
                    }
                    else
                    {
                        tbOutput.Text = Properties.Resources.NullError;
                    }

                    break;
            }

            tbOutput.Select(0, 0);
            tbOutput.ScrollToCaret();
        }

        /// <summary>
        /// Clears all text boxes on the active tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Allows the user to browse for a file from where messages are to be loaded and attempts to read that file. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            tbFileUnprocessed.Clear();

            // delete any messsages that were previously read from a file if there are any
            if (_messagesFromFile.Any())
                _messagesFromFile.Clear();

            if (result == DialogResult.OK)
            {
                tbOutput.Clear();
                var path = openFileDialog1.FileName;

                try
                {
                    _messagesFromFile = Utils.DeserializeFromJson(path);

                    var counter = 1;

                    // show unprocessed messages from a file in a textbox
                    foreach (var message in _messagesFromFile)
                    {
                        tbFileUnprocessed.AppendText("MESSAGE #" + counter++ + "\n");
                        tbFileUnprocessed.AppendText(message.Key + "\r\n\r\n");
                    }

                    tbFileUnprocessed.Select(0, 0);
                    tbFileUnprocessed.ScrollToCaret();
                }
                catch (IOException ioException)
                {
                    Console.WriteLine(ioException);
                    tbOutput.Text = Properties.Resources.WrongFileFormat;
                }
                catch (Newtonsoft.Json.JsonReaderException readerException)
                {
                    Console.WriteLine(readerException);
                    tbOutput.Text = Properties.Resources.WrongFileFormat;
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException);
                    tbOutput.Text = Properties.Resources.InvalidInput;
                }
                catch (NullReferenceException nullException)
                {
                    Console.WriteLine(nullException);
                    tbOutput.Text = Properties.Resources.NullError;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    tbOutput.Text = Properties.Resources.GenericError;
                }
            }
        }

        /// <summary>
        /// Disables Sender textbox if tab for loading messages from a file is active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Saves all processed messages from current input session to a file on the exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.SerializeToJson(_processedMessages);
        }
    }
}
