using System;

namespace Assignment40
{
    struct LogEntry
    {
        public LogEntry(int logEntryId, int jobId, int userId, DateTime timeStamp, String state) : this()
        {
            LogEntryId = logEntryId;
            JobId = jobId;
            JobOwner = DAO.GetUser(userId);
            TimeStamp = timeStamp;
            State = JobStateMethods.GetJobState(state);
        }

        public override string ToString()
        {
            return String.Format("LogEntryId: {0} - JobId: {1} Owner: {2} - TimeStamp: {3} - State {4}", LogEntryId, JobId, JobOwner, TimeStamp, State);
        }

        public int LogEntryId { get; private set; }
        
        public int JobId { get; private set; }

        public Owner JobOwner { get; private set; }

        public DateTime TimeStamp { get; private set; }

        public JobState State { get; private set; }
    }
}
