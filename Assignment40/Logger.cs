using System;

namespace Assignment40
{
    class Logger
    {
        public Logger(){
        }

        /// <summary>
        /// Listen to the given BenchmarkSystem
        /// </summary>
        /// <param name="bs">The BenchmarkSystem to listen to</param>
        public void Subscribe(BenchmarkSystem bs)
        {
            bs.JobSubmitted += OnJobSubmitted;
            bs.JobCancelled += OnJobCancelled;
            bs.JobRunning += OnJobRunning;
            bs.JobTerminated += OnJobTerminated;
            bs.JobFailed += OnJobFailed;
        }

        /// <summary>
        /// Stop Listening to the given BenchmarkSystem
        /// </summary>
        /// <param name="bs">The BenchmarkSystem to stop listening to</param>
        public void Unsubscribe(BenchmarkSystem bs)
        {
            bs.JobSubmitted -= OnJobSubmitted;
            bs.JobCancelled -= OnJobCancelled;
            bs.JobRunning -= OnJobRunning;
            bs.JobTerminated -= OnJobTerminated;
            bs.JobFailed -= OnJobFailed;
        }

        public void OnJobSubmitted(Job job)
        {
            //Console.WriteLine(string.Format("Job submitted: {0}", job));
        }

        public void OnJobCancelled(Job job)
        {
            Console.WriteLine(string.Format("Job cancelled: {0}", job));
        }

        public void OnJobRunning(Job job)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Job running: {0}", job));
            ResetConsole();
        }

        public void OnJobTerminated(Job job)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("Job terminated: {0}", job));
            ResetConsole();
        }

        public void OnJobFailed(Job job)
        {
            Console.WriteLine(string.Format("Job failed: {0}", job));
        }

        private void ResetConsole()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
