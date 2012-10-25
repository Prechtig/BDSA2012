using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace HTTPWorkshop
{
    class TCPClient
    {
        public static void Run()
        {
            int serverPort = 8080;
            IPAddress serverIp = IPAddress.Parse("10.211.55.4"); //IPAdress of Anders
            Console.WriteLine("Server IP: {0}", serverIp);

            Socket echoSocket = new Socket(
                serverIp.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            echoSocket.Connect(serverIp, serverPort);

            using(Stream echoServiceStream = new NetworkStream(echoSocket, true))
            using(StreamReader reader = new StreamReader(echoServiceStream))
            using(StreamWriter writer = new StreamWriter(echoServiceStream))
            {
                writer.WriteLine("Hello World");
                writer.Flush();
                String data = reader.ReadToEnd();
                Console.WriteLine("[from Server]: {0}", data);
            }
        }
    }
}
