using System;
using System.Windows;
using System.Windows.Media;
using TheMagshiClient.GUI;

namespace TheMagshiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly registerWindow registerWindow = App.registerWindow;
        public MainWindow()
        {
            Closing += MainWindow_Closing;
            InitializeComponent();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            QuestionWindow exitWindow = new QuestionWindow("Are you sure you want to leave?", App.CLIENT_NAME);
            exitWindow.Show();
            if (exitWindow.IsYes)
            {
                App.serverCommunicator.CloseSocket();
                Environment.Exit(0);
            }
            else
                e.Cancel = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registerWindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginRequest request = new LoginRequest(UsernameLogin.Text, PasswordLogin.Password.ToString());
            if(!Communicator.SendToServer(request))
            {
                serverMessages.Content = "Failed to send the request to the server check your connections!";
                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                serverMessages.Foreground = brush;
                return;
            }
            while (App.requests.Count == 0) ;
            foreach (ResponseServer response in App.requests)
            {
                if (response.code == (int)Protocols.RESPONSE_SIGNIN)
                {
                    LoginResponse signupResponse = JsonRequestPacketDeserializer.DeserializeLoginRequest(response.data);
                    if (signupResponse.status == (int)Protocols.RESPONSE_SIGNIN)
                    {
                        this.Hide();
                        MenuWindow menue = new MenuWindow(UsernameLogin.Text);
                        menue.Show();
                        break;
                    }
                }
                else if (response.code == (int)Protocols.RESPONSE_ERROR)
                {
                    ErrorResponse errorResponse = JsonRequestPacketDeserializer.DeserializeErrorResponse(response.data);
                    MyMessageBox errorMessage = new MyMessageBox(errorResponse.message, App.CLIENT_NAME);
                    errorMessage.Show();
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
