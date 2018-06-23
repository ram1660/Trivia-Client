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
            string strRequest = JsonConvert.SerializeObject(request);
            int len = strRequest.Length;
            byte code = (byte)Protocols.REQUEST_SIGNIN;
            string strData = code + len + strRequest;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(strData);
            try
            {
                server.Send(data);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ErrorCode);
                return false;
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine("Someting went wrong in " + e.ObjectName);
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Something very wrong that we don't know happened!");
                return false;
            }
            return true;
        }
        public bool SendToServer(SignupRequest request)
        {
            string strRequest = JsonConvert.SerializeObject(request);
            int len = strRequest.Length;
            byte code = (byte)Protocols.REQUEST_SIGNIN;
            string strData = code + len + strRequest;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(strData);
            try
            {
                server.Send(data);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ErrorCode);
                return false;
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine("Someting went wrong in " + e.ObjectName);
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Something very wrong that we don't know happened!");
                return false;
            }
            return true;
        }
        public bool SendToServer(GetPlayersInRoomRequest request)
        {
            try
            {
                server.Send(data);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ErrorCode);
                return false;
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine("Someting went wrong in " + e.ObjectName);
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Something very wrong that we don't know happened!");
                return false;
            }
            return true;
        }
    }
}
