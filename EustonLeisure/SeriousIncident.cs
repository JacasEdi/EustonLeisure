using System.Collections.Generic;

namespace EustonLeisure
{
    /// <summary>
    /// Class that represents serious incident that can be reported in SIR email message. It stores values of Centre Code
    /// and Nature of Incident from that SIR message so that they can later be added to a list and displayed in SirForm.
    /// </summary>
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            SeriousIncident sir = (SeriousIncident) obj;

            return this.CentreCode.Equals(sir.CentreCode) && this.NatureOfIncident.Equals(sir.NatureOfIncident);
        }

        public override int GetHashCode()
        {
            var hashCode = 1491410396;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CentreCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NatureOfIncident);
            return hashCode;
        }
    }
}