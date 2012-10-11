using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40
{
    class DAO
    {
        public static IEnumerable<user> GetUsers()
        {
            using (var context = new OOADEntities())
            {
                var users = from u in context.users
                            select u;
                return users;
            }
        }

        public static IEnumerable<job> GetJobsBy(uint id)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.jobs
                           where j.userId == id
                           select j;
                return jobs;
            }
        }

        public static IEnumerable<job> GetJobs(uint id, int pastXDays)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.jobs
                           where j.userId == id &&
                                 DateTime.Now <= j.subDate.AddDays(pastXDays)
                           select j;
                return jobs;
            }
        }

        public static IEnumerable<job> GetJobs(uint id, DateTime start, DateTime end)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.jobs
                           where j.userId == id &&
                                 start <= j.subDate && j.subDate <= end
                           select j;
                return jobs;
            }
        }

        public static IEnumerable<job> GetJobs(DateTime start, DateTime end)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.jobs
                           where start <= j.subDate && j.subDate <= end
                           group j by j.state into d
                           select d;
                return jobs;
            }
        }
    }
}