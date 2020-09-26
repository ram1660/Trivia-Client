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

namespace TheMagshiClient.GUI
{
    /// <summary>
    /// Interaction logic for RoomCreatorWindow.xaml
    /// </summary>
    public partial class RoomCreatorWindow : Window
    {
        public RoomCreatorWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(RoomName.Text.Length == 0 || QuetionCount.Text.Length == 0 || MaxPlayers.Text.Length == 0)
            {
                MyMessageBox lengthError = new MyMessageBox("Error: Please fill all the required fields!", App.CLIENT_NAME);
                lengthError.Show();
            }
            ///if()
        }
    }
}
