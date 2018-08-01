using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DynamixDNS.Classes;

namespace DynamixDNS.Helpers
{
    public static class AfraidDNSHelper
    {
        public static string settingsFile = AppDomain.CurrentDomain.BaseDirectory + "afraid.bin";
        public static string endPointURL = "http://freedns.afraid.org/api/?action=getdyndns&sha=";
        public static string serviceName = "FreeDNS Afraid";
        public static BinaryFormatter bformatter = new BinaryFormatter();
        public static string errorMessage = string.Empty;

        public static AfraidDNSSettings LoadOptions(dyndnsServices dyndnsServices = null)
        {
            AfraidDNSSettings settings = new AfraidDNSSettings();
            try
            {
                if (File.Exists(settingsFile))
                {
                    using (Stream stream = File.Open(settingsFile, FileMode.Open))
                    {
                        settings = (AfraidDNSSettings)bformatter.Deserialize(stream);
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
                dyndnsServices.freeDNSPass.Text = settings.Password;
                dyndnsServices.freeDNSPassVerify.Text = settings.Password;
                dyndnsServices.freeDNSEnable.Checked = settings.Enabled;
                dyndnsServices.freeDNSHosts.Items.Clear();
                if (settings.Hosts.Any())
                {
                    dyndnsServices.freeDNSHosts.Items.AddRange(settings.Hosts.ToArray());
                }
                dyndnsServices.freeDNSLogin.Text = settings.Login;
            }

            return settings;
        }

        public static string SaveOptions(AfraidDNSSettings settings, dyndnsServices dyndnsServices = null)
        {
            int errors = 0;
            string errorMessage = string.Empty;

            if (dyndnsServices != null && settings.Enabled)
            {

                // Perform validation
                if (string.IsNullOrEmpty(dyndnsServices.freeDNSLogin.Text))
                {
                    errors++;
                    errorMessage += "You must provide your " + serviceName + " login!" + Environment.NewLine;
                }

                if (dyndnsServices.freeDNSPass.Text != dyndnsServices.freeDNSPassVerify.Text)
                {
                    errors++;
                    errorMessage += "The " + serviceName + " passwords do not match!" + Environment.NewLine;
                }
                else
                {
                    if (!string.IsNullOrEmpty(dyndnsServices.freeDNSPass.Text) && !string.IsNullOrEmpty(dyndnsServices.freeDNSPass.Text))
                    {
                        settings.Password = dyndnsServices.freeDNSPass.Text;
                    }
                    else
                    {
                        errors++;
                        errorMessage += "You must provide your " + serviceName + " password and confirm the password." + Environment.NewLine;
                    }
                }

                if (dyndnsServices.freeDNSHosts.Items.Count <= 0)
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

        public static string RunUpdates(AfraidDNSSettings settings)
        {
            string returnStatus = "";
            List<FreeDNSURL> hostsToUpdateURLs = CurrentHosts(settings);
            if (hostsToUpdateURLs.Any())
            {
                foreach (FreeDNSURL url in hostsToUpdateURLs)
                {
                    string response = GenericHelper.MakeHTTPGETRequest(url.url);
                    if (response.StartsWith("Exception"))
                    {
                        returnStatus += serviceName + " host " + url.entry + " failed to update due to a system exception. " + response.Replace(Environment.NewLine, " ") + Environment.NewLine;
                    }
                    else if (response.StartsWith("ERROR"))
                    {
                        returnStatus += serviceName + " host " + url.entry + " failed to update to your current IP address. " + response + Environment.NewLine;
                    }
                    else
                    {
                        returnStatus += serviceName + " host " + url.entry + " was successfully updated to point to your current IP address. " + response + Environment.NewLine;
                    }
                }
            }

            return returnStatus;
        }

        public static List<FreeDNSURL> CurrentHosts(AfraidDNSSettings settings)
        {
            List<FreeDNSURL> updateURLs = new List<FreeDNSURL>();
            try
            {
                string url = endPointURL + settings.HashedLogin;
                string response = GenericHelper.MakeHTTPGETRequest(url);
                StringReader strReader = new StringReader(response);
                string line = string.Empty;
                while (!string.IsNullOrEmpty(line = strReader.ReadLine()))
                {
                    string[] parts = line.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        if (settings == null || !settings.Hosts.Any() || settings.Hosts.Contains(parts[0]))
                        {
                            updateURLs.Add(new FreeDNSURL() { url = parts[2], entry = parts[0] });
                        }
                    }
                }
            }
            catch(Exception e)
            {
                errorMessage = e.ToString();
            }
            return updateURLs;
        }
    }

    public class FreeDNSURL
    {
        public string url { get; set; }
        public string entry { get; set; }
    }
}
