using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class Utilities04
    {
        ///<summary>This takes a string input and splits it into HTML paragraphs by splitting at each '.' and then adding the <p></p> tags</summary>
        ///<param name="source">String input</param>
        ///<returns>A string of text seperated by <p></p> tags</returns>
        public string AddParaHtml(string source) //Daniel Szabo. I have changed the name AddParaHTML to AddParaHtml. Becouse it did not fuction properly so it did not allow the program to compile.
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                if (source.Contains('.'))
                {
                    string[] sentences = source.Split('.');
                    string[] paragraphs = new string[sentences.Length];
                    for (int i = 0; i < sentences.Length - 1; i++)
                    {
                        sentences[i] = sentences[i].TrimStart();
                        char[] ch = sentences[i].ToCharArray();
                        ch[0] = Char.ToUpper(ch[0]);
                        string newstring = new string(ch);
                        paragraphs[i] = "<p>" + newstring + "." + "</p>";
                        Console.WriteLine(paragraphs[i]);
                    }
                    return string.Join("", paragraphs);
                }
                else
                {
                    string[] paragraphs = new string[1];
                    char[] ch = source.ToCharArray();
                    ch[0] = Char.ToUpper(ch[0]);
                    string newstring = new string(ch);
                    paragraphs[0] = "<p>" + newstring + "." + "</p>";
                    return string.Join("", paragraphs);
                }
            }
        }

        ///<summary>This takes a string input, splits it at each '.' and then adds each paragraph to a string list</summary>
        ///<param name="source">String input</param>
        ///<returns>A List of properly formatted paragraphs.</returns>
        public List<string> Paragraphs(string source)
            {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                List<string> paras = new List<string>();
                string[] split = source.Split('.');

                for (int i = 0; i < split.Length - 1; i++)
                {
                    split[i] = split[i].TrimStart();
                    char[] ch = split[i].ToCharArray();
                    ch[0] = Char.ToUpper(ch[0]);
                    string newstring = new string(ch);
                    paras.Add(newstring + ".");
                }
                return paras;
            }

            }

        ///<summary>This takes a string input of a sentence, it then reverses the order of the words (i.e. first word would now be last)</summary>
        ///<param name="source">String input</param>
        ///<returns>A string of text which is the input but reversed</returns>
        public string ReverseWords(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                string[] sentences = source.Split('.');
                string temp;
                string[] words = sentences[0].Split(' ');
                char[] ch = words[0].ToCharArray();
                ch[0] = Char.ToLower(ch[0]);
                words[0] = new string(ch);

                char[] ch2 = words[words.Length - 1].ToCharArray();
                ch2[0] = Char.ToUpper(ch2[0]);
                words[words.Length - 1] = new string(ch2);
                for (int i = 0; i < (words.Length / 2); i++)
                {
                    temp = words[i];
                    words[i] = words[(words.Length - 1) - i];
                    words[(words.Length - 1) - i] = temp;
                }
                string combine = string.Join(" ", words);
                return (combine + ".");
            }
        }


        ///<summary>This takes a string input and translates it into pig latin</summary>
        ///<param name="source">String input</param>
        ///<returns>A string of correctly formatted pig latin</returns>
        public string Translate(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                const string vowels = "aeiouAEIOU";
                char[] capitals = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                string[] words = source.Split(' ');
                string[] pigWords = new string[words.Length];
                for (int i = 0; i < words.Length; i++)
                {
                    bool comma = false;
                    bool fullStop = false;
                    bool cap = false;
                    if (words[i].Contains(","))
                    {
                        char[] remover = words[i].ToCharArray();
                        for (int j = 0; j < remover.Length; j++)
                        {
                            if (remover[j] == ',') { words[i] = words[i].Remove(j, 1); }
                        }
                        comma = true;
                    }
                    else if (words[i].Contains("."))
                    {
                        char[] remover = words[i].ToCharArray();
                        for (int j = 0; j < remover.Length; j++)
                        {
                            if (remover[j] == '.') { words[i] = words[i].Remove(j, 1); }
                        }
                        fullStop = true;
                    }
                    char[] ch = words[i].ToCharArray();

                    foreach (char c in capitals)
                    {
                        if (ch[0] == c)
                        {
                            ch[0] = Char.ToLower(ch[0]);
                            cap = true;
                        }
                    }
                    if (ch.Length > 2)
                    {
                        int firstLetter = vowels.IndexOf(ch[0]);
                        int secondLetter = vowels.IndexOf(ch[1]);
                        int thirdLetter = vowels.IndexOf(ch[2]);
                        string word = words[i];
                        StringBuilder builder = new StringBuilder(word);
                        builder.Remove(0, 3);
                        word = builder.ToString();
                        string restOfWord = word;
                        if (firstLetter == -1)
                        {
                            if (ch[0] == 'y') { pigWords[i] = words[i] + "yay"; }
                            else if (secondLetter == -1)
                            {
                                if (thirdLetter == -1) { pigWords[i] = restOfWord + ch[0].ToString() + ch[1].ToString() + ch[2].ToString() + "ay"; }
                                else { pigWords[i] = ch[2].ToString() + restOfWord + ch[0].ToString() + ch[1].ToString() + "ay"; }
                            }
                            else { pigWords[i] = ch[1].ToString() + ch[2].ToString() + restOfWord + ch[0].ToString() + "ay"; }
                        }
                        else if (firstLetter != -1) { pigWords[i] = words[i] + "yay"; }
                        else { pigWords[i] = ch[1].ToString() + ch[2].ToString() + restOfWord + ch[0].ToString() + "ay"; }
                    }
                    else if (ch.Length == 2)
                    {
                        int firstLetter = vowels.IndexOf(ch[0]);
                        int secondLetter = vowels.IndexOf(ch[1]);
                        if (firstLetter == -1)
                        {
                            if (secondLetter == -1) { pigWords[i] = words[i] + "yay"; }
                            else { pigWords[i] = ch[1].ToString() + ch[0].ToString() + "ay"; }
                        }
                        else { pigWords[i] = words[i] + "yay"; }
                    }
                    else if (ch.Length == 1)
                    {
                        int firstLetter = vowels.IndexOf(ch[0]);
                        if (firstLetter == -1)
                        {
                            if (ch[0] == 'y') { pigWords[i] = ch[0].ToString() + "yay"; }
                            else { pigWords[i] = ch[0].ToString() + "ay"; }
                        }
                        else { pigWords[i] = words[i] + "yay"; }
                    }

                    if (comma == true)
                    {
                        pigWords[i] = pigWords[i] + ",";
                        comma = false;
                    }
                    else if (fullStop == true)
                    {
                        pigWords[i] = pigWords[i] + ".";
                        fullStop = false;
                    }

                    if (cap == true)
                    {
                        char[] capitalize = pigWords[i].ToCharArray();
                        capitalize[0] = Char.ToUpper(capitalize[0]);
                        pigWords[i] = new string(capitalize);
                    }
                }
                return string.Join(" ", pigWords);
            }
        }

        ///<summary>This takes a string input and counts the number of words in a sentence and how many other sentences in the source share this length</summary>
        ///<param name="source">String input</param>
        ///<returns>A dictionary where the key is the sentence length and the value is the number of sentences sharing this length</returns>
        public Dictionary<int, int> SentenceLengths(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                Dictionary<int, int> Lengths = new Dictionary<int, int>();
                string[] sentences = source.Split('.');
                int[] wordCounts = new int[sentences.Length - 1];

                for (int i = 0; i < sentences.Length - 1; i++)
                {
                    sentences[i] = sentences[i].TrimStart();
                    string[] words = sentences[i].Split(' ');
                    int Counters = words.Length;
                    wordCounts[i] = Counters;
                }

                for (int i = 0; i < wordCounts.Length; i++)
                {
                    int matchingNum = 1;
                    for (int j = 0; j < wordCounts.Length; j++)
                    {
                        if (j == i)
                        {
                            continue;
                        }
                        else if (wordCounts[i] == wordCounts[j])
                        {
                            matchingNum = matchingNum + 1;
                        }

                    }
                    if (Lengths.ContainsKey(wordCounts[i])) { continue; }
                    else { Lengths.Add(wordCounts[i], matchingNum); }

                }
                return Lengths;
            }
        }
    }
}
