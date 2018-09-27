using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class Program
    {
        private static TcpClient _clientSocket = null;
        private static Stream stream = null;
        private static StreamWriter Writer = null;
        private static StreamReader Reader = null;
        static void Main(string[] args)
        {
            try
            {
                using (_clientSocket=new TcpClient("127.0.0.1", 8080))
                {
                    using (stream = _clientSocket.GetStream())
                    {
                        while (true)
                        {
                            Writer = new StreamWriter(stream) { AutoFlush = true };
                           
                            Console.WriteLine("Write your request here ");
                            string clientMsg = Console.ReadLine();

                            Writer.WriteLine(clientMsg);

                            Reader = new StreamReader(stream);
                            string rdMsgFromServer = Reader.ReadLine();
                            if (rdMsgFromServer != null)
                            {
                                Console.WriteLine("Client recieved Message from Server:" + rdMsgFromServer);
                            }
                            else
                            {
                                Console.WriteLine("Client recieved null message from Server ");
                            }
                            
                           
                        }
                    }
                }
            

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }

    }

}