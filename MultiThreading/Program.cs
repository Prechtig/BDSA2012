using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        public static void Go(StringBuilder result, String name)
        {
            for (int i = 0; i < 100; i++)
            {
                result.AppendFormat("{0}: {1}\n", name, i);
            }
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            Thread t1 = new Thread(() => Go(result, "One"));
            Thread t2 = new Thread(() => Go(result, "Two"));

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.Write(result.ToString());
            String test = "KOM NU!";
        }
    }
}
