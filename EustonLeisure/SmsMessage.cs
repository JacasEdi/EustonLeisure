using System;
using System.Linq;
using System.Text;
using com.google.i18n.phonenumbers;

namespace EustonLeisure
{
    internal sealed class SmsMessage : Message
    {
        // assign an id to each new instance of a class
        private static int _idCounter = 100000000;

        public override string MessageId { get; set; }
        public override string Sender { get; set; }
        public override string Body { get; set; }

        protected override bool IsValid(string sender, string message)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.getInstance();
            bool isValid = false;

            try
            {
                Phonenumber.PhoneNumber phoneNumber = phoneUtil.parse(sender, "GB");
                isValid = phoneUtil.isValidNumber(phoneNumber);
            }
            catch (NumberParseException e)
            {
                Console.WriteLine(e.ToString());
            }

            return isValid && message.Length <= 140;
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

            MessageId = "S" + _idCounter++;
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

        public override string ToString()
        {
            return $"Message Id: {MessageId}\r\nSender: {Sender}\r\nMessage: {Body}";
        }
    }
}