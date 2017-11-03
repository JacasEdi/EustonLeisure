using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EustonLeisure
{
    public partial class MentionsForm : Form
    {
        public static List<String> Mentions = new List<string>();

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
