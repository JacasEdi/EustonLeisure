using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EustonLeisure
{
    internal sealed class EmailMessage : Message
    {
        private static readonly List<string> Incidents = new List<string>
        {
            "theft of properties", "staff attack", "device damage", "sport injury", "personal info leak",
            "raid", "customer attack", "staff abuse", "bomb threat", "terrorism", "suspicious incident"
        };
        private string _centreCode;
        private string _natureOfIncident;

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

        public EmailMessage(string sender, string subject, string message)
        {
            if (subject.StartsWith("SIR"))
            {
                // if input is invalid, do not create the object and throw an exception instead
                if (!IsSirEmailValid(sender, subject, message))
                {
                    throw new ArgumentException("Invalid input");
                }

                SirForm.SeriousIncidents.Add(new SeriousIncident(_centreCode, _natureOfIncident));
            }
            else
            {
                // if input is invalid, do not create the object and throw an exception instead
                if (!IsEmailValid(sender, subject, message))
                {
                    throw new ArgumentException("Invalid input");
                }
            }

            Sender = sender;
            Subject = subject;
            Body = QuarantineUrls(message);
            MessageId = "E" + _idCounter++;
        }

        // checks whether input is valid for a standard e-mail message
        private static bool IsEmailValid(string sender, string subject, string message)
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
       
        // checks whether input is valid for a SIR e-mail message
        private bool IsSirEmailValid(string sender, string subject, string message)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(sender);

                bool validSubject = ValidateSirSubject();
                bool validMessage = ValidateSirMessage();

                return validSubject && validMessage;
            }
            catch
            {
                return false;
            }

            bool ValidateSirSubject()
            {
                bool validDate = DateTime.TryParseExact(subject.Substring(4), "d'/'M'/'yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt);

                return subject.StartsWith("SIR ") && validDate;
            }

            bool ValidateSirMessage()
            {
                Regex regex = new Regex(@"^\d{2}-\d{3}-\d{2}");
                Match match = regex.Match(message);

                StringReader strReader = new StringReader(message);

                try
                {
                    _centreCode = strReader.ReadLine();
                    _natureOfIncident = strReader.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return match.Success && Incidents.Any(incident => _natureOfIncident.Equals(incident, StringComparison.CurrentCultureIgnoreCase));
            }
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