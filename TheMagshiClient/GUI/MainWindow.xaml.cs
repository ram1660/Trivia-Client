using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheMagshiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Communicator serverCommunicator;
        public MainWindow()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\config.txt"))
            {
                MessageBox.Show("Could not find config file in the current directory! Creating new one!");
                StreamWriter writer = File.CreateText(Directory.GetCurrentDirectory() + "\\config.txt");
                writer.WriteLine("server_ip:127.0.0.1");
                writer.WriteLine("server_port:7080");
                writer.Close();
                serverCommunicator = new Communicator("127.0.0.1", 7080);
            }
            else
            {
                string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\config.txt");
                string serverIp = lines[0].Substring(10);
                int serverPort = int.Parse(lines[1].Substring(12));
                serverCommunicator = new Communicator(serverIp, serverPort);
            }
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registerWindow register = new registerWindow();
            register.Show();
            this.Close();
        }
        public static Communicator GetCommunicator()
        {
            return serverCommunicator;
        }
    }
}
