using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using WCFSimpleChat;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(ChatService)))
            {
                host.Open();

                Console.WriteLine("Ready for connections");
                Console.ReadLine();
            }
        }
    }
}
