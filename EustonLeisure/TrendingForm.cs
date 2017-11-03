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
    public partial class TrendingForm : Form
    {
        public static List<String> HashTags = new List<String>();

        public TrendingForm()
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();

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
