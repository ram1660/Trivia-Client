using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace TheMagshiClient.GUI
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox(string message, string windowName)
        {
            InitializeComponent();
            this.Text = windowName;
            windowMessage.Text = message;
        }
        
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
