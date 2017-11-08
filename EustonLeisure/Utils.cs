using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace EustonLeisure
{
    public class Utils
    {
        public static Dictionary<string, string> GetTextwords()
        {
            Dictionary<string, string> textwords = new Dictionary<string, string>();

            var path = @"C:\Napier\Software Engineering\coursework\textwords.csv";

            using (TextFieldParser csvParser = new TextFieldParser(path))
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
            }

            return textwords;
        }

        public static void SerializeToJson(List<Message> messages)
        {
            string json = JsonConvert.SerializeObject(messages, Formatting.Indented);

            try
            {
                using (StreamWriter file = File.CreateText(@"C:\Napier\Software Engineering\messages.json"))
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

        public static Dictionary<MessageWrapper, Message> DeserializeFromJson(string path)
        {
            Dictionary<MessageWrapper, Message> messages = new Dictionary<MessageWrapper, Message>();

            try
            {
                string json = File.ReadAllText(@path);
                List<MessageWrapper> rawMessages = JsonConvert.DeserializeObject<List<MessageWrapper>>(json);

                string messageId;
                string sender;
                string body;

                foreach (var rawMessage in rawMessages)
                {
                    messageId = rawMessage.MessageId;
                    sender = rawMessage.Sender;
                    body = rawMessage.Body;

                    if (messageId.StartsWith("E"))
                    {
                        EmailMessage email = new EmailMessage(sender, rawMessage.Subject, body);
                        messages.Add(rawMessage, email);
                    }
                    else if (messageId.StartsWith("S"))
                    {
                        SmsMessage sms = new SmsMessage(sender, body);
                        messages.Add(rawMessage, sms);
                    }
                    else if (messageId.StartsWith("T"))
                    {
                        TweetMessage tweet = new TweetMessage(sender, body);
                        messages.Add(rawMessage, tweet);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return messages;
        }

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