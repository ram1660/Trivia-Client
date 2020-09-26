using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMagshiClient.GUI
{
    public partial class QuestionWindow : Form
    {
        public QuestionWindow(string windowName, string message)
        {
            InitializeComponent();
            this.Text = windowName;
            windowMessage.Text = message;
        }

        public bool IsYes { get; set; } = false;

        private void yesButton_Click(object sender, EventArgs e)
        {
            IsYes = true;
        }
        
    }
}
