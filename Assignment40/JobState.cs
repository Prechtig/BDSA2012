using System;

namespace Assignment40
{
    public enum JobState
    {
        Queued, Running, Ended, Error, Unknown
    }

    public static class JobStateMethods
    {
        public static JobState GetJobState(String state)
        {
            switch (state)
            {
                case "Queued" :
                    return JobState.Queued;
                case "Running" :
                    return JobState.Running;
                case "Ended" :
                    return JobState.Ended;
                case "Error" :
                    return JobState.Error;
                case "Unknown" :
                    return JobState.Unknown;
                default :
                    return JobState.Unknown;
            }
        }
    }
}