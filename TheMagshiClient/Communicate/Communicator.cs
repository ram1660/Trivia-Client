using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using System.Windows;

namespace TheMagshiClient
{
    public class Communicator
    {
        private string serverIp;
        private Int32 serverPort;
        public Communicator(string serverIp, int port)
        {
            serverPort = port;
            this.serverIp = serverIp;
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
            byte[] data = JsonRequestPacketSerializer.serializeRequest(request);
            try
            {
                TcpClient client = new TcpClient(serverIp, serverPort);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
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
            byte[] data = JsonRequestPacketSerializer.serializeRequest(request);
            try
            {
                TcpClient client = new TcpClient(serverIp, serverPort);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
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
            byte[] data = JsonRequestPacketSerializer.serializeRequest(request);
            try
            {
                TcpClient client = new TcpClient(serverIp, serverPort);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
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
