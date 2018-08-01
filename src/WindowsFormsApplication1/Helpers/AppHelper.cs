using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DynamixDNS.Classes;

namespace DynamixDNS.Helpers
{
    public static class AppHelper
    {
        public static string settingsFile = AppDomain.CurrentDomain.BaseDirectory + "appSettings.bin";
        public static BinaryFormatter bformatter = new BinaryFormatter();

        public static DynamixDNSSettings LoadOptions(options options = null)
        {
            DynamixDNSSettings settings = new DynamixDNSSettings();
            try
            {
                if (File.Exists(settingsFile))
                {
                    using (Stream stream = File.Open(settingsFile, FileMode.Open))
                    {
                        settings = (DynamixDNSSettings)bformatter.Deserialize(stream);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (options != null)
            {
                switch (settings.TimeIntervalMode)
                {
                    case 1:
                    default:
                        options.timeSeconds.Checked = true;
                        break;
                    case 2:
                        options.timeMinutes.Checked = true;
                        break;
                    case 3:
                        options.timeHours.Checked = true;
                        break;
                }

                options.intTimeInserted.Text = settings.TimeInterval.ToString();
                options.autoStart.Checked = settings.AutoStart;

                switch (settings.IPService)
                {
                    case 1:
                        options.dynamix.Checked = true;
                        break;
                    case 2:
                        options.grabIP.Checked = true;
                        break;
                    default:
                    case 3:
                        options.dinofly.Checked = true;
                        break;
                }

                options.dynServicesBox.Checked = settings.RunDynamicServices;

                if (settings.ExternalScriptToRun.Any())
                {
                    options.scriptText.Text = String.Join(",", settings.ExternalScriptToRun);
                }
            }

            return settings;
        }

        public static string SaveOptions(options options)
        {
            string errorMessage = string.Empty;
            DynamixDNSSettings settings = new DynamixDNSSettings();

            if (options.timeSeconds.Checked)
            {
                settings.TimeIntervalMode = 1;
            }
            else if (options.timeMinutes.Checked)
            {
                settings.TimeIntervalMode = 2;
            }
            else if (options.timeHours.Checked)
            {
                settings.TimeIntervalMode = 3;
            }
            else
            {
                settings.TimeInterval = 1;
            }

            if (!string.IsNullOrEmpty(options.intTimeInserted.Text) && GenericHelper.IsNumeric(options.intTimeInserted.Text))
            {
                settings.TimeInterval = Convert.ToInt32(options.intTimeInserted.Text);
                if (settings.TimeInterval < 10 && settings.TimeIntervalMode == 1)
                {
                    settings.TimeInterval = 10;
                    options.intTimeInserted.Text = "10";
                }
            }
            else
            {
                settings.TimeInterval = 60;
            }

            if (options.dynamix.Checked == true)
            {
                settings.IPService = 1;
            }
            else if (options.dinofly.Checked == true)
            {
                settings.IPService = 3;
            }
            else if (options.grabIP.Checked == true)
            {
                settings.IPService = 2;
            }
            else
            {
                settings.IPService = 1;
            }

            if (options.dynServicesBox.Checked)
            {
                settings.RunDynamicServices = true;
            }
            else
            {
                settings.RunDynamicServices = false;
            }

            if (!string.IsNullOrEmpty(options.scriptText.Text))
            {
                settings.ExternalScriptToRun = options.scriptText.Text.Split(',').ToList();
            }

            //serialize
            using (Stream stream = File.Open(settingsFile, FileMode.Create))
            {
                bformatter.Serialize(stream, settings);
            }

            return errorMessage;
        }
    }
}
