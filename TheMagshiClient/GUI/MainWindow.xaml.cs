﻿using System;
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
            Closing += MainWindow_Closing;
            InitializeComponent();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to leave?", App.clientName, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.serverCommunicator.CloseSocket();
                Environment.Exit(0);
            }
            else
                e.Cancel = true;
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
                MessageBox.Show("Failed to send the request to the server check your connections!", App.clientName, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Thread.Sleep(200);
            foreach (ResponseServer response in App.requests)
            {
                if (response.code == (int)Protocols.RESPONSE_SIGNIN)
                {
                    LoginResponse signupResponse = JsonRequestPacketDeserializer.DeserializeLoginRequest(response.data);
                    if (signupResponse.status == (int)Protocols.RESPONSE_SIGNIN)
                    {
                        this.Close();
                        MenuWindow menue = new MenuWindow();
                        menue.Show();
                        break;
                    }
                }
                else if (response.code == (int)Protocols.RESPONSE_ERROR)
                {
                    ErrorResponse errorResponse = JsonRequestPacketDeserializer.DeserializeErrorResponse(response.data);
                    MessageBox.Show(errorResponse.message, App.clientName, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            App.serverCommunicator.CloseSocket();
            Environment.Exit(0);
        }
    }
}
