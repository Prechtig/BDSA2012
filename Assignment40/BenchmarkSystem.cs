using System;

namespace Assignment40
{
    class BenchmarkSystem
    {
        //Events
        public event Action<Job> JobSubmitted;
        public event Action<Job> JobCancelled;
        public event Action<Job> JobRunning;
        public event Action<Job> JobTerminated;
        public event Action<Job> JobFailed;
        //Scheduler
        private Scheduler scheduler;

        public BenchmarkSystem()
        {
            scheduler = new Scheduler();
        }

        /// <summary>
        /// Submit a job to the benchmarksystem
        /// </summary>
        /// <param name="job">The job to submit</param>
        public void Submit(Job job)
        {
            //Notify subscribers
            if (JobSubmitted != null)
            {
                JobSubmitted(job);
            }
            scheduler.AddJob(job);
        }

        /// <summary>
        /// Cancel a job in the benchmarksystem
        /// </summary>
        /// <param name="job">The job to cancel</param>
        public void Cancel(Job job)
        {
            //Notify subscribers
            if (JobCancelled != null)
            {
                JobCancelled(job);
            }
            scheduler.RemoveJob(job);
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
                    job.Process(new[] { "" });
                    job.State = JobState.Finished;
                }
                //If the job failed, notify subscribers
                catch (Exception)
                {
                    if (JobFailed != null)
                    {
                        JobFailed(job);
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