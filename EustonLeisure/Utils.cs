using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace EustonLeisure
{
    public class Utils
    {
        public static Dictionary<string, string> GetTextwords()
        {
            Dictionary<string, string> textwords = new Dictionary<string, string>();

            var path = @"C:\Napier\Software Engineering\coursework\textwords.csv";

            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    string abbreviation = fields[0];
                    string fullForm = fields[1];
                    textwords.Add(abbreviation, fullForm);
                }
            }

            return textwords;
        }

        private void SaveToJson(Person p)
        {
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"C:\Napier\Software Engineering\messages.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, p);
            }
        }

    }
}