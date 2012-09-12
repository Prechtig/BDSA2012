using System;
using System.Collections.Generic;
using BDSA12;

namespace Assignment36
{
    class GameOfLife : IGameOfLife
    {
        //Field that represents the world
        private int?[,] world;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">The width and the height of the world</param>
        public GameOfLife(uint size)
        {
            Size = size;
            world = new int?[Size, Size];
            //Initialize the world
            RandomizeWorld(new Random());
        }

        public int? this[uint x, uint y]
        {
            get
            {
                return world[x, y];
            }
        }

        public uint Size
        {
            get;
            private set;
        }

        /// <summary>
        /// Makes a day go by, updating the fields
        /// corresponding to the set of rules.
        /// </summary>
        public void NextDay()
        {
            List<CoordState> updates = new List<CoordState>();
            //Makes a copy of the world in order to have a reference
            //which will not be changed when updating the original.
            int?[,] worldCopy = GetWorldCopy();
            //Loop through the cells of the world
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    //Amount of neighboring species
                    int zombies = 0;
                    int alive = 0;
                    //Loop through the 8 neighboring tiles
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            //If we're on the initial field we're
                            //testing from, we do nothing
                            if (i == 0 && j == 0) { }
                            else if(IsValidPoint(x+i, y+j))
                            {
                                //Get the state of the cell and
                                //increment the corresponding counter
                                int? state = worldCopy[x + i, y + j];
                                if (state == null) { zombies++; }
                                else if (state == 1) { alive++; }
                            }
                        }
                    }
                    //If the cell is either dead or alive, process it
                    CoordState self = new CoordState(x, y, worldCopy[x, y]);
                    if (self.State == 1)
                    {
                        CoordState newState = ProcessLiveCell(self, zombies, alive);
                        if (!newState.Equals(self))
                        {
                            updates.Add(newState);
                        }
                        
                    }
                    else if (self.State == 0)
                    {
                        CoordState newState = ProcessDeadCell(self, alive);
                        if(!newState.Equals(self))
                        {
                            updates.Add(newState);
                        }
                    }
                }
            }
            //Change the state of all the updates
            ChangeState(updates.ToArray());
        }

        /// <summary>
        /// Check if the given point is within the boundaries of the world
        /// </summary>
        /// <param name="x">The x value of the point</param>
        /// <param name="y">The y value of the point</param>
        /// <returns>Whether the point is within the boundaries</returns>
        private bool IsValidPoint(int x, int y)
        {
            return (0 <= x && x < Size &&
                    0 <= y && y < Size);
        }

        /// <summary>
        /// Print the world to the console
        /// </summary>
        public void PrintWorld()
        {
            Console.Clear();
            System.Text.StringBuilder sb;
            for (int y = 0; y < Size; y++)
            {
                sb = new System.Text.StringBuilder();
                for (int x = 0; x < Size; x++)
                {
                    int? state = world[x, y];
                    if (state == 1) { sb.Append("1"); }
                    else if (state == 0) { sb.Append("0"); }
                    else { sb.Append("n"); }

                }
                Console.WriteLine(sb);
            }
        }

        /// <summary>
        /// Returns a copy of the current world
        /// </summary>
        /// <returns> A copy of the current world</returns>
        private int?[,] GetWorldCopy()
        {
            int?[,] worldCopy = new int?[Size, Size];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    worldCopy[x, y] = world[x, y];
                }
            }
            return worldCopy;
        }

        /// <summary>
        /// Processes the cell according to the rules given to living cells
        /// </summary>
        /// <param name="curState">The current state of the cell</param>
        /// <param name="zombies">Number of neighboring zombies</param>
        /// <param name="alive">Number of neighboring living cells</param>
        /// <returns>The new state of the cell</returns>
        private CoordState ProcessLiveCell(CoordState curState, int zombies, int alive)
        {
            CoordState newState = curState;
            if (alive <= 1) { newState = new CoordState(curState.X, curState.Y, 0); }
            else if (alive == 2 && alive == 3) { newState = new CoordState(curState.X, curState.Y, 1); }
            else if (alive >= 4) { newState = new CoordState(curState.X, curState.Y, 0); }
            else if (zombies >= 1)
            {
                int? state;
                Random rnd = new Random();
                double num = rnd.NextDouble();
                if (num < 0.5) { state = 1; }
                else { state = null; }
                newState = new CoordState(curState.X, curState.Y, state);
            }
            return newState;
            //ChangeState(newState);
        }

        /// <summary>
        /// Processes the cell according to the rules given to dead cells
        /// </summary>
        /// <param name="curState">The current state of the cell</param>
        /// <param name="alive">Number of neighboring living cells</param>
        /// <returns>The new state of the cell</returns>
        private CoordState ProcessDeadCell(CoordState curState, int alive)
        {
            CoordState newState = curState;
            if (alive == 3) { newState = new CoordState(curState.X, curState.Y, 1); }
            return newState;
            //ChangeState(newState);
        }

        /// <summary>
        /// Changes the State of multiple points.
        /// </summary>
        /// <param name="newState">The CoordState stating what point should be changed to what.</param>
        public void ChangeState(params CoordState[] newState)
        {
            foreach (CoordState cs in newState)
            {
                world[cs.X, cs.Y] = cs.State;
            }
        }

        /// <summary>
        /// Run through all points initializing each point to a random value.
        /// </summary>
        public void RandomizeWorld(Random rnd)
        {
            int? state;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    double num = rnd.NextDouble();

                    if (num < 0.20) { state = null; }
                    else if (num < 0.60) { state = 0; }
                    else { state = 1; }

                    world[x, y] = state;
                }
            }
        }
    }
}