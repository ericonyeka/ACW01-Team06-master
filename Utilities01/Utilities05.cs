using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public class Utilities05
    {
        public string ProperNouns(string source)
        {
            string properNouns = "";

            var WordsinSource = source.Split(' ');
            var distinctWords = WordsinSource.Select(x => x).Distinct();
            WordsinSource = distinctWords.ToArray();
            for (int i = 1; i < WordsinSource.Length; i++)
            {
                if (char.IsUpper(WordsinSource[i].ToCharArray()[0]))
                {
                    properNouns += WordsinSource[i] + " ";
                }
            }

            return properNouns.TrimEnd(properNouns[^1]);
        }

        public string DistinctWords(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }

            var words = source.Split(' ');
            var distinctWords = words.Select(x => x).Distinct();

            
            var output= distinctWords.Aggregate("", (current, word) => current + (word + " "));
            return output.TrimEnd(output[^1]);
        }

        public string LineCentre(string source, int lineLength)
        {
            if (lineLength < source.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            var words = source.Split(' ');
            int spacesUsed = 0;
            string output = "";
            foreach (var word in words)
            {
                spacesUsed += word.Length + 1;
                output += " " + word;
            }

            {
                output += " ";
                spacesUsed += 1;
            }

            var spacesLeft = lineLength - spacesUsed;

            for (var i = 0; i < spacesLeft; i++)
            {
                output = spacesLeft % 2 == 1 ? output.Insert(output.Length - 1, " ") : output.Insert(0, " ");
            }

            return output;
        }

        public string MakeTable(Dictionary<string, int> data)
        {
            string output = "<table>";
            foreach (var pair in data)
            {
                output += "<tr><td>" + pair.Key + "</td></tr>";
            }
            output += "</table>";
            return output;
        }

        public Dictionary<int, string> FindContext(string source, string targetWords)
        {
            throw new NotImplementedException();
        }
    }
}