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
        private TcpClient client;
        private NetworkStream stream;
        public Communicator(string serverIp, int port)
        {
            serverPort = port;
            this.serverIp = serverIp;
            client = new TcpClient(serverIp, serverPort);
            stream = client.GetStream();
        }
        string GetServerIp()
        {
            return serverIp;
        }
        int GetServerPort()
        {
            return serverPort;
        }
        private void CloseSocket()
        {
            client.Close();
        }
        public bool SendToServer(LoginRequest request)
        {
            byte[] data = JsonRequestPacketSerializer.serializeRequest(request);
            try
            {
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
        public void recieveRequest(LoginResponse loginResponse)
        {
            byte[] data = new byte[4];
            int status = stream.Read(data, 0, 4), size = 0;
            for (int i = 1; i < 5; i++) size |= data[i] << (24 - (i - 1) * 8);
           
            
        }
    }
}
