using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EustonLeisure
{
    /// <summary>
    /// Stores list of mentions obtained from Tweet messsages and displays them to the user.
    /// </summary>
    public partial class MentionsForm : Form
    {
        public static List<string> Mentions = new List<string>();

        public MentionsForm()
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();

            var groupedMentions = Mentions.GroupBy(twitterId => twitterId)
                .Select(countedMentions => new { TwitterId = countedMentions.Key, MentionCount = countedMentions.Count()})
                .OrderByDescending(mention => mention.MentionCount);

            foreach (var mention in groupedMentions)
            {
                sb.AppendLine(mention.TwitterId + ": " + mention.MentionCount);
            }

            tbMentions.Text = sb.ToString();
            tbMentions.SelectionStart = 0;
        }
    }
}
