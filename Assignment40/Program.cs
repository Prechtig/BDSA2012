using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace Assignment40
{
    class Program
    {
        private static Job CreateRandomJob()
        {
            Func<String[], int> process = (x) =>
            {
                int i = (int)double.Parse(x[0]);
                Thread.Sleep(i*1000);
                return i;
            };
            Random rnd = new Random();
            //Sets cpus to a number between 1-10 both inclusive
            int cpus = rnd.Next(1, 11);
            //Sets the expectedRuntime to a number between 0.0 and 5.0 both inclusive
            double expectedRuntime = rnd.NextDouble() * 5.0;
            Owner jobOwner = new Owner("Christian", 4);
            Job job = new Job(0, jobOwner, cpus, expectedRuntime, process);
            return job;
        }

        private static void CreateRandomJobs(BenchmarkSystem bs)
        {
            while (true)
            {
                Job job = CreateRandomJob();
                bs.Submit(job);
                Random rnd = new Random();
                //Sleep between 0 and 5 seconds
                Thread.Sleep((int)(rnd.NextDouble() * 500));

            }
        }

        static void Main(String[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            BenchmarkSystem bs = BenchmarkSystem.GetBenchmarkSystem();
            //Start a thread that submits new random jobs at random intervals
            Thread t1 = new Thread(() => CreateRandomJobs(bs));
            t1.Start();
            Thread.Sleep(5000);
            Console.WriteLine("Main started");

            Logger logger = new Logger();
            logger.Subscribe(bs);

            while (true)
            {
                Console.WriteLine("New ExecuteAll() called");
                bs.ExecuteAll();
            }
        }

        /*
        static void Main(string[] args)
        {
            IEnumerable<user> users = DAO.GetUsers();

            foreach (user u in users)
            {
                Console.WriteLine("id: {0} - name: {1}", u.id, u.name);
            }
            Dictionary<String, List<LogEntry>> dic1 = DAO.GetJobs(new DateTime(1000, 1, 1, 0, 0, 0, 0), new DateTime(3000, 1, 1, 0, 0, 0, 0));

            foreach (KeyValuePair<String, List<LogEntry>> pair in dic1)
            {
                Console.WriteLine(pair.Key);
                foreach (LogEntry entry in pair.Value)
                {
                    Console.WriteLine("    {0}", entry);
                }
            }

            LogEntry newEntry = new LogEntry(0, 1, 1, DateTime.Now, "Running");
            DAO.AddLogEntry(newEntry);

            Dictionary<String, List<LogEntry>> dic2 = DAO.GetJobs(4, new DateTime(1000, 1, 1, 0, 0, 0, 0), new DateTime(3000, 1, 1, 0, 0, 0, 0));

            foreach (KeyValuePair<String, List<LogEntry>> pair in dic2)
            {
                Console.WriteLine(pair.Key);
                foreach (LogEntry entry in pair.Value)
                {
                    Console.WriteLine("    {0}", entry);
                }
            }

            Console.WriteLine(DAO.GetUser(3));
        }
        */
    }
}