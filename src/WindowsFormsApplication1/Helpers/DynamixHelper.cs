using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DynamixDNS.Classes;

namespace DynamixDNS.Helpers
{
    public static class DynamixHelper
    {
        public static string settingsFile = AppDomain.CurrentDomain.BaseDirectory + "dynamix.bin";
        public static string endPointURL = "https://dynamix.run/api/public_api.php";
        public static string serviceName = "Dynamix";
        public static BinaryFormatter bformatter = new BinaryFormatter();

        public static DynamixSettings LoadOptions(dyndnsServices dyndnsServices = null)
        {
            DynamixSettings settings = new DynamixSettings();
            try
            {
                if (File.Exists(settingsFile))
                {
                    using (Stream stream = File.Open(settingsFile, FileMode.Open))
                    {
                        settings = (DynamixSettings)bformatter.Deserialize(stream);
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
                if (settings.Hosts.Any())
                {
                    dyndnsServices.hostsBoxDynamix.Items.Clear();
                    dyndnsServices.hostsBoxDynamix.Items.AddRange(settings.Hosts.Select(c => c).ToArray());
                }
                dyndnsServices.enableDynamixCB.Checked = settings.Enabled;
                dyndnsServices.dynamix_user_key_TB.Text = settings.Password;
            }

            return settings;
        }

        public static string SaveOptions(DynamixSettings settings)
        {
            int errors = 0;
            string errorMessage = string.Empty;
            if (string.IsNullOrEmpty(settings.Password) && settings.Enabled)
            {
                errors++;
                errorMessage += "You cannot leave the Dynamix user key field blank!" + Environment.NewLine;
            }

            if (!settings.Hosts.Any() && settings.Enabled)
            {
                errors++;
                errorMessage += "There are no " + serviceName + " hosts to save!" + Environment.NewLine ;
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

        public static string RunUpdates(DynamixSettings settings, string IPAddress)
        {
            string returnStatus = "";
            foreach (string host in settings.Hosts)
            {
                SubdomainDomain info = DomainHelper.getSubdomainDomainFromString(host);
                if (info != null && !string.IsNullOrEmpty(info.domain))
                {
                    string url = endPointURL + "?key=" + settings.Password + "&action=ddns&subaction=update";
                    url += (!string.IsNullOrEmpty(info.subdomain) ? "&subdomain=" + info.subdomain : "");
                    url += "&domain=" + info.domain + "&ip=" + IPAddress;
                    string response = GenericHelper.MakeHTTPGETRequest(url);
                    if (response == "1")
                    {
                        returnStatus += serviceName + " host " + host + " was successfully updated to your current IP address." + Environment.NewLine;
                    }
                    else if (response == "0")
                    {
                        returnStatus += serviceName + " host " + host + " failed to update to your current IP address." + Environment.NewLine;
                    }
                    else if (response.StartsWith("Exception"))
                    {
                        returnStatus += serviceName + " host " + host + " failed to update due to a system exception. " + response.Replace(Environment.NewLine, " ") + Environment.NewLine;
                    }
                    else if (response.StartsWith("error="))
                    {
                        returnStatus += serviceName + " host " + host + " failed to update. " + response.Replace("error=", "");
                    }
                }
            }

            return returnStatus;
        }

        public static List<string> CurrentHosts(string accountKey)
        {
            List<string> hosts = new List<string>();
            try
            {
                string url = endPointURL + "?action=ddns&subaction=getHosts&key=" + accountKey;
                string response = GenericHelper.MakeHTTPGETRequest(url);
                StringReader strReader = new StringReader(response);
                string line = string.Empty;
                while (!string.IsNullOrEmpty(line = strReader.ReadLine()))
                {
                    hosts.Add(line);
                }
            }
            catch
            {

            }
            return hosts;
        }
    }
}
