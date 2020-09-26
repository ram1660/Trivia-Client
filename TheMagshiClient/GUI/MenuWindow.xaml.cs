using System;
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
using System.Windows.Shapes;
using System.Threading;
using TheMagshiClient.GUI;
namespace TheMagshiClient
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly string PLAYER_NAME;
        public MenuWindow(string userName)
        {
            PLAYER_NAME = userName; 
            InitializeComponent();
            string welcomeText = userNameLabel.Content.ToString();
            welcomeText = string.Format(welcomeText, PLAYER_NAME);
            userNameLabel.Content = welcomeText;
        }

        private void CreateRoomButton_Click(object sender, RoutedEventArgs e)
        {
            CreateRoomButton.IsEnabled = false;
            JoinRoomButton.IsEnabled = false;
            StatsButton.IsEnabled = false;
            HighscoreButton.IsEnabled = false;
            LogoutButton.IsEnabled = false;

            //Create cw = new MyChildWindow();
            //cw.ShowInTaskbar = false;
            //cw.Owner = Application.Current.MainWindow;
            //cw.Show();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Communicator.SendToServer(new DisconnectRequest((int)Protocols.REQUEST_SIGNOUT, PLAYER_NAME));
            this.Hide();
            App.mainWindow.Show();
        }

        private void HighscoreButton_Click(object sender, RoutedEventArgs e)
        {
            Communicator.SendToServer(new HighscoreRequest((int)Protocols.REQUEST_GET_HIGHSCORE));
            Thread.Sleep(200);
            foreach (ResponseServer response in App.requests)
            {
                if(response.code == (int)Protocols.RESPONSE_GET_HIGHSCORE)
                {
                    HighscoreResponse highscoreResponse = JsonRequestPacketDeserializer.DeserializeHighscoreResponse(response.data);
                    this.Hide();
                    HighscoreWindow highscoreWindow = new HighscoreWindow(highscoreResponse.highscores);
                    highscoreWindow.Show();
                    break;
                }
                else if(response.code == (int)Protocols.RESPONSE_ERROR)
                {
                    ErrorResponse errorResponse = JsonRequestPacketDeserializer.DeserializeErrorResponse(response.data);
                    MyMessageBox errorWindow = new MyMessageBox(errorResponse.message, App.CLIENT_NAME + " Error");
                    return;
                }
            }
            
        }
    }
}
