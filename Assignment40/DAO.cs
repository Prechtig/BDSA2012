using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40
{
    class DAO
    {
        #region Getters

        /// <summary>
        /// Get a user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        public static Owner GetUser(int id)
        {
            using (var context = new OOADEntities())
            {
                var user = from u in context.users
                           where u.id == id
                           select u;
                //Check if there's a user with the given id - else return null
                return 0 < user.Count() ? new Owner(user.First().name, user.First().id) : null;
            }
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<user> GetUsers()
        {
            using (var context = new OOADEntities())
            {
                var users = from u in context.users
                            select u;
                //Check if there's any users in the db - else return null
                return 0 < users.Count() ? users.ToList() : null;
            }
        }

        /// <summary>
        /// Select all jobs from a user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        public static IEnumerable<logEntry> GetJobs(uint id)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.logEntries
                           where j.userId == id
                           select j;
                //Check if there's any jobs submitted by the user - else return null
                return 0 < jobs.Count() ? jobs.ToList() : null;
            }
        }

        /// <summary>
        /// Select all jobs from a user within the past X days
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="pastXDays">The past X days</param>
        /// <returns></returns>
        public static IEnumerable<logEntry> GetJobs(uint id, int pastXDays)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.logEntries
                           where j.userId == id &&
                                 DateTime.Now.AddDays(-pastXDays) <= j.timeStamp
                           select j;
                //Check if there's any jobs submitted by the user within X days - else return null
                return 0 < jobs.Count() ? jobs.ToList() : null;
            }
        }

        /// <summary>
        /// select all jobs submitted by a user within a given time period
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="start">The start time</param>
        /// <param name="end">The end time</param>
        /// <returns></returns>
        public static IEnumerable<logEntry> GetJobs(uint id, DateTime start, DateTime end)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.logEntries
                           where j.userId == id &&
                                 start <= j.timeStamp && j.timeStamp <= end
                           select j;
                //Check if there's any jobs submitted by the user within the time period - else return null
                return 0 < jobs.Count() ? jobs.ToList() : null;
            }
        }

        /// <summary>
        /// Return the number of jobs within a given period grouped by their status
        /// </summary>
        /// <param name="start">The start time</param>
        /// <param name="end">The end time</param>
        /// <returns></returns>
        public static Dictionary<String, List<LogEntry>> GetJobs(DateTime start, DateTime end)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.logEntries
                           where start <= j.timeStamp && j.timeStamp <= end
                           group j by j.state into stateGroup
                           select new { StateGroup = stateGroup.Key, State = stateGroup };

                Dictionary<String, List<LogEntry>> dic = new Dictionary<String, List<LogEntry>>();
                foreach (var group in jobs)
                {
                    List<LogEntry> list = new List<LogEntry>();
                    dic.Add(group.StateGroup, list);
                    foreach (var state in group.State)
                    {
                        list.Add(new LogEntry(state.id, state.jobId, state.userId, state.timeStamp, state.state));
                    }
                }
                return dic;
            }
        }

        /// <summary>
        /// Return the number of jobs submitted by a user, within a given period grouped by their status
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="start">The start time</param>
        /// <param name="end">The end time</param>
        /// <returns></returns>
        public static Dictionary<String, List<LogEntry>> GetJobs(int id, DateTime start, DateTime end)
        {
            using (var context = new OOADEntities())
            {
                var jobs = from j in context.logEntries
                           where start <= j.timeStamp && j.timeStamp <= end && j.userId == id
                           group j by j.state into stateGroup
                           select new { StateGroup = stateGroup.Key, State = stateGroup };

                Dictionary<String, List<LogEntry>> dic = new Dictionary<String, List<LogEntry>>();
                foreach (var group in jobs)
                {
                    List<LogEntry> list = new List<LogEntry>();
                    dic.Add(group.StateGroup, list);
                    foreach (var state in group.State)
                    {
                        list.Add(new LogEntry(state.id, state.jobId, state.userId, state.timeStamp, state.state));
                    }
                }
                return dic;
            }
        }

        #endregion

        #region Setters

        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="owner">The user to add</param>
        public static bool AddUser(Owner owner)
        {
            try
            {
                using (var context = new OOADEntities())
                {
                    user u = new user();
                    u.name = owner.Name;
                    context.users.AddObject(u);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// Add a LogEntry to the database
        /// </summary>
        /// <param name="entry">The LogEntry to add</param>
        public static bool AddLogEntry(LogEntry entry)
        {
            using (var context = new OOADEntities())
            {
                logEntry dbEntry = new logEntry();
                dbEntry.jobId = entry.JobId;
                dbEntry.state = entry.State.ToString();
                dbEntry.timeStamp = entry.TimeStamp;
                //If the user doesn't exist in the db, we'll get a NPE
                try { dbEntry.userId = entry.JobOwner.Id; }
                catch (NullReferenceException) { return false; }
                context.logEntries.AddObject(dbEntry);
                context.SaveChanges();
                return true;
            }
        }

        #endregion
    }
}