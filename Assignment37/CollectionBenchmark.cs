using System;
using System.Collections.Generic;

namespace Assignment37
{
    class CollectionBenchmark
    {
        List<int> list = new List<int>();
        SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        public void Run(int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                list.Add(i);
            }
        }

        private void Add(
    }
}
