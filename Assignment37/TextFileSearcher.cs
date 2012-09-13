using System;
using System.Text.RegularExpressions;

namespace Assignment37
{
    class TextFileSearcher
    {
        public TextFileSearcher(string text)
        {
            Text = text;
            ProcessText();
        }

        private void ProcessText()
        {
            string URLRegex = @"((http|https)://)(\w+.?/?~?)+";
            URLs = Regex.Matches(Text, URLRegex, RegexOptions.IgnoreCase);
            string DateRegex = @"(Mon|Tue|Wed|Thur|Fri|Sat|Sun), (\d{2}) (Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec) \d{4} (\d{2}:?){3}";
            Dates = Regex.Matches(Text, DateRegex, RegexOptions.IgnoreCase);
        }

        public string ReadUserInput()
        {
            return Console.ReadLine();
        }

        public void WriteText(string keyword)
        {
            //Bools to see if we have unprocessed matches
            bool URLsDone = false;
            bool DatesDone = false;
            bool HighlightDone = false;
            //Counters for each of the matches
            int u = 0;
            int d = 0;
            int h = 0;

            Match latestMatch = null;
            
            //Process every match
            while (u < URLs.Count | d < Dates.Count | h < Highlights.Count)
            {
                if (u == URLs.Count)        { URLsDone      = true; }
                if (d == Dates.Count)       { DatesDone     = true; }
                if (h == Highlights.Count)  { HighlightDone = true; }

                if(
                
                if ((DatesDone && !URLsDone) || URLs[u].Index < Dates[d].Index)
                {
                    if (latestMatch == null)
                    {
                        Console.Write(Text.Substring(0, URLs[u].Index));
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Text.Substring(URLs[u].Index, URLs[u].Length));
                        latestMatch = URLs[u++];
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(Text.Substring(latestMatch.Index + latestMatch.Length,
                                                     URLs[u].Index - (latestMatch.Index + latestMatch.Length)));
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Text.Substring(URLs[u].Index, URLs[u].Length));
                        latestMatch = URLs[u++];
                    }
                }
                else if(!DatesDone)
                {
                    if (latestMatch == null)
                    {
                        Console.Write(Text.Substring(0, Dates[d].Index));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Text.Substring(Dates[d].Index, Dates[d].Length));
                        latestMatch = Dates[d++];
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(Text.Substring(latestMatch.Index + latestMatch.Length,
                                                     Dates[d].Index - (latestMatch.Index + latestMatch.Length)));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Text.Substring(Dates[d].Index, Dates[d].Length));
                        latestMatch = Dates[d++];
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public void HighlightText(string keyword)
        {
            MatchCollection matches = Regex.Matches(Text, keyword, RegexOptions.IgnoreCase);

            Console.Clear();

            if (0 < matches.Count)
            {
                //Write the text until the start of the first match
                Console.Write(Text.Substring(0, matches[0].Index));
                //Loop through the matches
                for (int i = 0; i < matches.Count; i++)
                {
                    //Change the background color of the text
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    //Print match i
                    Console.Write(Text.Substring(matches[i].Index, matches[i].Length));
                    //Reset the colors of the console to the default
                    Console.ResetColor();
                    //If theres still unprocessed matches
                    if (i + 1 < matches.Count)
                    {
                        int start = matches[i].Index + matches[i].Length;
                        //Difference between match i and match i+1
                        int length = matches[i + 1].Index - (matches[i].Index + matches[i].Length);
                        Console.Write(Text.Substring(start, length));
                    }
                    else
                    {
                        Console.Write(Text.Substring(matches[i].Index + matches[i].Length));
                    }
                }
            }
            else
            {
                Console.WriteLine(Text);
            }
        }

        public string Text
        {
            get;
            private set;
        }

        public MatchCollection URLs
        {
            get;
            private set;
        }

        public MatchCollection Dates
        {
            get;
            private set;
        }

        public MatchCollection Highlights
        {
            get;
            private set;
        }
    }
}