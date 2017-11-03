using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EustonLeisure
{
    internal class SirEmailMessage : EmailMessage
    {
        private static readonly List<string> Incidents = new List<string>
        {
            "theft of properties", "staff attack", "device damage", "sport injury", "personal info leak",
            "raid", "customer attack", "staff abuse", "bomb threat", "terrorism", "suspicious incident"
        };

        private string _centreCode;
        private string _natureOfIncident;

        public SirEmailMessage(string sender, string subject, string message) : base(sender, subject, message)
        {
            if (!IsValid(sender, subject, message))
            {
                throw new ArgumentException("Invalid input");
            }

            SirForm.SeriousIncidents.Add(new SeriousIncident(_centreCode, _natureOfIncident));
        }

        // check whether input is valid for an e-mail message
        private bool IsValid(string sender, string subject, string message)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(sender);

                bool validSubject = ValidateSirSubject(subject);
                bool validMessage = ValidateSirMessage(message);
                
                return validSubject && validMessage;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateSirSubject(string subject)
        {
            bool validDate = DateTime.TryParseExact(subject.Substring(4), "d'/'M'/'yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt);

            return subject.StartsWith("SIR ") && validDate;
        }

        private bool ValidateSirMessage(string message)
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

    public class SeriousIncident
    {
        private string CentreCode { get; set; }
        private string NatureOfIncident { get; set; }

        public SeriousIncident(string centreCode, string natureOfIncident)
        {
            CentreCode = centreCode;
            NatureOfIncident = natureOfIncident;
        }

        public override string ToString()
        {
            return "Centre Code: " + CentreCode + "\r\nNature of Incident: " + NatureOfIncident;
        }
    }
}