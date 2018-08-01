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
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using DynamixDNS.Classes;
using DynamixDNS.Helpers;

namespace DynamixDNS
{
    public partial class dyndnsServices : Form
    {
        Encoding utf = new UTF8Encoding();
        string saveSuccess = "";
        int errorCount = 0, successCount = 0;
        DynamixSettings dynamixSettings = new DynamixSettings();
        XPertDNSSettings xpertDNSSettings = new XPertDNSSettings();
        AfraidDNSSettings afraidDNSSettings = new AfraidDNSSettings();
        NoIPDNSSettings noIPSettings = new NoIPDNSSettings();
        public dyndnsServices()
        {
            InitializeComponent();
        }

        private void AddExpertDNS_Click(object sender, EventArgs e)
        {
            if (xpertHostIDField.Text != "" & xpertHostIDField.Text != null & !dynIDsXPertDNS.Items.Contains(xpertHostIDField.Text))
            {
                double Num;
                bool isNum = double.TryParse(xpertHostIDField.Text, out Num);
                if (isNum)
                {
                    // Adds entry to list box
                    dynIDsXPertDNS.Items.Add(xpertHostIDField.Text);
                }
                else
                {
                    MessageBox.Show("Host IDs must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Host ID was entered, the host was entered improperly, or the host already exists in the item list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            xpertHostIDField.Text = "";
            xpertHostIDField.Focus();
        }

        private void removeXPertDNS_Click(object sender, EventArgs e)
        {
            if (dynIDsXPertDNS.SelectedIndex != -1)
            {
                int toRemove = dynIDsXPertDNS.SelectedIndex;
                dynIDsXPertDNS.Items.RemoveAt(toRemove);
            }
            dynIDsXPertDNS.Focus();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            /*            if(xpertEnable.Checked == false & (login4XPertDNS.Text != "" | XPertDNSPass.Text != "" | XPertDNSConfirmPass.Text != "" | dynIDsXPertDNS.Items.Count > 0)){
                MessageBox.Show("Warning:  Your updated settings will not save unless you enable this server!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             */
            errorCount = 0;
            saveSuccess = "";
            successCount = 0;
            saveAllSettings();
            if (successCount > 0)
            {
                success Yes = new success(saveSuccess);
                Yes.Show();
            }
        }

        private void saveXpertSettings()
        {
            XPertDNSSettings xSettings = new XPertDNSSettings();
            xSettings.Enabled = xpertEnable.Checked;
            xSettings.Hosts = dynIDsXPertDNS.Items.Cast<String>().ToList();
            xSettings.Login = login4XPertDNS.Text;

            var success = XpertDNSHelper.SaveOptions(xSettings, this);

            if (string.IsNullOrEmpty(success))
            {
                successCount++;
                saveSuccess += "Your " + XpertDNSHelper.serviceName + " settings were successfully saved! \n";
            }
            else
            {
                customError err = new customError("You have the following problems with your " + XpertDNSHelper.serviceName + " Settings!", success);
                err.intervalForTimer = 30000;
                err.Show();
                errorCount++;
            }
        }


        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public string HashCode(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 =
            new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(
                cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }


        private void dyndnsServices_Load(object sender, EventArgs e)
        {
            getXpertSettings();
            getNoIPSettings();
            getFreeDNSSettings();
            getDynamixSettings();
        }

        private void getXpertSettings()
        {
            xpertDNSSettings = XpertDNSHelper.LoadOptions(this);
        }

        private void getNoIPSettings()
        {
            noIPSettings = NoIPHelper.LoadOptions(this);
        }

        private void getFreeDNSSettings()
        {
            afraidDNSSettings = AfraidDNSHelper.LoadOptions(this);
        }

        private void getDynamixSettings()
        {
            dynamixSettings = DynamixHelper.LoadOptions(this);
        }

        private void noIPAdd_Click(object sender, EventArgs e)
        {
            if (noIPHost.Text != "" & noIPHost.Text != null & noIPHost.Text.IndexOf(".") != -1)
            {
                string filteredDomain = DomainHelper.filterDomain(noIPHost.Text.ToString());
                if (DomainHelper.isValidSubdomainOrDomain(filteredDomain))
                {
                    if (!noIPHosts.Items.Contains(filteredDomain))
                    {
                        // Adds entry to list box
                        noIPHosts.Items.Add(filteredDomain);
                    }
                    else
                    {
                        MessageBox.Show("The host of " + filteredDomain + " already exists in the item list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The host of " + filteredDomain + " is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Host ID was entered or the host was entered improperly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            noIPHost.Text = "";
            noIPHost.Focus();
        }

        private void noIPRemove_Click(object sender, EventArgs e)
        {
            if (noIPHosts.SelectedIndex != -1)
            {
                int toRemove = noIPHosts.SelectedIndex;
                noIPHosts.Items.RemoveAt(toRemove);
            }
            noIPHosts.Focus();
        }

        private void saveDynamixSettings()
        {
            saveDynamixSettingsLogic();
        }

        private void saveDynamixSettingsLogic()
        {
            // UI to class
            DynamixSettings updatedSettings = new DynamixSettings();
            updatedSettings.Enabled = enableDynamixCB.Checked;
            updatedSettings.Password = dynamix_user_key_TB.Text;
            updatedSettings.Hosts = hostsBoxDynamix.Items.Cast<String>().ToList();

            // Save the options using our static class
            string result = DynamixHelper.SaveOptions(updatedSettings);

            // Display any errors
            if (result != string.Empty)
            {
                customError err = new customError("You have the following problems with your Dynamix settings!", result);
                err.intervalForTimer = 30000;
                err.Show();
                errorCount++;
            }
            else
            {
                successCount++;
                saveSuccess += "Your " + DynamixHelper.serviceName + " settings were successfully saved! \n";
            }

        }

        private void saveNoIPSettings()
        {

            NoIPDNSSettings noIPSettings = new NoIPDNSSettings();
            noIPSettings.Enabled = noIPEnabled.Checked;
            noIPSettings.Hosts = noIPHosts.Items.Cast<String>().ToList();
            noIPSettings.Login = noIPLogin.Text;

            string result = NoIPHelper.SaveOptions(noIPSettings, this);
            if (result != string.Empty)
            {
                customError err = new customError("You have the following problems with your " + NoIPHelper.serviceName + " settings!", result);
                err.intervalForTimer = 30000;
                err.Show();
                errorCount++;
            }
            else
            {
                successCount++;
                saveSuccess += "Your " + NoIPHelper.serviceName + " settings were successfully saved! \n";
            }
        }

        private void saveFreeDNSSettings()
        {

            AfraidDNSSettings aSettings = new AfraidDNSSettings();
            aSettings.Enabled = freeDNSEnable.Checked;
            aSettings.Hosts = freeDNSHosts.Items.Cast<String>().ToList();
            aSettings.Login = freeDNSLogin.Text;

            var success = AfraidDNSHelper.SaveOptions(aSettings, this);

            if (string.IsNullOrEmpty(success))
            {
                successCount++;
                saveSuccess += "Your " + AfraidDNSHelper.serviceName + " settings were successfully saved! \n";
            }
            else
            {
                customError err = new customError("You have the following problems with your " + AfraidDNSHelper.serviceName + " Settings!", success);
                err.intervalForTimer = 30000;
                err.Show();
                errorCount++;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorCount = 0;
            saveSuccess = "";
            successCount = 0;
            saveAllSettings();
            if (successCount > 0)
            {
                success Yes = new success(saveSuccess);
                Yes.Show();
            }
        }

        private void saveAllSettings()
        {
            saveXpertSettings();
            saveNoIPSettings();
            saveFreeDNSSettings();
            saveDynamixSettings();
        }

        private void retreiveHostsButton_Click(object sender, EventArgs e)
        {
            AfraidDNSSettings temp = new AfraidDNSSettings();
            temp.Login = freeDNSLogin.Text;
            temp.Password = freeDNSPass.Text;
            var hosts = AfraidDNSHelper.CurrentHosts(temp);
            if (hosts.Any())
            {
                freeDNSHosts.Items.Clear();
                foreach (var host in hosts)
                {
                    freeDNSHosts.Items.Add(host.entry);
                }
            }
            else
            {
                MessageBox.Show("Failed to retrieve hosts from " + AfraidDNSHelper.serviceName + "! Please make sure you've entered your login and password." + Environment.NewLine + Environment.NewLine + AfraidDNSHelper.errorMessage, "Generic Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void freeDNSRemove_Click_1(object sender, EventArgs e)
        {
            if (freeDNSHosts.SelectedIndex != -1)
            {
                freeDNSHosts.Items.RemoveAt(freeDNSHosts.SelectedIndex);
            }
            freeDNSHosts.Focus();
        }

        private void removeDynamixHost_Click(object sender, EventArgs e)
        {
            if (hostsBoxDynamix.SelectedIndex != -1)
            {
                int toRemove = hostsBoxDynamix.SelectedIndex;
                hostsBoxDynamix.Items.RemoveAt(toRemove);
            }
            hostsBoxDynamix.Focus();
        }

        private void retrieveDynamixHostsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dynamix_user_key_TB.Text))
            {
                var hosts = DynamixHelper.CurrentHosts(dynamix_user_key_TB.Text);
                if (hosts.Any())
                {
                    hostsBoxDynamix.Items.Clear();
                    foreach (var host in hosts)
                    {
                        hostsBoxDynamix.Items.Add(host);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve " + DynamixHelper.serviceName + " hosts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter your account user key first before attempting to retrieve hosts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
