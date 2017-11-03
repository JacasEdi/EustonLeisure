using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EustonLeisure
{
    internal sealed class TweetMessage : Message
    {
        // assign an id to each new instance of a class
        private static int _idCounter = 100000000;

        public override string MessageId { get; set; } = "T" + _idCounter++;
        public override string Sender { get; set; }
        public override string Body { get; set; }

        // check whether input is valid for a tweet
        protected override bool IsValid(string sender, string message)
        {
            if (sender.StartsWith("@") && sender.Length <= 16 && message.Length <= 140)
                return true;

            return false;
        }

        public TweetMessage(string sender, string message)
        {
            // if input is invalid, do not create the object and throw an exception instead
            if (!IsValid(sender, message))
            {
                throw new ArgumentException("Invalid input");
            }

            Sender = sender;
            Body = ProcessMessage(message);
        }

        private string ProcessMessage(string message)
        {
            message = ExpandTextwords(message);
            ExtractHashtags(message);
            ExtractMentions(message);

            return message;
        }

        private string ExpandTextwords(string message)
        {
            StringBuilder sb = new StringBuilder(message);

            foreach (var textword in Form1.Textwords)
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

    }
}