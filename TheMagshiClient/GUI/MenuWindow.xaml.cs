﻿using System;
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
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void CreateRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //Create cw = new MyChildWindow();
            //cw.ShowInTaskbar = false;
            //cw.Owner = Application.Current.MainWindow;
            //cw.Show();
        }
    }
}
