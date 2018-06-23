using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for registerWindow.xaml
    /// </summary>
    public partial class registerWindow : Window
    {
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
            if(UsernameTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the username box!");
                return;
            }
            if(PasswordTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the password box!");
                return;
            }
            if(EmailTextBox.Text == "")
            {
                MessageBox.Show("You have to fill the email box!");
                return;
            }
            if(!Regex.IsMatch(PasswordTextBox.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("The password have to contain numbers and letters");
                return;
            }
            if(PasswordTextBox.Text.Length < 4)
            {
                MessageBox.Show("The password has to atleast 4 characters");
                return;
            }
            Communicator communicator = new Communicator();
        }
    }
}
