using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EustonLeisure
{
    /// <summary>
    /// Class that handles validation and processing of Tweet messages. It checks whether input is valid 
    /// for a Tweet message before creating and processing it.
    /// </summary>
    public sealed class TweetMessage : Message
    {
        // assign an id to each new instance of a class
        private static int _idCounter = 100000000;

        public override string MessageId { get; set; }
        public override string Sender { get; set; }
        public override string Body { get; set; }

        /// <summary>
        /// Checks whether input is valid for a Tweet message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns>Returns true for valid message and false if it's invalid.</returns>
        protected override bool IsValid(string sender, string message)
        {
            Regex regex = new Regex(@"(^|[^@\w])@(\w{1,15})\b");
            Match match = regex.Match(sender);

            return match.Success && message.Length <= 140;
        }

        /// <summary>
        /// Constructor for a TweetMessage. It will only create a new message if input is valid, otherwise throws an exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public TweetMessage(string sender, string message)
        {
            // if input is invalid, do not create the object and throw an exception instead
            if (!IsValid(sender, message))
            {
                throw new ArgumentException("Invalid input");
            }

            Sender = sender;
            Body = ProcessMessage(message);

            MessageId = "T" + _idCounter++;
        }

        /// <summary>
        /// Passes the message body to relevant methods that handle processing of it.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns processed message.</returns>
        private string ProcessMessage(string message)
        {
            message = ExpandTextwords(message);
            ExtractHashtags(message);
            ExtractMentions(message);

            return message;
        }

        /// <summary>
        /// Searches for textspeak abbreviations in a Tweet message and appends expanded form to its body.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns message body with expanded abbreviations.</returns>
        private string ExpandTextwords(string message)
        {
            StringBuilder sb = new StringBuilder(message);

            foreach (var textword in MainForm.Textwords)
            {
                if (!message.Contains(textword.Key)) continue;

                string abbreviation = textword.Key;
                string fullVersion = textword.Value;
                char characterBefore = ' ';

                if (message.IndexOf(abbreviation, StringComparison.Ordinal) != 0)
                    characterBefore = message.ElementAt(message.IndexOf(abbreviation, StringComparison.Ordinal) - 1);

                if (characterBefore.Equals(' '))
                    sb.Replace(abbreviation, abbreviation + " <" + fullVersion + ">");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Searches for hashtags in a Tweet message and adds them to a list.
        /// </summary>
        /// <param name="message"></param>
        private void ExtractHashtags(string message)
        {
            Regex regex = new Regex(@"(?<=\s|^)#(\w*[A-Za-z_]+\w*)");
            Match match = regex.Match(message);

            while (match.Success)
            {
                TrendingForm.HashTags.Add(match.Value);
                match = match.NextMatch();
            }
        }

        /// <summary>
        /// Searches for mentions in a Tweet message and adds them to a list.
        /// </summary>
        /// <param name="message"></param>
        private void ExtractMentions(string message)
        {
            Regex regex = new Regex(@"(?<=^|(?<=[^a-zA-Z0-9-_\\.]))@([A-Za-z]+[A-Za-z0-9_]+)");
            Match match = regex.Match(message);

            while (match.Success)
            {
                MentionsForm.Mentions.Add(match.Value);
                match = match.NextMatch();
            }
        }

        public override string ToString()
        {
            return $"Message Id: {MessageId}\r\nSender: {Sender}\r\nMessage: {Body}";
        }
    }
}