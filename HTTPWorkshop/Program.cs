using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HTTPWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args[0].Equals("client"))
            {
                TCPClient.Run();
            }
            else if (args[0].Equals("server"))
            {
                TCPServer.Run();
            }
            else
            {
                Console.WriteLine("Error");
            }
            
            //ReadHttpWebRequest("http://www.itu.dk/people/dpacino/test.html");
            //ReadHttpWebRequest("http://www.itu.dk/people/dpacino/test/");
        }

        public static void ReadHttpWebRequest(String s)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(s);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream respStream = resp.GetResponseStream();
                StreamReader reader = new StreamReader(respStream);
                string pageContent = reader.ReadToEnd();
                Console.WriteLine(pageContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}