using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace HTTPWorkshop
{
    class TCPServer
    {
        public static void Run()
        {
            int serverPort = 8080;
            using (Socket echoListener = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp))
            {
                IPEndPoint echoEndPoint = new IPEndPoint(IPAddress.Any, serverPort);
                echoListener.Bind(echoEndPoint);
                echoListener.Listen(20);

                while (true)
                {
                    Console.WriteLine("Waiting for connections...");
                    Socket incomingConnection = echoListener.Accept();

                    using(NetworkStream connStream = new NetworkStream(incomingConnection, true))
                    using(StreamReader reader = new StreamReader(connStream))
                    {
                        Console.WriteLine("Accepted connection");
                        String data = reader.ReadToEnd();
                        Console.WriteLine("[Server Recieved]: {0}", data);
                        
                        StreamWriter writer = new StreamWriter(connStream);
                        writer.WriteLine(data);
                        writer.Flush();
                    }
                }
            }
        }
    }
}
