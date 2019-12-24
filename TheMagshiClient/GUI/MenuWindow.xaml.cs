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
    }
}
