using Assignment36;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{


    /// <summary>
    ///This is a test class for GameOfLifeTest and is intended
    ///to contain all GameOfLifeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameOfLifeTest
    {
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GameOfLife Constructor
        ///</summary>
        [TestMethod()]
        public void GameOfLifeConstructorTest()
        {
            uint size = 25;
            GameOfLife gof = new GameOfLife(size);
            Assert.AreEqual(size, gof.Size);
        }

        /// <summary>
        ///A test for ChangeState
        ///</summary>
        [TestMethod()]
        public void ChangeStateTest()
        {
            uint size = 25;
            GameOfLife gof = new GameOfLife(size);

            int? oldState = gof[0, 0];

            CoordState stateChange;
            if (oldState == null)
            {
                stateChange = new CoordState(0, 0, 1);
            }
            else
            {
                stateChange = new CoordState(0, 0, null);
            }

            gof.ChangeState(stateChange);

            int? newState = gof[0, 0];

            Assert.AreNotEqual(oldState, newState);
        }

        /// <summary>
        ///A test for GetWorldCopy
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Assignment36.exe")]
        public void GetWorldCopyTest()
        {
            uint size = 25;
            GameOfLife_Accessor gof = new GameOfLife_Accessor(size);
            int?[,] worldCopy = gof.GetWorldCopy();
            for (uint x = 0; x < size; x++)
            {
                for (uint y = 0; y < size; y++)
                {
                    Assert.AreEqual(gof[x, y], worldCopy[x, y]);
                }
            }
        }

        /// <summary>
        ///A test for IsValidPoint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Assignment36.exe")]
        public void IsValidPointTest()
        {
            uint size = 25;
            GameOfLife_Accessor gof = new GameOfLife_Accessor(size);

            Assert.AreEqual(true, gof.IsValidPoint(0, 0));
            Assert.AreEqual(true, gof.IsValidPoint((int)size - 1, (int)size - 1));
            Assert.AreEqual(false, gof.IsValidPoint(-1, -1));
            Assert.AreEqual(false, gof.IsValidPoint((int)size, (int)size));
        }

        /// <summary>
        ///A test for NextDay
        ///</summary>
        [TestMethod()]
        public void NextDayTest()
        {
            uint size = 25;
            GameOfLife gof = new GameOfLife(size);
            Random rnd = new Random();
            gof.RandomizeWorld(rnd);
            int?[,] world1 = new int?[size, size];
            for (uint x = 0; x < size; x++)
            {
                for (uint y = 0; y < size; y++)
                {
                    world1[x, y] = gof[x, y];
                }
            }

            //Make a day go by
            gof.NextDay();

            int?[,] world2 = new int?[size, size];
            for (uint x = 0; x < size; x++)
            {
                for (uint y = 0; y < size; y++)
                {
                    world2[x, y] = gof[x, y];
                }
            }
            Assert.AreNotEqual(world1, world2);
        }

        /// <summary>
        ///A test for RandomizeWorld
        ///</summary>
        [TestMethod()]
        public void RandomizeWorldTest()
        {
            uint size = 25;
            GameOfLife gof1337 = new GameOfLife(size);
            Random rnd = new Random(1337);
            gof1337.RandomizeWorld(rnd);
            int?[,] world1337 = new int?[size, size];
            for (uint x = 0; x < size; x++)
            {
                for (uint y = 0; y < size; y++)
                {
                    world1337[x, y] = gof1337[x, y];
                }
            }

            GameOfLife gof42 = new GameOfLife(size);
            rnd = new Random(42);
            gof42.RandomizeWorld(rnd);
            int?[,] world42 = new int?[size, size];
            for (uint x = 0; x < size; x++)
            {
                for (uint y = 0; y < size; y++)
                {
                    world42[x, y] = gof42[x, y];
                }
            }
            Assert.AreNotEqual(world1337, world42);
        }
    }
}