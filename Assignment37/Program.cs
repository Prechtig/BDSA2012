using System;
using System.Text.RegularExpressions;

namespace Assignment37
{
    class Program
    {   

        static void Main(string[] args)
        {
            //Make a new TextFileSearcher
            TextFileSearcher tfs = new TextFileSearcher(TextFileReader.ReadFile(@"..\..\testText.txt"));
            //Run the TextFileSearcher
            tfs.Run();
        }


        /*
        static void Main(string[] args)
        {
            //Define the limit
            int addLimit      = 100000000;
            int containsLimit = 100000;
            //Define the filepath
            string filePath = @"C:\Users\Precht\Desktop\";

            CollectionBenchmark cb = new CollectionBenchmark(filePath);
            
            //Run each test
            cb.RunAddDictionary(addLimit);
            cb.RunAddList(addLimit);
            cb.RunAddSortedDictionary(addLimit);

            cb.RunContainsDictionary(containsLimit);
            cb.RunContainsList(containsLimit);
            cb.RunContainsSortedDictionary(containsLimit);

            cb.RunBinarySearchList(containsLimit);
        }
        */
    }
}
