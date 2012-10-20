using System;

namespace Assignment40
{
    class Job
    {
        private Func<string[], int> process;

        public Job() { }

        public Job(int id, Owner jobOwner, int cpus, double expectedRuntime, Func<string[], int> process)
        {
            JobOwner = jobOwner;
            //Limit the number of cpus to 1-10
            CPUs = cpus < 1 ? 1 : 10 < cpus ? 10 : cpus;
            //Limit the expected runtime to 0.1 - 5.0
            ExpectedRuntime = expectedRuntime < 0.1 ? 0.1 : 5.0 < expectedRuntime ? 5.0 : expectedRuntime;
            State = JobState.Unknown;
            this.process = process;
            Delayed = 0;
        }

        /// <summary>
        /// Process the Func
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public int Process(string[] args)
        {
            int i = process(args);
            Scheduler scheduler = BenchmarkSystem.GetBenchmarkSystem().GetScheduler();
            scheduler.AvailableCPUs += CPUs;
            Console.WriteLine("Available CPUs = {0}", scheduler.AvailableCPUs);
            State = JobState.Ended;
            return i;
        }

#region Overridden Methods
        public override string ToString()
        {
            return string.Format("Delayed: {0} - CPUs: {1} - ExpectedRuntime: {2} - State: {3}", Delayed, CPUs, ExpectedRuntime, State);
        }
#endregion

        #region Properties
        public Owner JobOwner
        {
            get;
            private set;
        }

        public int CPUs
        {
            get;
            private set;
        }

        public double ExpectedRuntime
        {
            get;
            private set;
        }

        public JobState State
        {
            get;
            set;
        }

        public DateTime TimeStamp
        {
            get;
            set;
        }

        public int Delayed { get; set; }
#endregion
    }
}