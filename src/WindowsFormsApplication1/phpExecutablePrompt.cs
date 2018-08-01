using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DynamixDNS
{
    public partial class phpExecutablePrompt : Form
    {
        string PHPPath = "";
        int success = 0;
        public phpExecutablePrompt()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openPHPDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                PHPPath = openPHPDialog.FileName;
                phpPathEXE.Text = PHPPath;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (PHPPath != "" & PHPPath != null)
            {
                checkPath();
                if (success == 1)
                {
                    if (!File.Exists(mainDynamix.phpPathFile))
                    {
                        FileStream fs = File.Open(mainDynamix.phpPathFile, FileMode.CreateNew);
                        fs.Close();
                        using (StreamWriter outfile = new StreamWriter(mainDynamix.phpPathFile))
                        {
                            outfile.Write(PHPPath);
                            outfile.Close();
                        }
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error!", "The path you selected is invalid.  The path must end with php.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void checkPath()
        {
            if (PHPPath.Substring(PHPPath.LastIndexOf("\\") + 1) != "php.exe")
            {
                success = 0;
            }
            else
            {
                success = 1;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        internal string getPath()
        {
            if (PHPPath != "" & PHPPath != null)
            {
                return PHPPath;
            }
            else
            {
                return "";
            }
        }

    }
}
