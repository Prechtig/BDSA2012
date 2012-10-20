using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40
{
    class Scheduler
    {
        //Fields containing all of the queues
        private List<Job> queue;

        public Scheduler()
        {
            queue = new List<Job>();
            AvailableCPUs = 30;
        }

        //Adds a specific job to the correct queue
        public void AddJob(Job job)
        {
            queue.Add(job);
            job.TimeStamp = DateTime.Now;
            job.State = JobState.Queued;
        }

        //Remove a job from a specified queue
        public void RemoveJob(Job job)
        {
            queue.Remove(job);
        }

        private Job PopJob(int i)
        {
            Job job = queue[i];
            if (job.CPUs < AvailableCPUs)
            {
                queue.Remove(job);
                return job;
            }
            else if (job.Delayed == 2)
            {
                //Wait for the resources to be available
                while (AvailableCPUs < job.CPUs) { }
                queue.Remove(job);
                return job;
            }
            else if (i + 1 == queue.Count)
            {
                //Start over again with the new delayed values
                return PopJob(0);
            }
            else
            {
                job.Delayed++;
                return PopJob(i + 1);
            }
        }

        //Returns the earliest inserted job independent of queue
        public Job PopJob()
        {
            if (0 < queue.Count)
            {
                return PopJob(0);
            }
            else
            {
                return null;
            }
        }

        public int AvailableCPUs
        {
            get;
            set;
        }
    }
}