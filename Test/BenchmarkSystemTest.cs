using Assignment38;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    /// <summary>
    ///This is a test class for BenchmarkSystemTest and is intended
    ///to contain all BenchmarkSystemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BenchmarkSystemTest
    {
        /// <summary>
        ///A test for Cancel()
        ///</summary>
        [TestMethod()]
        public void CancelTest()
        {
            BenchmarkSystem bs = new BenchmarkSystem();
            bool isCancelled = false;
            Func<string[], int> function = (String) => { isCancelled = true; return 42; };
            Job job = new Job(new Owner("Boogie"), 4, 1, function);
            bs.Submit(job);
            bs.Cancel(job);
            bs.ExecuteAll();
            Assert.IsFalse(isCancelled);
        }

        /// <summary>
        ///A test for ExecuteAll() and Submit()
        ///</summary>
        [TestMethod()]
        public void ExecuteAllTest()
        {
            BenchmarkSystem bs = new BenchmarkSystem();
            bool isCancelled = false;
            Func<string[], int> function = (String) => { isCancelled = true; return 42; };
            Job job = new Job(new Owner("Boogie"), 4, 1, function);
            bs.Submit(job);
            bs.ExecuteAll();
            Assert.IsTrue(isCancelled);

            isCancelled = false;
            bs.ExecuteAll();
            Assert.IsFalse(isCancelled);
        }
    }
}
