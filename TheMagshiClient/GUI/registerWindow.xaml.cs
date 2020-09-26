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
using TheMagshiClient.GUI;
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
            MyMessageBox messageBox = new MyMessageBox("You have to fill all the boxes in order to register!", App.CLIENT_NAME);
            if (UsernameTextBox.Text == "" && PasswordRegister.Password.ToString() == "" && EmailTextBox.Text == "")
            {
                messageBox.ShowDialog();
                return;
            }
            if(UsernameTextBox.Text == "" && PasswordRegister.Password.ToString() == "")
            {
                messageBox.Text = "You have to fill the password and the username boxes!";
                messageBox.ShowDialog();
                return;
            }
            if(UsernameTextBox.Text == "" && EmailTextBox.Text == "")
            {
                messageBox.Text = "You have to fill the username and email boxes!";
                messageBox.ShowDialog();
                return;
            }
            if(PasswordRegister.Password.ToString() == "" && EmailTextBox.Text == "")
            {
                messageBox.Text = "You have to fill the email and the password boxes!";
                messageBox.ShowDialog();
                return;
            }
            if(UsernameTextBox.Text == "")
            {
                messageBox.Text = "You have to fill the username box!";
                messageBox.ShowDialog();
                return;
            }
            if(PasswordRegister.Password.ToString() == "")
            {
                messageBox.Text = "You have to fill the password box!";
                messageBox.ShowDialog();
                return;
            }
            if(EmailTextBox.Text == "")
            {
                messageBox.Text = "You have to fill the email box!";
                messageBox.ShowDialog();
                return;
            }
            if(!Regex.IsMatch(PasswordRegister.Password.ToString(), @"^[a-zA-Z0-9]+$") && PasswordRegister.Password.ToString().Length < 4)
            {
                messageBox.Text = "The password have to contain numbers and letters and be atleast 4 characters!";
                messageBox.ShowDialog();
                return;
            }
            if(!Regex.IsMatch(PasswordRegister.Password.ToString(), @"^[a-zA-Z0-9]+$"))
            {
                messageBox.Text = "The password have to contain numbers and letters.";
                messageBox.ShowDialog();
                return;
            }
            if(PasswordRegister.Password.ToString().Length < 4)
            {
                messageBox.Text = "The password has to be atleast 4 characters.";
                messageBox.ShowDialog();
                return;
            }
            SignupRequest request = new SignupRequest(UsernameTextBox.Text, PasswordRegister.Password.ToString(), EmailTextBox.Text);
            if (!Communicator.SendToServer(request))
            {
                messageBox.Text = "Failed to make a request!";
                messageBox.ShowDialog();
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
                        messageBox.Text = "You have been registered to the system! Please login!";
                        messageBox.ShowDialog();
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
                    messageBox.Text = errorResponse.message;
                    messageBox.ShowDialog();
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
