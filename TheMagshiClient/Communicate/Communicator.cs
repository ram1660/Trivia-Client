using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using System.Threading;
namespace TheMagshiClient
{
    public class Communicator
    {
        private string serverIp;
        private Int32 serverPort;
        private TcpClient client;
        private static NetworkStream stream;
        public Communicator(string serverIp, int port)
        {
            serverPort = port;
            this.serverIp = serverIp;
            client = new TcpClient(serverIp, serverPort);
            stream = client.GetStream();
            //keepAliveThread = new ThreadStart(keepAliveThread);
            //keepThread = new Thread(keepAliveThread);
        }
        string GetServerIp()
        {
            return serverIp;
        }
        int GetServerPort()
        {
            return serverPort;
        }
        public void CloseSocket()
        {
            client.Close();
        }
        public static bool SendToServer(LoginRequest request)
        {
            byte[] data = JsonRequestPacketSerializer.SerializeRequest(request);
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
        public static bool SendToServer(SignupRequest request)
        {
            byte[] data = JsonRequestPacketSerializer.SerializeRequest(request);
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
        public static bool SendToServer(GetPlayersInRoomRequest request)
        {
            byte[] data = JsonRequestPacketSerializer.SerializeRequest(request);
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
        public static bool SendToServer(KeepAliveResponse keepAliveResponse)
        {
            byte[] data = JsonRequestPacketSerializer.SerializeRequest(keepAliveResponse);
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
        public void recieveRequests()
        {
            while (true)
            {
                byte[] data = new byte[5];
                try
                {
                    stream.Read(data, 0, 5);
                }
                catch (IOException)
                {
                    MessageBox.Show("We lost connection with the server closing the app!");
                    Environment.Exit(0);
                }
                int size = 0, code = data[0];
                for (int i = 1; i < 5; i++) size |= data[i] << (24 - (i - 1) * 8);
                byte[] bufferData = new byte[size];
                stream.Read(bufferData, 0, size);
                App.requests.Add(new ResponseServer(code, bufferData));
                if((App.keepThread.ThreadState == ThreadState.Suspended))
                    App.keepThread.Resume();
            }
        }
        public static void KeepAlive()
        {
            while (true)
            {
                if (App.requests.Count == 0)
                    App.keepThread.Suspend();
                ResponseServer response = App.requests.First();
                if(response.code == (int)Protocols.REQUEST_KEEP_ALIVE)
                {
                    App.requests.Remove(response);
                    KeepAliveResponse keepAliveResponse = new KeepAliveResponse((int)Protocols.RESPONSE_KEEP_ALIVE);
                    if (!SendToServer(keepAliveResponse))
                        MessageBox.Show("Failed to send the message!");
                }
            }
        }
    }
}
