using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using DynamixDNS.Helpers;
using DynamixDNS.Classes;

namespace DynamixDNS
{
    public partial class options : Form
    {
        string scriptPath = "";
        DynamixDNSSettings appSettings = new DynamixDNSSettings();

        public options()
        {
            InitializeComponent();
        }

        private void saveSettings_Click(object sender, EventArgs e)
        {
            AppHelper.SaveOptions(this);
            this.Close();
        }

        private void options_Load(object sender, EventArgs e)
        {
            getSavedOptions();
        }
        private void getSavedOptions()
        {
            appSettings = AppHelper.LoadOptions(this);
        }

        private void browseScriptButton_Click(object sender, EventArgs e)
        {
            scriptPath = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                scriptPath = openFileDialog1.FileName;
            }
            if (File.Exists(scriptPath))
            {

                if (!string.IsNullOrEmpty(scriptPath))
                {
                    if (!string.IsNullOrEmpty(scriptText.Text))
                    {
                        scriptText.Text += "," + scriptPath;
                    }
                    else
                    {
                        scriptText.Text += scriptPath;
                    }
                }
            }
            else
            {
                if (scriptPath != "" & scriptPath != null)
                {
                    MessageBox.Show(scriptPath + " is not a valid file to run.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No script file was selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                scriptPath = "";
            }
        }

        private void clearScripts_Click(object sender, EventArgs e)
        {
            scriptText.Text = "";
        }

        private void configOtherDynDNS_Click(object sender, EventArgs e)
        {
            dyndnsServices configure = new dyndnsServices();
            configure.ShowDialog();
        }
    }
}
