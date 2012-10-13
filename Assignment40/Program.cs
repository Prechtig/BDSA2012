using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Assignment40
{
    class Program
    {

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
    }
}