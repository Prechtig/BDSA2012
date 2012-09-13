using System;
using System.Text.RegularExpressions;

namespace Assignment37
{
    class Program
    {   
        static void Main(string[] args)
        {
            //Make a new TextFileSearcher
            TextFileSearcher tfs = new TextFileSearcher(TextFileReader.ReadFile(@"..\..\testFile.txt"));
            //Run the TextFileSearcher

            Run(tfs);
        }

        private static void Run(TextFileSearcher tfs)
        {
            //Print the original text
            tfs.WriteText("");
            
            string searchString;
            
            do
            {
                searchString = tfs.ReadUserInput().ToLower();
                tfs.HighlightText(searchString);
            } while (!searchString.Equals("exit system"));
        }
    }
}
