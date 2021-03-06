﻿using System;
using System.Text.RegularExpressions;

namespace Assignment37
{
    class TextFileSearcher
    {
#region Fields
        private readonly string URLRegex = @"((http|https)://)\w+.\w+(\S)*";
        private readonly string DateRegex = @"(Mon|Tue|Wed|Thur|Fri|Sat|Sun), (\d{2}) (Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec) \d{1,4} (\d{2}:?){3}";
#endregion

        public TextFileSearcher(string text)
        {
            Text = text;
            TextChar = Text.ToCharArray();
        }

        /// <summary>
        /// Run the TextFileSearcher
        /// </summary>
        public void Run()
        {
            string searchString = "";
            while (true)
            {
                if (searchString.Equals("exit system")) { break; }
                MatchCollection matches = ProcessInput(searchString, Text);
                WriteText(matches);
                searchString = Console.ReadLine().ToLower();
                Console.Clear();
            }
        }

        /// <summary>
        /// Process the RE and the text
        /// </summary>
        /// <param name="keyword">The keyword(s) to be highlighted</param>
        public MatchCollection ProcessInput(string keyword, string text)
        {
            //If there are no keyword, don't include it in the RE
            if (keyword.Equals("") || keyword == null)
            {
                RE = "(" + URLRegex + ")|(" + DateRegex + ")";
            }
            else
            {
                if (keyword.Contains("+"))
                {
                    //Split the string around the "+" and concatenate the two
                    //strings in order to highlight them.
                    string[] arr = keyword.Split('+');
                    keyword = arr[0].Trim() + " " + arr[1].Trim();
                }
                else if (keyword.StartsWith("*"))
                {
                    //Replace the "*" with nothing and define the keyword as RE
                    keyword = keyword.Replace("*", "");
                    keyword = @"\w+" + keyword + @"\b";
                }
                else if (keyword.EndsWith("*"))
                {
                    //Replace the "*" with nothing and define the keyword as RE
                    keyword = keyword.Replace("*", "");
                    keyword = @"\b" + keyword + @"\w+\b";
                }
                //Set the RE
                RE = "(" + URLRegex + ")|(" + DateRegex + @")|(\b" + keyword + @"\b)";
            }
            //Find all matches and print the text
            return Regex.Matches(text, RE, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Write the text to the console, coloring the URLs, Dates and keywords searched for
        /// </summary>
        private void WriteText(MatchCollection matches)
        {
            //Index to keep track of the current Match
            int index = 0;
            for (int i = 0; i < TextChar.Length; i++)
            {
                //If we still have unprocessed Matches
                if (index < matches.Count)
                {
                    //If we're currently printing a Match
                    if (matches[index].Index <= i)
                    {
                        //Groups[1] is the URL group
                        if (matches[index].Groups[1].Success)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        //Groups[5] is the Date group
                        else if (matches[index].Groups[5].Success)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        //Groups[10] is the Keyword group
                        else if (matches[index].Groups[10].Success)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                        }
                    }
                }
                //Reset the color and increment index if we're done writing the current Match
                if (index < matches.Count && matches[index].Index + matches[index].Length == i)
                {
                    index++;
                    Console.ResetColor();
                }
                //Write the next char
                Console.Write(TextChar[i]);
            }
        }

#region Properties
        /// <summary>
        /// The Regular Expression
        /// </summary>
        private string RE
        {
            get;
            set;
        }
        /// <summary>
        /// The text as a single string
        /// </summary>
        private string Text
        {
            get;
            set;
        }
        /// <summary>
        /// The text as a char array
        /// </summary>
        private char[] TextChar
        {
            get;
            set;
        }
#endregion
    }
}