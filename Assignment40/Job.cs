using System;

namespace Assignment40
{
    class Job
    {
        private Func<string[], int> process;

        public Job() { }

        public Job(Owner jobOwner, int cpus, uint expectedRuntime, Func<string[], int> process)
        {
            JobOwner = jobOwner;
            CPUs = cpus;
            ExpectedRuntime = expectedRuntime;
            State = JobState.Unassigned;
            this.process = process;
        }

        /// <summary>
        /// Process the Func
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public int Process(string[] args)
        {
            return process(args);
        }

#region Overridden Methods
        public override string ToString()
        {
            return string.Format("Owner: {0} - CPUs: {1} - ExpectedRuntime: {2} - State: {3} - TimeStamp: {4}", JobOwner, CPUs, ExpectedRuntime, State, TimeStamp);
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

        public uint ExpectedRuntime
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
#endregion
    }
}