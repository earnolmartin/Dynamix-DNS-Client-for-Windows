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
    public partial class success : Form
    {
        string messageToDisplay = "";
        int seconds = 0;
        public success(string theMessage)
        {
            messageToDisplay = theMessage;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void success_Load(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
            if (messageToDisplay != "" & messageToDisplay != null)
            {
                message.Text = messageToDisplay;
            }
            else
            {
                message.Text = "There is no message to display!";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 20)
            {
                seconds = 0;
                timer1.Enabled = false;
                this.Close();
            }
            
        }
    }
}
