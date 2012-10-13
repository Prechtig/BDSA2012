using Assignment40;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test
{
    ///      
    ///      #####   ####    ####
    ///     #     #  #   #  #
    ///     #     #  ####    ####
    ///     #     #  #   #       #
    ///      #####   ####    ####
    ///      
    ///     We can't get the tests to work. It throws an exception
    ///     when we try to call any methods from the DAO class.
    ///     The Program.cs in the Assignment40 namespace, has no
    ///     problem calling the methods. We don't know what's wrong,
    ///     but the tests should work, besides that error.
    ///
    ///      #####   ####    ####
    ///     #     #  #   #  #
    ///     #     #  ####    ####
    ///     #     #  #   #       #
    ///      #####   ####    ####
    ///      

    
    /// <summary>
    ///This is a test class for DAOTest and is intended
    ///to contain all DAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DAOTest
    {
        /// <summary>
        ///A test for AddLogEntry
        ///</summary>
        [TestMethod()]
        public void AddLogEntryTest()
        {
            LogEntry entry = new LogEntry(0, 1, 4, DateTime.Now, "Queued");
            Assert.IsTrue(DAO.AddLogEntry(entry));
        }

        /// <summary>
        ///A test for AddUser
        ///</summary>
        [TestMethod()]
        public void AddUserTest()
        {
            Owner owner = new Owner("Bob", 0);
            Assert.IsTrue(DAO.AddUser(owner));
        }

        /// <summary>
        ///A test for GetJobs
        ///</summary>
        [TestMethod()]
        public void GetJobsTest()
        {
            uint id = 4;
            Assert.IsNotNull(DAO.GetJobs(id));
        }

        /// <summary>
        ///A test for GetJobs
        ///</summary>
        [TestMethod()]
        public void GetJobsTest1()
        {
            uint id = 4;
            int pastXDays = 1000;
            Assert.IsNotNull(DAO.GetJobs(id, pastXDays));
        }

        /// <summary>
        ///A test for GetJobs
        ///</summary>
        [TestMethod()]
        public void GetJobsTest2()
        {
            uint id = 4;
            DateTime start = new DateTime(1000,1,1,1,1,1);
            DateTime end = new DateTime(3000,1,1,1,1,1);
            Assert.IsNotNull(DAO.GetJobs(id, start, end));
        }

        /// <summary>
        ///A test for GetJobs
        ///</summary>
        [TestMethod()]
        public void GetJobsTest3()
        {
            DateTime start = new DateTime(1000, 1, 1, 1, 1, 1);
            DateTime end = new DateTime(3000, 1, 1, 1, 1, 1);
            Dictionary<string, List<LogEntry>> dic = DAO.GetJobs(start, end);
            Assert.IsTrue(0 < dic.Keys.Count);
        }

        /// <summary>
        ///A test for GetJobs
        ///</summary>
        [TestMethod()]
        public void GetJobsTest4()
        {
            int id = 4;
            DateTime start = new DateTime(1000, 1, 1, 1, 1, 1);
            DateTime end = new DateTime(3000, 1, 1, 1, 1, 1);
            Dictionary<string, List<LogEntry>> dic = DAO.GetJobs(id, start, end);
            Assert.IsTrue(0 < dic.Keys.Count);
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        [TestMethod()]
        public void GetUserTest()
        {
            int id = 4;
            Assert.IsNotNull(DAO.GetUser(id));
        }

        /// <summary>
        ///A test for GetUsers
        ///</summary>
        [TestMethod()]
        public void GetUsersTest()
        {
            Assert.IsNotNull(DAO.GetUsers());
        }
    }
}
