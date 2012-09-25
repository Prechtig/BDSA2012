using System;
using System.Collections.Generic;

namespace Assignment38
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSystem bs = new BenchmarkSystem();
            Logger logger1 = new Logger();
            Logger logger2 = new Logger();
            Func<string[], int> function = (String) => 42;

            List<Job> list = new List<Job>();
            list.Add(new Job(new Owner("Boogie"), 4, 1, function));
            list.Add(new Job(new Owner("Mikkel"), 4, 50, function));
            list.Add(new Job(new Owner("The Blitz"), 4, 90, function));
            list.Add(new Job(new Owner("Mark"), 4, 110, function));
            list.Add(new Job(new Owner("Morten"), 4, 125, function));
            list.Add(new Job(new Owner("Andreas"), 4, 3893, function));

            foreach (Job job in list)
            {
                bs.Submit(job);
            }

            logger1.Subscribe(bs);

            bs.ExecuteAll();

            foreach (Job job in list)
            {
                bs.Submit(job);
            }

            logger2.Subscribe(bs);

            bs.ExecuteAll();
        }
    }
}
