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

namespace TheMagshiClient.GUI
{
    /// <summary>
    /// Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        public HighscoreWindow(List<HighscoreRecord> records)
        {
            InitializeComponent();
            foreach (HighscoreRecord record in records)
            {
                HighscoreTable.Items.Add(record);
            }
        }
    }
}
