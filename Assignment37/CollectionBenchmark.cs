using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment37
{
    class CollectionBenchmark
    {
        private string filePath;
        
        public CollectionBenchmark(string filePath)
        {
            this.filePath = filePath;
        }

        public void RunBinarySearchList(int limit)
        {
            string iString = "iContainsSortedList";
            string resultString = "resultContainsSortedList";

            ClearFile(iString, resultString);
            Print("Sorted List:", iString, resultString);

            try
            {
                List<int> sortedList = new List<int>();
                for (int i = 0; i <= limit; i++)
                {
                    sortedList.Add(i);
                }

                //Create a stopwatch and start the timer
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i <= limit; i++)
                {
                    sortedList.BinarySearch(i);
                    if (i % 1000 == 0)
                    {
                        Print(i, sw.ElapsedMilliseconds, iString, resultString);
                    }
                }
            }
            catch (OutOfMemoryException) { }
        }

        public void RunContainsList(int limit)
        {
            string iString = "iContainsList";
            string resultString = "resultContainsList";

            ClearFile(iString, resultString);
            Print("List:", iString, resultString);

            try
            {
                List<int> list = new List<int>();
                for (int i = 0; i <= limit; i++)
                {
                    list.Add(i);
                }

                //Create a stopwatch and start the timer
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i <= limit; i++)
                {
                    list.Contains(i);
                    if (i % 1000 == 0)
                    {
                        Print(i, sw.ElapsedMilliseconds, iString, resultString);
                    }
                }
            }
            catch (OutOfMemoryException) { }
        }

        public void RunContainsSortedDictionary(int limit)
        {
            string iString = "iContainsSortedDictionary";
            string resultString = "resultContainsSortedDictionary";

            ClearFile(iString, resultString);
            Print("List:", iString, resultString);

            try
            {
                SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
                for (int i = 0; i <= limit; i++)
                {
                    sortedDictionary.Add(i, i);
                }

                //Create a stopwatch and start the timer
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i <= limit; i++)
                {
                    sortedDictionary.ContainsKey(i);
                    if (i % 1000 == 0)
                    {
                        Print(i, sw.ElapsedMilliseconds, iString, resultString);
                    }
                }
            }
            catch (OutOfMemoryException) { }
        }

        public void RunContainsDictionary(int limit)
        {
            string iString = "iContainsDictionary";
            string resultString = "resultContainsDictionary";

            ClearFile(iString, resultString);
            Print("Dictionary", iString, resultString);

            try
            {
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                for (int i = 0; i <= limit; i++)
                {
                    dictionary.Add(i, i);
                }

                //Create a stopwatch and start the timer
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i <= limit; i++)
                {
                    dictionary.ContainsKey(i);
                    if (i % 1000 == 0)
                    {
                        Print(i, sw.ElapsedMilliseconds, iString, resultString);
                    }
                }
            }
            catch (OutOfMemoryException) { }
        }

        public void RunAddList(int limit)
        {
            string iString = "iAddList";
            string resultString = "resultAddList";

            ClearFile(iString, resultString);
            Print("List:", iString, resultString);

            try
            {
                //Create a new list
                List<int> list = new List<int>(limit);
                //Create a stopwatch and start the timer
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i <= limit; i++)
                {
                    list.Add(i);
                    if (i % 1000000 == 0)
                    {
                        Print(i, sw.ElapsedMilliseconds, iString, resultString);
                    }
                }
            }
            catch (OutOfMemoryException) { }
            
        }

        public void RunAddSortedDictionary(int limit)
        {
            string iString = "iAddSortedDictionary";
            string resultString = "resultAddSortedDictionary";

            ClearFile(iString, resultString);
            Print("SortedDictionary:", iString, resultString);

            try
            {
                //Create a new sorted dictionary
                SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
                //Create a stopwatch and start the timer
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i <= limit; i++)
                {
                    sortedDictionary.Add(i, i);
                    if (i % 1000000 == 0)
                    {
                        Print(i, sw.ElapsedMilliseconds, iString, resultString);
                    }
                }
            }
            catch (OutOfMemoryException) { }
        }

        public void RunAddDictionary(int limit)
        {
            string iString = "iAddDictionary";
            string resultString = "resultAddDictionary";

            ClearFile(iString, resultString);
            Print("Dictionary:", iString, resultString);

            try
            {
                //Create a new dictionary
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                //Create a stopwatch and start the timer
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i <= limit; i++)
                {
                    dictionary.Add(i, i);
                    if (i % 1000000 == 0)
                    {
                        Print(i, sw.ElapsedMilliseconds, iString, resultString);
                    }
                }
            }
            catch (OutOfMemoryException) { }
            
        }

#region File Methods
        /// <summary>
        /// Clears the to files
        /// </summary>
        private void ClearFile(string iFile, string resultFile)
        {
            System.IO.File.WriteAllText(filePath + iFile + ".txt", string.Empty);
            System.IO.File.WriteAllText(filePath + resultFile + ".txt", string.Empty);
        }

        /// <summary>
        /// Prints the input text to the two files and the console
        /// </summary>
        private void Print(string text, string iFile, string resultFile)
        {
            System.IO.File.AppendAllText(filePath + iFile + ".txt", text + System.Environment.NewLine);
            System.IO.File.AppendAllText(filePath + resultFile + ".txt", text + System.Environment.NewLine);
            Console.WriteLine(text);
        }
        
        /// <summary>
        /// Prints a intermediate time two the two files and the console
        /// </summary>
        private void Print(int i, long elapsedMilliseconds, string iFile, string resultFile)
        {
            System.IO.File.AppendAllText(filePath + iFile + ".txt", i.ToString() + System.Environment.NewLine);
            System.IO.File.AppendAllText(filePath + resultFile + ".txt", elapsedMilliseconds.ToString() + System.Environment.NewLine);
            Console.WriteLine(string.Format("{0,10} {1,6}", i.ToString(), elapsedMilliseconds.ToString()));
        }
#endregion
    }
}