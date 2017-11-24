using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EustonLeisure
{
    /// <summary>
    /// Stores list of serious incidents obtained from SIR emails and displays them to the user.
    /// </summary>
    public partial class SirForm : Form
    {
        public static List<SeriousIncident> SeriousIncidents = new List<SeriousIncident>();

        public SirForm()
        {
            InitializeComponent();
            tbIncidents.ScrollBars = ScrollBars.Vertical;

            StringBuilder sb = new StringBuilder();

            foreach (var incident in SeriousIncidents)
            {
                sb.AppendLine(incident.ToString());
                sb.AppendLine();
            }

            tbIncidents.Text = sb.ToString();
            tbIncidents.SelectionStart = 0;
        }
    }
}
