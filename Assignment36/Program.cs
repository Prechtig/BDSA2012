using System;
using BDSA12;

namespace Assignment36
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Console
            /*
            ConsoleKeyInfo cki;

            GameOfLife gof = new GameOfLife(25);
            gof.RandomizeWorld(new Random());
            gof.PrintWorld();

            do
            {
                cki = Console.ReadKey();
                gof.NextDay();
                Console.WriteLine();
                gof.PrintWorld();
            } while (cki.Key != ConsoleKey.Q);
            */

            //GUI
            IGameOfLife gof = new GameOfLife(25);
            GOFRunner.Run(gof);
        }
    }
}
