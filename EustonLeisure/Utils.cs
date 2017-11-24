using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EustonLeisure.Properties;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace EustonLeisure
{
    /// <summary>
    /// Contains methods that are used by MainForm.cs to read in Textspeak abbreviations, as well as methods for 
    /// loading input from a file and saving processed messages to it.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Reads textwords from a CSV resource file and stores them in a dictionary.
        /// </summary>
        /// <returns>Returns dictionary where key-value pair are textspeak abbreviations and their expanded form.</returns>
        public static Dictionary<string, string> GetTextwords()
        {
            Dictionary<string, string> textwords = new Dictionary<string, string>();

            //var path = @"C:\Napier\Software Engineering\coursework\textwords.csv";

            //open resource file
            var csvTextwords = Resources.textwords;

            //store all lines in an array of strings
            string[] lines = csvTextwords.Split('\n');

            foreach (string t in lines)
            {
                int index = t.IndexOf(',');

                string abbreviation = t.Substring(0, index);
                string fullForm = t.Substring(index + 1).TrimEnd();

                textwords.Add(abbreviation, fullForm);
            }

/*            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    string abbreviation = fields[0];
                    string fullForm = fields[1];
                    textwords.Add(abbreviation, fullForm);
                }
            }*/

            return textwords;
        }

        /// <summary>
        /// Serializes messages to a JSON formatted file.
        /// </summary>
        /// <param name="messages"></param>
        public static void SerializeToJson(List<Message> messages)
        {
            string json = JsonConvert.SerializeObject(messages, Formatting.Indented);

            //attempt to create or append serialized messages to "processed messages.json" file inside program folder
            try
            {
                using (StreamWriter file = File.CreateText(@".\processed messages.json"))
                {
                    file.Write(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Attempts to deserialize messages from a file. File has to be in a JSON format 
        /// and contain messages in a valid format. 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Returns dictionary where key-value pair are unprocessed messages from a file and
        /// their processed version of a specific message type.</returns>
        public static Dictionary<MessageWrapper, Message> DeserializeFromJson(string path)
        {
            // stores unprocessed messages as a key and processed messages as a value
            Dictionary<MessageWrapper, Message> messages = new Dictionary<MessageWrapper, Message>();

            // stores unprocessed messages that were read in from a file
            List<MessageWrapper> unprocessedMessages = new List<MessageWrapper>();

            try
            {
                string json = File.ReadAllText(path);
                unprocessedMessages = JsonConvert.DeserializeObject<List<MessageWrapper>>(json);
            }
            catch (Newtonsoft.Json.JsonReaderException readerException)
            {
                Console.WriteLine(readerException);
                throw;
            }
            catch (IOException ioException)
            {
                Console.WriteLine(ioException);
                throw;
            }
            catch (NullReferenceException nullException)
            {
                Console.WriteLine(nullException);
                throw;
            }

            foreach (var unprocessedMessage in unprocessedMessages)
            {
                var messageId = unprocessedMessage.MessageId;
                var sender = unprocessedMessage.Sender;
                var body = unprocessedMessage.Body;

                try
                {
                    if (messageId.StartsWith("E"))
                    {
                        EmailMessage email = new EmailMessage(sender, unprocessedMessage.Subject, body);
                        messages.Add(unprocessedMessage, email);
                    }
                    else if (messageId.StartsWith("S"))
                    {
                        SmsMessage sms = new SmsMessage(sender, body);
                        messages.Add(unprocessedMessage, sms);
                    }
                    else if (messageId.StartsWith("T"))
                    {
                        TweetMessage tweet = new TweetMessage(sender, body);
                        messages.Add(unprocessedMessage, tweet);
                    }
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException);
                    messages.Add(unprocessedMessage, null);
                }
                catch (NullReferenceException nullException)
                {
                    Console.WriteLine(nullException);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return messages;
        }

        /// <summary>
        /// Class for creating POCO for temporarily storing messages that are read in from a file.
        /// </summary>
        public class MessageWrapper
        {
            public string MessageId { get; set; }
            public string Sender { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }

            public override string ToString()
            {
                if (Subject == null)
                    return $"Message Id: {MessageId}\r\nSender: {Sender}\r\nMessage: {Body}";

                return $"Message Id: {MessageId}\r\nSender: {Sender}\r\nSubject: {Subject}\r\nMessage: {Body}";
            }
        }
    }
}