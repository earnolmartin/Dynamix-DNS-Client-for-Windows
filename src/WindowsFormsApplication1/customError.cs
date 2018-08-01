using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DynamixDNS
{
    public partial class customError : Form
    {
        // default 10 seconds.
        int intervalTimer = 10000;
        string errorMessage = "";
        public int intervalForTimer
        {
            get
            {
                return intervalTimer;
            }
            set
            {
               intervalTimer = value;
            }
        }
        public customError(string message)
        {
            InitializeComponent();
            errorMessage = message;
            
        }
        public customError(string message, string boxMessage)
        {
            InitializeComponent();
            errorMessage = message;
            errorBox.Text = boxMessage;
            
            
        }

        private void connectionError_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(intervalTimer.ToString());
            timer1.Interval = intervalTimer - 3000;
            timer1.Enabled = true;
            mainError.Text = errorMessage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
