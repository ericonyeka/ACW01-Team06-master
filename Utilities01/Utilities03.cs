using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utilities
{
    public class Utilities03
    {
        public string[] SampleMethod(int param1)
        {
            throw (new NotImplementedException());
        }

        public string[] removeExtraStuffInWords(string[] sourceArray)
        {
            char[] symbols = {'!', '"', '#', '$', '%', '&', (char)40, (char)41, (char)42, (char)43, (char)44, (char)45, (char)46, (char)47, (char)58, (char)59, (char)60, (char)61, (char)62, (char)63, (char)64,
            (char)91, (char)92, (char)93, (char)94, (char)95, (char)96, (char)123, (char)124, (char)125, (char)126, (char)127,};

            for (int i = 0; i < sourceArray.Length; i++) //remove non alphabetic or numeric characters
            {
                sourceArray[i] = sourceArray[i].Trim(symbols);
                for (int j = 0; j < sourceArray[i].Length; j++)
                {
                    for (int l = 0; l < symbols.Length; l++)
                    {
                        if (sourceArray[i][j] == symbols[l])
                        {
                            sourceArray[i] = sourceArray[i].Remove(j);
                            break;
                        }
                    }
                }
            }

            return sourceArray;
        }

        /// <summary>
        /// Sorts the words in a string into alphabetical order
        /// </summary>
        /// <param name="source">String input</param>
        /// <returns>String in alphabetical order</returns>
        public string SortWords(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException();
            }
            else
            {
                string[] sourceArray = source.Split(' '); //Spliting up the string by spaces and puting them into the array
                string empty = "";

                removeExtraStuffInWords(sourceArray);
                
                for (int i = 1; i < sourceArray.Length; i++) //sorting in alphabetical order
                {
                    for (int j = 0; j < sourceArray.Length - 1; j++)
                    {
                        if (sourceArray[j].ToLower() == sourceArray[j + 1].ToLower()) //if the words are the same dont do anything
                        {
                            continue;
                        }
                        int n = 0;  //character number
                        int maxN = 0; //the max lenngth
                        if (sourceArray[j].Length < sourceArray[j + 1].Length) //checks which word is shorter to not go over bounderies
                        {
                            maxN = sourceArray[j].Length - 1;
                        }
                        else
                        {
                            maxN = sourceArray[j + 1].Length - 1;
                        }
                        while (n < maxN && sourceArray[j].ToLower()[n] == sourceArray[j + 1].ToLower()[n]) //check for the starting letters are the same if yes then n++ and check for the next letter
                        {
                            n++;
                        }
                        if (sourceArray[j].ToLower()[n] > sourceArray[j + 1].ToLower()[n] || maxN == n && sourceArray[j].ToLower() != sourceArray[j + 1].ToLower() && sourceArray[j].Length > sourceArray[j + 1].Length) //check which letter comes first then it swaps them up
                        {
                            empty = sourceArray[j];
                            sourceArray[j] = sourceArray[j + 1];
                            sourceArray[j + 1] = empty;
                        }

                    }
                }
                string sourceDone = string.Join(' ', sourceArray); //put the array into a string
                return sourceDone;
            }
        }
        /// <summary>
        /// Separates the source into sentences 
        /// </summary>
        /// <param name="source">A string comprising a number of words separated by spaces.</param>
        /// <returns>A list of strings, each of which represents a sentence in the source, or null</returns>
        public List< string > Sentences(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException();
            }
            else
            {
                char[] capitalLetters = { (char)65, (char)66, (char)67, (char)68, (char)69, (char)70, (char)71, (char)72, (char)73, (char)74, (char)75, (char)76, (char)77, (char)78, (char)79, (char)80,
                    (char)81, (char)82, (char)83, (char)84, (char)85, (char)86, (char)87, (char)88, (char)89, (char)90 };
                char[] terminators = {'.', '?' , '!' };

                List<string> sourceDone = Regex.Split(source, @"(?<=[\.!\?])\s+").ToList(); // split on the white space after the terminator
                if (sourceDone[sourceDone.Count - 1] == "")
                {
                    sourceDone.RemoveAt(sourceDone.Count - 1); // remove last element of the list bc its empty

                }
                
                for (int i = 0; i < sourceDone.Count; i++) //checks for the elemetns of the list if they are sentences
                {
                    bool isCapital = false;
                    bool isTerminator = false;
                    for (int j = 0; j < capitalLetters.Length; j++)//checks for capital letter start
                    {
                        if (sourceDone[i][0] == capitalLetters[j])
                        {
                            isCapital = true;
                        }                        
                    }
                    for (int j = 0; j < terminators.Length; j++)//checks for terminator end
                    {
                        if (sourceDone[i][sourceDone[i].Length - 1] == terminators[j])
                        {
                            isTerminator = true;
                        }
                    }
                    if (isCapital == false || isTerminator == false)
                    {
                        sourceDone.RemoveAt(i);
                    }
                }
                if (sourceDone.Count == 0) //if no senteces in the source return null
                {
                    return null;
                }
                else
                {
                    return sourceDone;
                }
            }
        }

        /// <summary>
        /// Get information on the the length of words in the source 
        /// </summary>
        /// <param name="source">A string comprising a number of words separated by spaces</param>
        /// <returns>A dictionary in which the key is the length of a word in the source text, and the value is the number of words in the source text which have that length.</returns>
        public Dictionary<int, int> WordLengths(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException();
            }
            else
            {
                Dictionary<int, int> sourceDone = new Dictionary<int, int>();

                string[] sourceArray = source.Split(' '); //Spliting up the string by spaces and puting them into the array
                //string empty = "";

                removeExtraStuffInWords(sourceArray);

                for (int i = 0; i < sourceArray.Length; i++) //going through all of the words
                {
                    if (sourceDone.ContainsKey(sourceArray[i].Length)) //if its an existing key then add one more to its value 
                    {
                        sourceDone[sourceArray[i].Length]++;
                    }
                    else //if not then make it with value of 1
                    {
                        sourceDone.Add(sourceArray[i].Length, 1);
                    }
                }

                return sourceDone;
            }
        }

        /// <summary>
        /// Adds HTML heading tags to specific lines in the source text. 
        /// </summary>
        /// <param name="source">A string comprising a number of words separated by spaces.</param>
        /// <returns>A string of properly formatted HTML in which each heading in the source (regardless of case) is wrapped with HTML h2 tags. </returns>
        public string AddHeadings(string source) //Adds HTML heading tags to specific lines in the source text
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException();
            }
            else
            {
                string[] lines = source.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); //spliting source by lines 
                List<string> linesList = lines.ToList(); //adding it to list to make it easier to handle

                for (int i = 0; i < linesList.Count; i++) //checking every line
                {
                    if (linesList[i] == "")
                    {
                        continue;
                    }
                    if (linesList[i][0] == '=' && linesList[i][1] == '=' && linesList[i][2] == '=')// if a line has at least 3 = then we remove it and add the h2 tags for the previus line
                    {
                        linesList.RemoveAt(i);
                        linesList[i - 1] = linesList[i - 1].Insert(0, "<h2>");
                        linesList[i - 1] = linesList[i - 1].Insert(linesList[i - 1].Length, "</h2>");
                    }
                }

                string sourceDone = string.Join("\n", linesList);
                return sourceDone;
            }
        }

        /// <summary>
        /// Determine the positive or negative sentiment of the text 
        /// </summary>
        /// <param name="source">A string comprising a number of words separated by spaces</param>
        /// <param name="goodWords">A string containing words considered positive, separated by spaces</param>
        /// <param name="badWords">A string containing words considered negative, separated by spaces</param>
        /// <returns>A number ranging from -1 to +1 depending on the number of occurrences of words (regardlessof case) considered negative or positive in the source.</returns>
        public double GetSentiment(string source, string goodWords, string badWords)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(goodWords) || string.IsNullOrEmpty(badWords))
            {
                throw new ArgumentNullException();
            }
            else
            {
                string[] sourceArray = source.Split(' ');
                string[] goodWordsArray = goodWords.Split(' ');
                string[] badWordsArray = badWords.Split(' ');

                removeExtraStuffInWords(sourceArray);
                removeExtraStuffInWords(goodWordsArray);
                removeExtraStuffInWords(badWordsArray);

                int numberOfgoodWords = 0;
                int numberOfBadWords = 0;

                for (int i = 0; i < sourceArray.Length; i++) // going trough all of the words
                {
                    for (int j = 0; j < goodWordsArray.Length; j++)
                    {
                        if (sourceArray[i] == goodWordsArray[j])//if its a good words +1 for the numberOfGoodWords
                        {
                            numberOfgoodWords++;
                        }
                    }
                    for (int j = 0; j < badWordsArray.Length; j++)
                    {
                        if (sourceArray[i] == badWordsArray[j])//if its a bad words +1 for the numberOfBadWords
                        {
                            numberOfBadWords++;
                        }
                    }
                }
                double result = 0;
                if (numberOfBadWords == 0 && numberOfgoodWords == 0)
                {
                    result = 0;
                }
                else
                {
                    result = (numberOfgoodWords - numberOfBadWords) / (numberOfgoodWords + numberOfBadWords);
                }
                return result;
            }
        }
    }
}
