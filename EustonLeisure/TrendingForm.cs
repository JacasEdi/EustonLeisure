using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EustonLeisure
{
    /// <summary>
    /// Stores list of hashtags obtained from Tweet messages and displays them to the user.
    /// </summary>
    public partial class TrendingForm : Form
    {
        public static List<string> HashTags = new List<string>();

        public TrendingForm()
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();

            // count number of uses for each hashtag and sort them from most to least used
            var groupedHashtags = HashTags.GroupBy(hashtag => hashtag)
                .Select(countedTag => new { Hashtag = countedTag.Key, HashtagCount = countedTag.Count() })
                .OrderByDescending(countedTag => countedTag.HashtagCount);

            foreach (var hashtag in groupedHashtags)
            {
                sb.AppendLine(hashtag.Hashtag + ": " + hashtag.HashtagCount);
            }

            tbHashtags.Text = sb.ToString();
            tbHashtags.SelectionStart = 0;
        }
    }
}
