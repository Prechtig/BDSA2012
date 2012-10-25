using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChatClient.ChatServiceReference;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ChatServiceClient proxy = new ChatServiceClient())
            {
                Console.Write("Username: ");
                String name = Console.ReadLine();
                Console.Write("[{0}]: ", name);
                String note = Console.ReadLine();
                while (note != "")
                {
                    Console.WriteLine("----------");
                    Console.WriteLine(proxy.PostNote(name, note));
                    Console.Write("[{0}]: ", name);
                    note = Console.ReadLine();
                }
                
            }
        }
    }
}
