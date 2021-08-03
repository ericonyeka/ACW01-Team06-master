using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Utilities;

namespace MultiUtility
{
    // Students must not edit this file
    public class ExtraUtilities
    {

        private Utilities01 utility1 = new Utilities01();
        private Utilities02 utility2 = new Utilities02();
        private Utilities03 utility3 = new Utilities03();
        private Utilities04 utility4 = new Utilities04();
        private Utilities05 utility5 = new Utilities05();

        public string ReverseSortWords(string data)
        {
            return utility4.ReverseWords(utility3.SortWords(data));
        }

        public string GetNthSentence(string data, int n)
        {
            var sentences = utility3.Sentences(data);
            if (sentences.Count >= n)
            {
                return sentences[n-1];
            }
            return null;
        }

        public string GetNthLine(string source, int lineLength, int n)
        {
            var lines = utility1.TextLines(source,lineLength);
            return lines[n];

        }

        public string HighlightTopWords(string source, int n)
        {
            var frequencies = utility1.WordFrequencies(source);
            var best = frequencies.OrderByDescending(x => x.Value).Take(n);
            var bestWords = string.Join(" ",best.Select(x => x.Key));
            var results = utility1.EmboldenWords(source, bestWords);
            return results;
            
        }

        public double CheckComplexity(string source)
        {
            var complexity = utility1.GetComplexity(source);
            return complexity;
        }

        public string GetJustifiedText(string source, int lineLength)
        {
            var lines = utility1.TextLines(source, lineLength);
            var formattedLines = new List<string>();
            foreach(var line in lines)
            {
                formattedLines.Add(utility2.LineJustify(line, lineLength));
            }
            return string.Join("|",formattedLines);
        }
    }
}
