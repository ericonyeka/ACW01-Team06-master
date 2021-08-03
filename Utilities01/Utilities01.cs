using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Utilities
{
    public class Utilities01
    {
        public string RemovePunctuation(string InputData)
        {
            char[] charArray = InputData.ToCharArray();//string is split into characters 
            return new string(charArray.Where(c => !char.IsPunctuation(c)).ToArray());//remove all punctuation
        }
        public string Textlined(string InputData, int LineLength)
        {
            if (LineLength < 10)//Do nothing if line length is less than 10
            {
                return "";
            }
            for (int i = LineLength; i < InputData.Length; i += LineLength)
            {//Every (however long LineLength is) charcters, \n is  added in
                InputData = InputData.Insert(i+((i/LineLength) -1), "\n");  
            } //account for the new added string. \n is only worth 1 character
            return InputData;
        }
        public string EmboldenWords(string InputData, string boldWords)
        {
            string[] ArrayofBoldWords = boldWords.Split();//split both strings into arrays
            string[] ListofWords = InputData.Split();
            for (int i = 0; i < ListofWords.Length; i++)
            {
                for (int j = 0; j < ArrayofBoldWords.Length; j++)
                {
                    string TempWord = RemovePunctuation(ListofWords[i]);
                    string TempWord2 = RemovePunctuation(ArrayofBoldWords[j]);
                    if (TempWord.ToLower() == TempWord2.ToLower())
                    {//if word is in list of words to bolden and string given, add bold tags to word. Account for capital letters
                        List<char> Letters = ListofWords[i].ToList();
                        Letters.Insert(ArrayofBoldWords[j].Length,'<');
                        Letters.Insert(ArrayofBoldWords[j].Length+1, '/');
                        Letters.Insert(ArrayofBoldWords[j].Length+2, 'b');
                        Letters.Insert(ArrayofBoldWords[j].Length+3, '>');
                        ListofWords[i] = new string (Letters.ToArray());
                        ListofWords[i] = "<b>" + ListofWords[i];
                    } 
                }
            }
            string Result = string.Join(" ",ListofWords);
            return Result;
        }

        public List<string> TextLines(string source, int lineLength) //Daniel Szabo. Added it to let the program compile
        {
            throw new NotImplementedException();
        }

        public Dictionary<string,int> WordFrequencies(string InputData)
        {
            InputData = RemovePunctuation(InputData);
            InputData = InputData.ToLower();//remove punctuation and capital letters
            string[] ListofWords = InputData.Split();
            Dictionary<string, int> Words = new Dictionary<string, int>();
            for (int i = 0; i < ListofWords.Length; i++)
            {
                if (Words.ContainsKey(ListofWords[i]))
                {
                    Words[ListofWords[i]] += 1;
                }
                else
                {
                    Words.Add(ListofWords[i],1);//initial word count set to 1
                }
            }
            return Words;
        }
        public double GetComplexity(string InputData)
        {
            InputData.Replace("...",".");
            char[] charArray = InputData.ToCharArray();//string is split into characters
            InputData = new string(charArray.Where(c => !char.IsPunctuation(c) || c == '.' || c == '!' || c == '?').ToArray());
            double TotalCharacters = 0;//remove all punctuation other than fullstops//bug, removes full stops
            string[] ArrayofWords = InputData.Split();
            for (int i = 0; i < ArrayofWords.Length; i++)
            {
                TotalCharacters += ArrayofWords[i].ToCharArray().Length;//Take away the full stops total later
            }
            double TotalSentences = 0;
            for (int i = 0; i < ArrayofWords.Length; i++)
            {
                charArray = ArrayofWords[i].ToCharArray();
                for (int j = 0; j < charArray.Length; j++)
                {
                    if (charArray[j]=='.' || charArray[j] == '?' || charArray[j] == '!')
                    {
                        TotalSentences += 1;
                    }
                }
            }
            if (TotalSentences == 0){TotalSentences = 1;}
            return (TotalCharacters-TotalSentences)/TotalSentences;
        }
    }
}
