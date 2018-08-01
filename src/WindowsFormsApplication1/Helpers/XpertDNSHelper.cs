using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DynamixDNS.Classes;

namespace DynamixDNS.Helpers
{
    public static class XpertDNSHelper
    {
        public static string settingsFile = AppDomain.CurrentDomain.BaseDirectory + "xpertdns.bin";
        public static string endPointURL = "https://www.xpertdns.com/dyndns.php";
        public static string serviceName = "XpertDNS";
        public static BinaryFormatter bformatter = new BinaryFormatter();

        public static XPertDNSSettings LoadOptions(dyndnsServices dyndnsServices = null)
        {
            XPertDNSSettings settings = new XPertDNSSettings();
            try
            {
                if (File.Exists(settingsFile))
                {
                    using (Stream stream = File.Open(settingsFile, FileMode.Open))
                    {
                        settings = (XPertDNSSettings)bformatter.Deserialize(stream);
                    }
                    settings.Password = GenericHelper.DecodeFrom64(settings.Password);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (dyndnsServices != null)
            {
                dyndnsServices.XPertDNSPass.Text = settings.Password;
                dyndnsServices.XPertDNSConfirmPass.Text = settings.Password;
                dyndnsServices.xpertEnable.Checked = settings.Enabled;
                dyndnsServices.dynIDsXPertDNS.Items.Clear();
                if (settings.Hosts.Any())
                {
                    dyndnsServices.dynIDsXPertDNS.Items.AddRange(settings.Hosts.ToArray());
                }
                dyndnsServices.login4XPertDNS.Text = settings.Login;
            }

            return settings;
        }

        public static string SaveOptions(XPertDNSSettings settings, dyndnsServices dyndnsServices = null)
        {
            int errors = 0;
            string errorMessage = string.Empty;

            if (dyndnsServices != null && settings.Enabled)
            {

                // Perform validation
                if (string.IsNullOrEmpty(dyndnsServices.login4XPertDNS.Text))
                {
                    errors++;
                    errorMessage += "You must provide your " + serviceName + " login email address!" + Environment.NewLine;
                }
                else
                {
                    if (!GenericHelper.IsValidEmail(dyndnsServices.login4XPertDNS.Text))
                    {
                        errors++;
                        errorMessage += "Your " + serviceName + " login must be your email address!" + Environment.NewLine;
                    }
                }

                if (dyndnsServices.XPertDNSPass.Text != dyndnsServices.XPertDNSConfirmPass.Text)
                {
                    errors++;
                    errorMessage += "The " + serviceName + " passwords do not match!" + Environment.NewLine;
                }
                else
                {
                    if (!string.IsNullOrEmpty(dyndnsServices.XPertDNSPass.Text) && !string.IsNullOrEmpty(dyndnsServices.XPertDNSConfirmPass.Text))
                    {
                        settings.Password = dyndnsServices.XPertDNSPass.Text;
                    }
                    else
                    {
                        errors++;
                        errorMessage += "You must provide your " + serviceName + " password and confirm the password." + Environment.NewLine;
                    }
                }

                if (dyndnsServices.dynIDsXPertDNS.Items.Count <= 0)
                {
                    errors++;
                    errorMessage += "There are no " + serviceName + " host IDs to save!" + Environment.NewLine;
                }

            }

            if (errors == 0)
            {
                //serialize
                settings.Password = GenericHelper.EncodeTo64(settings.Password);
                using (Stream stream = File.Open(settingsFile, FileMode.Create))
                {
                    bformatter.Serialize(stream, settings);
                }
            }

            return errorMessage;
        }

        public static string RunUpdates(XPertDNSSettings settings, string IPAddress)
        {
            string returnStatus = "";
            foreach (string host in settings.Hosts)
            {
                string url = endPointURL + "?dynid=" + host + "&ip=" + IPAddress + "&uname=" + settings.Login + "&password=" + settings.MD5Password;
                string response = GenericHelper.MakeHTTPGETRequest(url);
                if (response.StartsWith("Exception"))
                {
                    returnStatus += serviceName + " host ID " + host + " failed to update due to a system exception. " + response.Replace(Environment.NewLine, " ") + Environment.NewLine;
                }
                else if (response.Trim() != (host + "=Successfully Updated=") && !response.Trim().StartsWith(host + "=Successfully Updated="))
                {
                    returnStatus += serviceName + " host ID " + host + " failed to update to your current IP address. " + response + Environment.NewLine;
                }
                else
                {
                    returnStatus += serviceName + " host ID " + host + " was successfully updated to point to your current IP address. " + response + Environment.NewLine;
                }
            }

            return returnStatus;
        }
    }
}
