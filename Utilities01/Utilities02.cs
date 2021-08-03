using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Utilities
{
    public class Utilities02
    {
        public int SampleMethod(int param1)
        {
            return param1 - 3;
        }

        ///<summary>Takes in a string input and reverses the character order of that string</summary>
        ///<param name="source">String input</param>
        ///<returns>Reversed source text</returns>
        public string ReverseString(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                string reversedData = "";

                for (int i = source.Length - 1; i >= 0; i--)
                {
                    reversedData = reversedData + source[i];
                }

                return reversedData;
            }
        }

        ///<summary>Takes in a string input and counts the freqency of letters</summary>
        ///<param name="source">A string comprising a number of words separated by spaces</param>
        ///<returns>A dictionary in which the key is the letter of the alphabet, and the value is the number of occurrences in the text</returns>
        public Dictionary<string, int> LetterFrequencies(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                Dictionary<string, int> letterCount = new Dictionary<string, int>();

                foreach (char character in source.ToLower())
                {
                    if (char.IsLetter(character))
                    {
                        if (letterCount.ContainsKey(character.ToString()))
                        {
                            letterCount[character.ToString()]++;
                        }
                        else
                        {
                            letterCount.Add(character.ToString(), 1);
                        }
                    }
                }
                return letterCount;
            }
        }

        ///<summary>Adds spacing between words as needed to ensure that the last character of the last word is exactly at the desired line length</summary>
        ///<param name="source">A string comprising a number of words separated by spaces</param>
        ///<param name="lineLength">The desired length of the formatted line. Must be greater than or equal to the length of the source.</param>
        ///<returns>A string of length lineLength with the same words as the input, but the last character of the last word is exactly at the desired line length</returns>
        public string LineJustify(string source, int lineLength)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                if (lineLength < source.Length)
                {
                    throw new System.ArgumentOutOfRangeException();
                }
                else if (source.Length < lineLength)
                {
                    string[] splitSource = source.Split(' ');
                    int index = 0;
                    int sourceLength = source.Length;
                    do
                    {
                        if (index == splitSource.Length - 1)
                        {
                            index = 0;
                        }
                        splitSource[index] = splitSource[index] + " ";
                        index++;
                        sourceLength++;

                    } while (sourceLength < lineLength);

                    string result = string.Join(" ", splitSource);
                    return result;
                }
                else
                {
                    return source;
                }
            }
        }

        ///<summary>Determines the most common pairings of words in the source</summary>
        ///<param name="source">A string comprising a number of words separated by spaces</param>
        ///<returns>A dictionary in which the keys are bigrams and the values are the frequencies of occurrence of the keys in the source text. Only those bigrams which occur more than once should be included</returns>
        public Dictionary<string, int> GetBigrams(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                Dictionary<string, int> bigramCount = new Dictionary<string, int>();
                StringBuilder builder = new StringBuilder();
                bool previousWhiteSpace = false;

                //Removes all punctuation and excessive whitespaces to cope with error cases.
                foreach (char character in source)
                {
                    if (!char.IsPunctuation(character))
                    {
                        if (char.IsWhiteSpace(character))
                        {
                            if (previousWhiteSpace == false)
                            {
                                builder.Append(character);
                                previousWhiteSpace = true;
                            }
                        }
                        else
                        {
                            builder.Append(character);
                            previousWhiteSpace = false;
                        }
                    }
                }

                source = builder.ToString().ToLower();

                string[] splitSource = source.Split(' ');
                string bigram, firstWord, secondWord;
                int index = 0;

                do
                {
                    firstWord = splitSource[index];
                    secondWord = splitSource[index + 1];
                    bigram = firstWord + " " + secondWord;

                    if (bigramCount.ContainsKey(bigram))
                    {
                        bigramCount[bigram]++;
                    }
                    else
                    {
                        bigramCount.Add(bigram, 1);
                    }

                    index++;
                } while (index < splitSource.Length - 1);

                foreach (KeyValuePair<string, int> entry in bigramCount)
                {
                    if (entry.Value < 2)
                    {
                        bigramCount.Remove(entry.Key);
                    }
                }
                return bigramCount;
            }
        }


        ///<summary>Adds HTML tags to make certain parts italic in the source text</summary>
        ///<param name="source">A string comprising a number of words separated by spaces</param>
        ///<returns>A string of properly formatted HTML in which each some words or pasasages are wrapped with html "em" tags</returns>
        public string Italicize(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw (new ArgumentNullException());
            }
            else
            {
                StringBuilder builder = new StringBuilder(source);
                string openingTag = "<em>";
                string closingTag = "</em>";
                int firstOccurance = 0;
                int secondOccurance = 0;
                int i = 0;
                bool replace = false;
                char[] endOfLineChar = { '.', '!', '?' };

                do
                {
                    if (builder[i] == '/')
                    {
                        if (replace == false)
                        {
                            //If the first '/' is either the first element or is preceeded by a whitespace then do...
                            if (i == 0 || i - 1 > 0 && char.IsWhiteSpace(builder[i - 1]))
                            {
                                //If the next character after the starting '/' is not a whitespace then do...
                                if (i + 1 < builder.Length && !char.IsWhiteSpace(builder[i + 1]))
                                {
                                    firstOccurance = i;
                                    replace = true;
                                }
                            }
                        }
                        else
                        {
                            //If the character before the ending '/' is not a whitespace then do...
                            if (!char.IsWhiteSpace(builder[i - 1]))
                            {
                                //If the charcter after the ending '/' is either a whitespace or an end of line punctuation character then do...
                                if (i + 1 < builder.Length && char.IsWhiteSpace(builder[i + 1]) || i + 1 < builder.Length && endOfLineChar.Contains(builder[i + 1]))
                                {
                                    secondOccurance = i + 3;
                                    builder.Remove(firstOccurance, 1);
                                    builder.Insert(firstOccurance, openingTag);
                                    builder.Remove(secondOccurance, 1);
                                    builder.Insert(secondOccurance, closingTag);
                                    //Adds 9 characters on by adding the "em" tags
                                    i = i + 8;
                                }
                            }
                            replace = false;
                        }
                    }
                    i++;
                } while (i < builder.Length);

                return builder.ToString();
            }
        }
    }
}