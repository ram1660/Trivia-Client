using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace TheMagshiClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<ResponseServer> requests;
        public static Thread keepThread;
        public Thread handleRequestsThread;
        private ThreadStart handleRequestsStarter;
        private ThreadStart keepAliveThread;
        public static Communicator serverCommunicator;
        public static ManualResetEvent resetEvent = new ManualResetEvent(true);
        public static string clientName = "TheMagshiClient";
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!InitializeConnection())
                Environment.Exit(0);
            requests = new List<ResponseServer>();
            keepAliveThread = new ThreadStart(Communicator.KeepAlive);
            keepThread = new Thread(keepAliveThread);
            handleRequestsStarter = new ThreadStart(serverCommunicator.recieveRequests);
            handleRequestsThread = new Thread(handleRequestsStarter);
            keepThread.Start();
            handleRequestsThread.Start();
        }
        public bool InitializeConnection()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\config.txt"))
            {
                MessageBox.Show("Could not find config file in the current directory! Creating new one!", clientName, MessageBoxButton.OK, MessageBoxImage.Information);
                StreamWriter writer = File.CreateText(Directory.GetCurrentDirectory() + "\\config.txt");
                writer.WriteLine("server_ip:127.0.0.1");
                writer.WriteLine("server_port:7080");
                writer.Close();
                try
                {
                    serverCommunicator = new Communicator("127.0.0.1", 7080);
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not connect to the server", clientName, MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
            else
            {
                string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\config.txt");
                string serverIp = lines[0].Substring(10);
                int serverPort = int.Parse(lines[1].Substring(12));
                try
                {
                    serverCommunicator = new Communicator("127.0.0.1", 7080);
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not connect to the server", clientName, MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
        }
    }
}
