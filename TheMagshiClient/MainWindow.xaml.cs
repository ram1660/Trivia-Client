﻿using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheMagshiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Communicator serverCommunicator;
        public MainWindow()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\config.txt"))
            {
                MessageBox.Show("Could not find config file in the current directory! Creating new one!");
                StreamWriter writer = File.CreateText(Directory.GetCurrentDirectory() + "\\config.txt");
                writer.WriteLine("server_ip: 127.0.0.1");
                writer.WriteLine("server_port: 8070");

            }
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registerWindow register = new registerWindow();
            register.Show();
            this.Close();
        }
    }
}
