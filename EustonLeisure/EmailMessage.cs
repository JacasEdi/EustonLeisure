using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EustonLeisure
{
    internal class EmailMessage : Message
    {
        // assign an id to each new instance of a class
        private static int _idCounter = 100000000;

        public override string MessageId { get; set; }
        public override string Sender { get; set; }
        public string Subject { get; set; }
        public override string Body { get; set; }

        protected override bool IsValid(string sender, string message)
        {
            return false;
        }

        // check whether input is valid for an e-mail message
        private bool IsValid(string sender, string subject, string message)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(sender);

                return subject.Length <= 20 && message.Length <= 1028;
            }
            catch
            {
                return false;
            }
        }

        public EmailMessage(string sender, string subject, string message)
        {
            if (subject.StartsWith("SIR"))
            {
                //TODO stick some static ValidateSir(sender, subject, message) method here and delete SirEmailMessage class
                SirEmailMessage sirEmail = new SirEmailMessage(sender, subject, message);
            }
            else
            {
                // if input is invalid, do not create the object and throw an exception instead
                if (!IsValid(sender, subject, message))
                {
                    throw new ArgumentException("Invalid input");
                }
            }

            Sender = sender;
            Subject = subject;
            Body = QuarantineUrls(message);
            MessageId = "E" + _idCounter++;
        }

        private string QuarantineUrls(string message)
        {
            Regex regex = new Regex(@"(http|ftp|https)://([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?");
            Match match = regex.Match(message);

            StringBuilder sb = new StringBuilder(message);

            while (match.Success)
            {
                string urlToQuarantine = message.Substring(match.Index, match.Length);

                sb.Replace(urlToQuarantine, "<URL Quarantined>");
                match = match.NextMatch();
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"Message Id: {MessageId}\r\nSender: {Sender}\r\nSubject: {Subject}\r\nMessage: {Body}";
        }
    }
}