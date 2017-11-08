namespace EustonLeisure
{
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