using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
namespace TheMagshiClient
{
    class Communicator
    {
        private string serverIp;
        private int serverPort;
        private Socket server;
        public Communicator(string serverIp, int port)
        {
            this.serverIp = serverIp;
            serverPort = port;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = new IPAddress(byte.Parse(serverIp));
            try
            {
                server.Connect(new IPEndPoint(iPAddress, port));
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }
        string GetServerIp()
        {
            return serverIp;
        }
        int GetServerPort()
        {
            return serverPort;
        }
        public bool SendToServer(LoginRequest request)
        {
            DataC
            return true;
        }
    }
}
