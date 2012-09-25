using Assignment38;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    /// <summary>
    ///This is a test class for SchedulerTest and is intended
    ///to contain all SchedulerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerTest
    {
        /// <summary>
        ///A test for AddJob and PopJob
        ///</summary>
        [TestMethod()]
        public void AddJobTest()
        {
            Scheduler scheduler = new Scheduler();
            Assert.IsNull(scheduler.PopJob());

            Func<string[], int> function = (String) => 42;
            Job job = new Job(new Owner("Boogie"), 4, 1, function);
            scheduler.AddJob(job);

            Assert.IsNotNull(scheduler.PopJob());
        }

        /// <summary>
        ///A test for RemoveJob
        ///</summary>
        [TestMethod()]
        public void RemoveJobTest()
        {
            Scheduler scheduler = new Scheduler();

            Func<string[], int> function = (String) => 42;
            Job job = new Job(new Owner("Boogie"), 4, 1, function);
            scheduler.AddJob(job);

            Assert.AreEqual(JobState.Queued, job.State);

            scheduler.RemoveJob(job);

            Assert.AreEqual(JobState.Cancelled, job.State);
        }
    }
}