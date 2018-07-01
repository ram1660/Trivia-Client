﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TheMagshiClient
{
    /// <summary>
    /// Interaction logic for registerWindow.xaml
    /// </summary>
    public partial class registerWindow : Window
    {
        static Communicator communicator = App.serverCommunicator;
        public registerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(UsernameTextBox.Text == "" && PasswordRegister.Password.ToString() == "" && EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill all the boxes in order to register!");
                return;
            }
            if(UsernameTextBox.Text == "" && PasswordRegister.Password.ToString() == "")
            {
                MessageBox.Show("You have to fill the password and the username boxes!");
                return;
            }
            if(UsernameTextBox.Text == "" && EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the username and email boxes!");
                return;
            }
            if(PasswordRegister.Password.ToString() == "" && EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the email and the password boxes!");
            }
            if(UsernameTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the username box!");
                return;
            }
            if(PasswordRegister.Password.ToString() == "")
            {
                MessageBox.Show("You have to fill the password box!");
                return;
            }
            if(EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the email box!");
                return;
            }
            if(!Regex.IsMatch(PasswordRegister.Password.ToString(), @"^[a-zA-Z0-9]+$") && PasswordRegister.Password.ToString().Length < 4)
            {
                MessageBox.Show("The password have to contain numbers and letters and be atleast 4 characters!");
                return;
            }
            if(!Regex.IsMatch(PasswordRegister.Password.ToString(), @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("The password have to contain numbers and letters.");
                return;
            }
            if(PasswordRegister.Password.ToString().Length < 4)
            {
                MessageBox.Show("The password has to be atleast 4 characters.");
                return;
            }
            SignupRequest request = new SignupRequest(UsernameTextBox.Text, PasswordRegister.Password.ToString(), EmailTextBox.Text);
            if (!Communicator.SendToServer(request))
            {
                MessageBox.Show("Failed to make a request!");
                return;
            }
            Thread.Sleep(200);
            foreach (ResponseServer response in App.requests)
            {
                if (response.code == (int)Protocols.RESPONSE_SIGNUP)
                {
                    SignupResponse signupResponse = JsonRequestPacketDeserializer.DeserializeSignupRequest(response.data);
                    if (signupResponse.status == (int)Protocols.REQUEST_SIGNUP)
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
                    MessageBox.Show(errorResponse.message);
                    break;
                }
            }
        }
    }
}
