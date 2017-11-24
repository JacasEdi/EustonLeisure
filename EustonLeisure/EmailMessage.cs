using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EustonLeisure
{
    /// <summary>
    /// Class that handles validation and processing of Email messages. It checks what kind of Email message it 
    /// is intended to be (Standard or Serious Incident Report) and checkes whether input is valid for that type 
    /// before creating and processing it.
    /// </summary>
    public sealed class EmailMessage : Message
    {
        // list of all serious incidents that could be reported in SIR
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

        /// <summary>
        /// Constructor for EmailMessage. It determines whether standard or SIR email is an intended type and will
        /// only create a new message if input is valid for that type, otherwise throws an exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public EmailMessage(string sender, string subject, string message)
        {
            // attempt to create SIR email
            if (subject.StartsWith("SIR"))
            {
                // if input is invalid, do not create the object and throw an exception instead
                if (!IsSirEmailValid(sender, subject, message))
                {
                    throw new ArgumentException("Invalid input");
                }

                SirForm.SeriousIncidents.Add(new SeriousIncident(_centreCode, _natureOfIncident));
            }
            // attempt to create standard email
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

        /// <summary>
        /// Checks whether input is valid for a standard email message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns>Returns true for valid message and false if it's invalid.</returns>
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

        /// <summary>
        /// Checks whether input is valid for a SIR email message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns>Returns true for valid message and false if it's invalid.</returns>
        private bool IsSirEmailValid(string sender, string subject, string message)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(sender);

                bool validSubject = ValidateSirSubject();
                bool validMessage = ValidateSirBody();

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

            bool ValidateSirBody()
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

        /// <summary>
        /// Searches for URLs in email message and replaces them with "URL Quarantined".
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns message body without URLs.</returns>
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