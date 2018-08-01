using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DynamixDNS.Classes;
using System.Net;

namespace DynamixDNS.Helpers
{
    public static class NoIPHelper
    {
        public static string settingsFile = AppDomain.CurrentDomain.BaseDirectory + "noip.bin";
        public static string endPointURL = "http://dynupdate.no-ip.com/nic/update?hostname=";
        public static string serviceName = "No-IP";
        public static BinaryFormatter bformatter = new BinaryFormatter();

        public static NoIPDNSSettings LoadOptions(dyndnsServices dyndnsServices = null)
        {
            NoIPDNSSettings settings = new NoIPDNSSettings();
            try
            {
                if (File.Exists(settingsFile))
                {
                    using (Stream stream = File.Open(settingsFile, FileMode.Open))
                    {
                        settings = (NoIPDNSSettings)bformatter.Deserialize(stream);
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
                dyndnsServices.noIPPass.Text = settings.Password;
                dyndnsServices.noIPPassVerify.Text = settings.Password;
                dyndnsServices.noIPEnabled.Checked = settings.Enabled;
                dyndnsServices.noIPHosts.Items.Clear();
                if (settings.Hosts.Any())
                {
                    dyndnsServices.noIPHosts.Items.AddRange(settings.Hosts.ToArray());
                }
                dyndnsServices.noIPLogin.Text = settings.Login;
            }

            return settings;
        }

        public static string SaveOptions(NoIPDNSSettings settings, dyndnsServices dyndnsServices = null)
        {
            int errors = 0;
            string errorMessage = string.Empty;

            if (dyndnsServices != null && settings.Enabled)
            {

                // Perform validation
                if (string.IsNullOrEmpty(dyndnsServices.noIPLogin.Text))
                {
                    errors++;
                    errorMessage += "You must provide your " + serviceName + " login email address!" + Environment.NewLine;
                }
                else
                {
                    if (!GenericHelper.IsValidEmail(dyndnsServices.noIPLogin.Text))
                    {
                        errors++;
                        errorMessage += "You must provide a valid " + serviceName + " login email address!" + Environment.NewLine;
                    }
                }

                if (dyndnsServices.noIPPass.Text != dyndnsServices.noIPPassVerify.Text)
                {
                    errors++;
                    errorMessage += "The " + serviceName + " passwords do not match!" + Environment.NewLine;
                }
                else
                {
                    if (!string.IsNullOrEmpty(dyndnsServices.noIPPass.Text) && !string.IsNullOrEmpty(dyndnsServices.noIPPassVerify.Text))
                    {
                        settings.Password = dyndnsServices.noIPPass.Text;
                    }
                    else
                    {
                        errors++;
                        errorMessage += "You must provide your " + serviceName + " password and confirm the password." + Environment.NewLine;
                    }
                }

                if (dyndnsServices.noIPHosts.Items.Count <= 0)
                {
                    errors++;
                    errorMessage += "There are no " + serviceName + " hosts to save!" + Environment.NewLine;
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

        public static string RunUpdates(NoIPDNSSettings settings, string IPAddress)
        {
            string returnStatus = "";
            foreach (string host in settings.Hosts)
            {
                string url = endPointURL + host + "&myip=" + IPAddress;
                WebAuthentication auth = new WebAuthentication();
                auth.CredCache.Add(new Uri(url), "Basic", new NetworkCredential(settings.Login, settings.Password));
                auth.Agent = "Dynamix DNS Update Client/1.0.0.0 earnolmartin@gmail.com - dynamix.run";
                string response = GenericHelper.MakeHTTPGETRequest(url, auth);
                if (response.StartsWith("Exception"))
                {
                    returnStatus += serviceName + " host " + host + " failed to update due to a system exception. " + response.Replace(Environment.NewLine, " ") + Environment.NewLine;
                }
                else if (response.Trim() != ("good " + IPAddress) && !response.Trim().StartsWith("good " + IPAddress))
                {
                    returnStatus += serviceName + " host " + host + " failed to update to your current IP address. " + response + Environment.NewLine;
                }
                else
                {
                    returnStatus += serviceName + " host " + host + " was successfully updated to your current IP address. " + response + Environment.NewLine;
                }
            }

            return returnStatus;
        }
    }
}
