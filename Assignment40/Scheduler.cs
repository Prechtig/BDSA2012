using System;
using System.Collections.Generic;

namespace Assignment40
{
    class Scheduler
    {
        //Fields containing all of the queues
        private Queue<Job> shortQueue;
        private Queue<Job> longQueue;
        private Queue<Job> veryLongQueue;
        private List<Queue<Job>> queues;

        public Scheduler()
        {
            shortQueue = new Queue<Job>();
            longQueue = new Queue<Job>();
            veryLongQueue = new Queue<Job>();
            queues = new List<Queue<Job>>();
            queues.Add(shortQueue);
            queues.Add(longQueue);
            queues.Add(veryLongQueue);
        }

        //Adds a specific job to the correct queue
        public void AddJob(Job job)
        {    
            job.State = JobState.Queued;
            job.TimeStamp = DateTime.Now;

            if(job.ExpectedRuntime < 30) {
                shortQueue.Enqueue(job);
            }
            else if(30 <= job.ExpectedRuntime && job.ExpectedRuntime <= 120){
                longQueue.Enqueue(job);
            }
            else{
                veryLongQueue.Enqueue(job);
            }
        }

        //Remove a job from a specified queue
        public void RemoveJob(Job job)
        {
            job.State = JobState.Cancelled;
        }

        //Returns the earliest inserted job independent of queue
        public Job PopJob()
        {
            Queue<Job> popQueue = queues[0];
            
            //Remove all cancelled Jobs
            foreach (Queue<Job> queue in queues)
            {
                while (0 < queue.Count && queue.Peek().State == JobState.Cancelled) { queue.Dequeue(); }
            }
            //Find the oldest job
            foreach (Queue<Job> queue in queues)
            {
                if (0 < queue.Count && (popQueue.Count == 0 || queue.Peek().TimeStamp < popQueue.Peek().TimeStamp))
                {
                    popQueue = queue;
                }
            }
            //Return the oldest job if there's any
            if (0 < popQueue.Count)
            {
                return popQueue.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }
}