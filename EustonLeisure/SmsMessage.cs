using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EustonLeisure
{
    internal sealed class SmsMessage : Message
    {
        // assign an id to each new instance of a class
        private static int _idCounter = 100000000;

        public override string MessageId { get; set; } = "S" + _idCounter++;
        public override string Sender { get; set; }
        public override string Body { get; set; }

        // check whether input is valid for sms
        protected override bool IsValid(string sender, string message)
        {
            return Int64.TryParse(sender, out long result) && message.Length <= 140;
        }

        public SmsMessage(string sender, string message)
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
    }
}