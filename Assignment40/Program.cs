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
            using (var context = new OOADEntities())
            {
                var myJobs = from j in context.jobs
                             select j;
                foreach (job job in myJobs)
                {
                    Console.WriteLine(String.Format("id: {0} - state: {1} - subDate: {2} - userId: {3}",
                                                    job.id, job.state, job.subDate, job.userId));
                }

                var myUsers = from u in context.users
                              select u;
                foreach (user user in myUsers)
                {
                    Console.WriteLine(String.Format("name: {0} - id: {1}", user.name, user.id));
                }

            }
        }
    }
}