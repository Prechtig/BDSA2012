using System;
using System.Threading;

namespace Assignment40
{
    class BenchmarkSystem
    {
        //BenchmarkSystem Singleton
        private static BenchmarkSystem bs;
        //Events
        public event Action<Job> JobSubmitted;
        public event Action<Job> JobCancelled;
        public event Action<Job> JobRunning;
        public event Action<Job> JobTerminated;
        public event Action<Job> JobFailed;
        //Scheduler
        private Scheduler scheduler;

        private BenchmarkSystem()
        {
            scheduler = new Scheduler();
        }

        public static BenchmarkSystem GetBenchmarkSystem()
        {
            if (bs == null)
            {
                bs = new BenchmarkSystem();
            }
            return bs;
        }

        public Scheduler GetScheduler()
        {
            return scheduler;
        }

        /// <summary>
        /// Submit a job to the benchmarksystem
        /// </summary>
        /// <param name="job">The job to submit</param>
        public void Submit(Job job)
        {
            scheduler.AddJob(job);
            //Notify subscribers
            if (JobSubmitted != null)
            {
                JobSubmitted(job);
            }
        }

        /// <summary>
        /// Cancel a job in the benchmarksystem
        /// </summary>
        /// <param name="job">The job to cancel</param>
        public void Cancel(Job job)
        {
            scheduler.RemoveJob(job);
            //Notify subscribers
            if (JobCancelled != null)
            {
                JobCancelled(job);
            }
        }

        /// <summary>
        /// Execute all jobs in the benchmarksystem
        /// </summary>
        public void ExecuteAll()
        {
            for (Job job = scheduler.PopJob(); job != null; job = scheduler.PopJob())
            {
                //Notify subscribers
                if (JobRunning != null)
                {
                    JobRunning(job);
                }
                //Process the job
                try
                {
                    job.State = JobState.Running;
                    scheduler.AvailableCPUs -= job.CPUs;
                    Console.WriteLine("Available CPUs = {0}", scheduler.AvailableCPUs);
                    Thread t = new Thread(() => job.Process(new[] { job.ExpectedRuntime.ToString() }));
                    t.Start();                    
                }
                //If the job failed, notify subscribers
                catch (Exception)
                {
                    if (JobFailed != null)
                    {
                        JobFailed(job);
                        job.State = JobState.Error;
                    }
                }
                //Notify subscribers
                if (JobTerminated != null)
                {
                    JobTerminated(job);
                }
            }
        }       
    }
}