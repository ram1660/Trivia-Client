using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public MainWindow()
        {
            //if (!File.Exists(Directory.GetCurrentDirectory() + "\\config.txt"))
            //{
            //    MessageBox.Show("Could not find config file in the current directory! Creating new one!");
            //    StreamWriter writer = File.CreateText(Directory.GetCurrentDirectory() + "\\config.txt");
            //    writer.WriteLine("server_ip:127.0.0.1");
            //    writer.WriteLine("server_port:7080");
            //    writer.Close();
            //    try
            //    {
            //        if(serverCommunicator == null)
            //            serverCommunicator = new Communicator("127.0.0.1", 7080);
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Could not connect to server");
            //        this.Close();
            //        return;
            //    }
            //}
            //else
            //{
            //    string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\config.txt");
            //    string serverIp = lines[0].Substring(10);
            //    int serverPort = int.Parse(lines[1].Substring(12));
            //    try
            //    {
            //        if(serverCommunicator == null)
            //            serverCommunicator = new Communicator("127.0.0.1", 7080);
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Could not connect to server");
            //        this.Close();
            //        return;
            //    }
            //}
            Closing += MainWindow_Closing;
            InitializeComponent();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registerWindow register = new registerWindow();
            register.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginRequest request = new LoginRequest(UsernameLogin.Text, PasswordLogin.Password.ToString());
            if(!Communicator.SendToServer(request))
            {
                MessageBox.Show("Failed to send the request to the server check your connections!");
                return;
            }
            Thread.Sleep(50);
            for (int i = 0; i < App.requests.Count; i++)
            {
                if(App.requests[i].code == (int)Protocols.RESPONSE_SIGNIN)
                {
                    LoginResponse loginResponse = JsonRequestPacketDeserializer.DeserializeLoginRequest(App.requests[i].data);
                    if (loginResponse.status == (int)Protocols.RESPONSE_SIGNIN)
                    {
                        this.Close();
                        MenuWindow menue = new MenuWindow();
                        menue.Show();
                        break;
                    }
                }
                else if(App.requests[i].code == (int)Protocols.RESPONSE_ERROR)
                {
                    ErrorResponse errorResponse = JsonRequestPacketDeserializer.DeserializeErrorResponse(App.requests[i].data);
                    MessageBox.Show(errorResponse.message);
                    break;
                }
            }

        }
    }
}
