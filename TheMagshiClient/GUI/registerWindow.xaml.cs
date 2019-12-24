using System;
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
        static readonly Communicator communicator = App.serverCommunicator;
        private static readonly MainWindow mainWindow = App.mainWindow;
        public registerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //mainWindow.Show();
            App.mainWindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(UsernameTextBox.Text == "" && PasswordRegister.Password.ToString() == "" && EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill all the boxes in order to register!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(UsernameTextBox.Text == "" && PasswordRegister.Password.ToString() == "")
            {
                MessageBox.Show("You have to fill the password and the username boxes!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(UsernameTextBox.Text == "" && EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the username and email boxes!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(PasswordRegister.Password.ToString() == "" && EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the email and the password boxes!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(UsernameTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the username box!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(PasswordRegister.Password.ToString() == "")
            {
                MessageBox.Show("You have to fill the password box!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the email box!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(!Regex.IsMatch(PasswordRegister.Password.ToString(), @"^[a-zA-Z0-9]+$") && PasswordRegister.Password.ToString().Length < 4)
            {
                MessageBox.Show("The password have to contain numbers and letters and be atleast 4 characters!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(!Regex.IsMatch(PasswordRegister.Password.ToString(), @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("The password have to contain numbers and letters.", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(PasswordRegister.Password.ToString().Length < 4)
            {
                MessageBox.Show("The password has to be atleast 4 characters.", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SignupRequest request = new SignupRequest(UsernameTextBox.Text, PasswordRegister.Password.ToString(), EmailTextBox.Text);
            if (!Communicator.SendToServer(request))
            {
                MessageBox.Show("Failed to make a request!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Thread.Sleep(200);
            foreach (ResponseServer response in App.requests)
            {
                if (response.code == (int)Protocols.RESPONSE_SIGNUP)
                {
                    SignupResponse signupResponse = JsonRequestPacketDeserializer.DeserializeSignupRequest(response.data);
                    if (signupResponse.status == (int)Protocols.RESPONSE_SIGNUP)
                    {
                        MessageBox.Show("You have been registered to the system! Please login!", App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Information);
                        MenuWindow menue = new MenuWindow(UsernameTextBox.Text);
                        menue.Show();
                        //this.Hide();
                        //menue.Activate();
                        this.Close();
                        break;
                    }
                }
                else if (response.code == (int)Protocols.RESPONSE_ERROR)
                {
                    ErrorResponse errorResponse = JsonRequestPacketDeserializer.DeserializeErrorResponse(response.data);
                    MessageBox.Show(errorResponse.message, App.CLIENT_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.mainWindow.Show();
        }
    }
}
