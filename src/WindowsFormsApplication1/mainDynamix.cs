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
using System.Diagnostics;
using System.Text.RegularExpressions;
using DynamixDNS.Classes;
using DynamixDNS.Helpers;


namespace DynamixDNS
{

    

    public partial class mainDynamix : Form
    {
        string IPAddress = "", oldIP, urlForIPCheck = "", dynamixStartupEntryName = "Dynamix DNS Client.lnk";
        public string phpPath = "";
        DynamixSettings dynamixSettings = new DynamixSettings();
        DynamixDNSSettings appSettings = new DynamixDNSSettings();
        XPertDNSSettings XpertDNSSettings = new XPertDNSSettings();
        AfraidDNSSettings afraidDNSSettings = new AfraidDNSSettings();
        NoIPDNSSettings noIPDNSSettings = new NoIPDNSSettings();
        int seconds = 0, minutes = 0, hours = 0;
        public static string oldIPFile = AppDomain.CurrentDomain.BaseDirectory + "oldip.txt";
        public static string phpPathFile = AppDomain.CurrentDomain.BaseDirectory + "phpPath.txt";

        public mainDynamix()
        {
            InitializeComponent();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)3072;
        }

        private void Dynamix_Load(object sender, EventArgs e)
        {
            checkOptionsExist();
            // Getting External IP
            IPAddress = getExternalIP();
            if (!string.IsNullOrEmpty(IPAddress))
            {
                currentIP.Text = IPAddress;
                updateIP();
            }
        }

        private string getExternalIP()
        {
            try
            {
                if (string.IsNullOrEmpty(urlForIPCheck))
                {
                    urlForIPCheck = "https://dynamix.run/ip.php";
                }
                var response = GenericHelper.MakeHTTPGETRequest(urlForIPCheck);

                //Search for the ip in the html
                int first = response.IndexOf("Address: ") + 9;
                int last = response.LastIndexOf("</body>");
                if (first != -1 && last != -1)
                {
                    response = response.Substring(first, last - first);
                }
                response = GenericHelper.ParseIPv4Addr(response);

                //Write the IP to oldip.txt
                if (!string.IsNullOrEmpty(response) && GenericHelper.CheckIPValid(response))
                {
                    if (!File.Exists(oldIPFile))
                    {
                        writeOldIP(response);
                        oldIP = response;
                    }
                    else
                    {
                        oldIP = loadOldIP();
                    }
                    currentIP.Text = response;
                }
                resetTimeLabels();
                return response;
            }
            catch
            {
                resetTimeLabels();
                customError unableToConnect = new customError("Unable to determine your external IP address.", "Unable to contact " + urlForIPCheck + "\nA firewall has blocked the connection!\nYou have no connection to the internet!");
                if (timer1.Enabled == true)
                {
                    if (timer1.Interval > 10000)
                    {
                        unableToConnect.intervalForTimer = timer1.Interval;
                    }
                    else
                    {
                        unableToConnect.intervalForTimer = 10000;
                    }
                }
                else
                {
                    unableToConnect.intervalForTimer = 10000;
                }
                unableToConnect.Show();
                //MessageBox.Show(" \n\tPossible causes:\n\t No internet connection\n\t DynDns IP service down.", "Error Determining IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }


        private void scanButton_Click(object sender, EventArgs e)
        {
            startScanning();
        }

        private string loadOldIP()
        {
            if (File.Exists(oldIPFile))
            {
                return File.ReadAllText(oldIPFile);
            }

            return string.Empty;
        }

        private void writeOldIP(string IP)
        {
            File.WriteAllText(oldIPFile, IP);
        }

        private void updateIP()
        {
            if (oldIP != IPAddress && GenericHelper.CheckIPValid(IPAddress) && GenericHelper.CheckIPValid(oldIP))
            {
                stopScanningInterval();

                // Run configured external applications for when the IP address changes and pass in the parameters
                runExternalApps();

                // Run IP updating services
                runInternetServices();

                writeOldIP(IPAddress);
                oldIPLabel.Text = oldIP;
                oldIPLabel.Visible = true;
                oldIPLabelText.Visible = true;

                // Restart the scanning
                startScanning();
            }
        }

        private void runExternalApps()
        {
            if (appSettings.ExternalScriptToRun.Any())
            {
                string errorsForScripts = "", successesForScripts = "";
                foreach (string prog in appSettings.ExternalScriptToRun)
                {
                    // Add the positonal parameters
                    // Send oldIP and newIP values for to all executables
                    string parameters = " " + oldIP + " " + IPAddress;
                    string extension = "";
                    if (File.Exists(prog))
                    {
                        // Check and see if the program has a valid extension.  If it is, run it... if not, show error!
                        if (prog.LastIndexOf('.') == -1)
                        {
                            extension = "NO_EXTENSION";
                        }
                        else
                        {
                            extension = prog.Substring(prog.LastIndexOf('.'));
                        }
                        switch (extension)
                        {
                            case ".php":
                                // Add the positonal parameters
                                // Send oldIP and newIP values for to all executables
                                string runPHPProg = "\"" + prog + "\"" + parameters;

                                // phpPath will not be set to "" if they were prompted in the past for a PHP path since it didn't exist where it was supposed to be (perhaps no installation of Dynamix DNS).
                                if (phpPath != "")
                                {
                                    processRun(phpPath, runPHPProg);
                                    successesForScripts += prog + " ran successfully!\n";
                                }
                                else
                                {
                                    phpExecutablePrompt phpNew = new phpExecutablePrompt();
                                    if (Application.OpenForms.OfType<phpExecutablePrompt>().Count() > 0)
                                    {

                                    }
                                    else
                                    {
                                        phpNew.ShowDialog();
                                    }
                                    string returnedPath = phpNew.getPath();
                                    phpPath = returnedPath;
                                    if (returnedPath != "")
                                    {
                                        processRun(returnedPath, runPHPProg);
                                        successesForScripts += prog + " ran successfully!\n";
                                    }

                                    else
                                    {
                                        errorsForScripts += "Unable to find the php.exe executable on your system!  Until the path is entered, you cannot run .php scripts!";
                                    }
                                }
                                break;
                            case ".exe":
                                processRun(prog, parameters);
                                successesForScripts += prog + " ran successfully!\n";
                                break;
                            case ".bat":
                                processRun(prog, parameters);
                                successesForScripts += prog + " ran successfully!\n";
                                break;
                            case ".jar":
                                processRun(prog, parameters);
                                successesForScripts += prog + " ran successfully!\n";
                                break;
                            default:
                                errorsForScripts += prog + " has an invalid extension of " + extension + "!  Only .exe, .php, .bat, and .jar are allowed!\n";
                                break;

                        }
                    }
                    else
                    {
                        errorsForScripts += prog + " doesn't even exist!";
                    }

                }
                if (errorsForScripts != "")
                {
                    customError newError = new customError("The following scripts did not run because:", errorsForScripts);
                    newError.Show();
                    //MessageBox.Show(errorsForScripts, "Error Running Scripts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (successesForScripts != "")
                {
                    success scriptsHaveRan = new success(successesForScripts);
                    scriptsHaveRan.Show();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IPAddress = getExternalIP();
            if (!string.IsNullOrEmpty(IPAddress))
            {
                updateIP();
            }
        }

        private void optiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopScanningInterval();
            options showOptions = new options();
            showOptions.ShowDialog();
            getSavedOptions();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            updateTimerLabels();
        }

        private void updateTimerLabels()
        {
            seconds = int.Parse(secondsLabel.Text);
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            if (minutes == 60)
            {
                hours++;
                minutes = 0;
            }
            string secondsAdd, minutesAdd, hoursAdd;
            if (seconds < 10)
            {
                secondsAdd = "0" + seconds.ToString();
            }
            else
            {
                secondsAdd = seconds.ToString();
            }
            if (minutes < 10)
            {
                minutesAdd = "0" + minutes.ToString();
            }
            else
            {
                minutesAdd = minutes.ToString();
            }
            if (hours < 10)
            {
                hoursAdd = "0" + hours.ToString();
            }
            else
            {
                hoursAdd = hours.ToString();
            }

            secondsLabel.Text = secondsAdd;
            minutesLabel.Text = minutesAdd;
            hoursLabel.Text = hoursAdd;

        }

        private void stopScanButton_Click(object sender, EventArgs e)
        {
            stopScanningInterval();
        }

        private void resetTimeLabels()
        {
            secondsLabel.Text = "00";
            minutesLabel.Text = "00";
            hoursLabel.Text = "00";
            seconds = 0;
            minutes = 0;
            hours = 0;
        }

        private void stopScanningInterval()
        {
            if (timer1.Enabled != false)
            {
                timer1.Enabled = false;
            }
            if (timer2.Enabled != false)
            {
                timer2.Enabled = false;
            }
            resetTimeLabels();
            scanButton.Visible = true;
            stopScanButton.Visible = false;
            timer1.Stop();
            timer2.Stop();
        }
        private void getSavedOptions()
        {
            appSettings = AppHelper.LoadOptions();

            // Reading Saved Options:
            switch (appSettings.TimeIntervalMode)
            {
                default:
                case 1:
                    timer1.Interval = appSettings.TimeInterval * 1000;
                    break;
                case 2:
                    timer1.Interval = appSettings.TimeInterval * 1000 * 60;
                    break;
                case 3:
                    timer1.Interval = appSettings.TimeInterval * 1000 * 3600;
                    break;

            }

            if (appSettings.AutoStart)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                scanButton.Visible = false;
                stopScanButton.Visible = true;
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                scanButton.Visible = true;
                stopScanButton.Visible = false;
            }

            switch (appSettings.IPService)
            {
                case 1:
                    urlForIPCheck = "https://dynamix.run/ip.php";
                    break;
                case 3:
                    urlForIPCheck = "http://dinofly.com/misc/ipcheck.php";
                    break;
                case 2:
                    urlForIPCheck = "http://grabip.tk";
                    break;
                default:
                    urlForIPCheck = "https://dynamix.run/ip.php";
                    break;
            }


            if (File.Exists(phpPathFile))
            {
                phpPath = File.ReadAllText(phpPathFile);
            }

            if (appSettings.RunDynamicServices)
            {
                XpertDNSSettings = XpertDNSHelper.LoadOptions();
                dynamixSettings = DynamixHelper.LoadOptions();
                afraidDNSSettings = AfraidDNSHelper.LoadOptions();
                noIPDNSSettings = NoIPHelper.LoadOptions();
            }
        }

        private void addToStartupProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToStartUp();
        }
        private void addToStartUp()
        {
            string pathToStartUp = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            if (!File.Exists(pathToStartUp + "\\" + dynamixStartupEntryName))
            {
                using (ShellLink shortcut = new ShellLink())
                {
                    shortcut.Target = Application.ExecutablePath;
                    shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                    shortcut.Description = "Dynamix DNS Client";
                    shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
                    //MessageBox.Show(pathToStartUp, "info");
                    shortcut.Save(pathToStartUp + "\\" + dynamixStartupEntryName);
                }
                success StartUpCreated = new success("A startup entry for the Dynamix DNS Client was successfully created.\n\nDynamix DNS Client will start with Windows!");
                StartUpCreated.ShowDialog();
            }
            else
            {
                MessageBox.Show("The startup entry already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void removeFromStartUp()
        {
            string pathToStartUp = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            if (File.Exists(pathToStartUp + "\\" + dynamixStartupEntryName))
            {
                File.Delete(pathToStartUp + "\\" + dynamixStartupEntryName);
                success StartUpRemoved = new success("The startup entry for the Dynamix DNS Client was successfully deleted.\n\nDynamix DNS Client will NOT start with Windows!");
                StartUpRemoved.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is no startup entry to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeFromStartupProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeFromStartUp();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about showAbout = new about();
            showAbout.ShowDialog();
        }

        private void processRun(string process, string parameter)
        {
            try
            {
                ProcessStartInfo startBindSync = new ProcessStartInfo();
                startBindSync.FileName = (!process.StartsWith("\"") ? "\"" + process + "\"" : process);
                startBindSync.Arguments = parameter;
                string oldWorkingDirectory = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\") + 1);
                string ranFromDirectory = process.Substring(0, process.LastIndexOf("\\") + 1);
                startBindSync.WorkingDirectory = ranFromDirectory;
                Process.Start(startBindSync);
                // Had to reset the working directory to the old directory due to a C# bug that starts writing settings into the working directory of the process run...
                startBindSync.WorkingDirectory = oldWorkingDirectory;
            }
            catch(Exception e)
            {
                MessageBox.Show("Unable to run script " + process + Environment.NewLine + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void runInternetServices()
        {
            runXPertDNSUpdate();
            runDynamixDNSUpdate();
            runAfraidDNSUpdate();
            runNoIPUpdate();
        }

        private void runDynamixDNSUpdate()
        {
            if (dynamixSettings.Hosts.Any() && !string.IsNullOrEmpty(dynamixSettings.Password) && dynamixSettings.Enabled)
            {
                string messages = DynamixHelper.RunUpdates(dynamixSettings, IPAddress);
                parseMessagesAndShowResults(messages);
            }
        }

        private void runXPertDNSUpdate()
        {
            if (XpertDNSSettings.Hosts.Any() && !string.IsNullOrEmpty(XpertDNSSettings.Login) && !string.IsNullOrEmpty(XpertDNSSettings.Password) && XpertDNSSettings.Enabled)
            {
                string messages = XpertDNSHelper.RunUpdates(XpertDNSSettings, IPAddress);
                parseMessagesAndShowResults(messages);
            }
        }

        private void runAfraidDNSUpdate()
        {
            if (afraidDNSSettings.Hosts.Any() && !string.IsNullOrEmpty(afraidDNSSettings.Login) && !string.IsNullOrEmpty(afraidDNSSettings.Password) && afraidDNSSettings.Enabled)
            {
                string messages = AfraidDNSHelper.RunUpdates(afraidDNSSettings);
                parseMessagesAndShowResults(messages);
            }
        }

        private void runNoIPUpdate()
        {
            if (noIPDNSSettings.Hosts.Any() && !string.IsNullOrEmpty(noIPDNSSettings.Login) && !string.IsNullOrEmpty(noIPDNSSettings.Password) && noIPDNSSettings.Enabled)
            {
                string messages = NoIPHelper.RunUpdates(noIPDNSSettings, IPAddress);
                parseMessagesAndShowResults(messages);
            }
        }

        private void parseMessagesAndShowResults(string messages)
        {
            string success = string.Empty;
            string error = string.Empty;
            string[] finalMessages = messages.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string mess in finalMessages)
            {
                if (mess.IndexOf("failed") == -1)
                {
                    success += mess + Environment.NewLine;
                }
                else
                {
                    error += mess + Environment.NewLine;
                }
            }

            if (error != "" & error != null)
            {
                customError showError = new customError("Error Synchronizing to Service", error);
                showError.intervalForTimer = 60000;
                showError.Show();
            }
            if (success != "" & success != null)
            {
                success synced = new success(success);
                synced.Show();
            }
        }

        private void startScanning()
        {
            scanButton.Visible = false;
            stopScanButton.Visible = true;
            if (timer1.Enabled != true)
            {
                timer1.Enabled = true;
            }
            if (timer2.Enabled != true)
            {
                timer2.Enabled = true;
            }
            timer1.Start();
            timer2.Start();
        }

        private void checkOptionsExist()
        {
            if (!File.Exists(AppHelper.settingsFile))
            {
                MessageBox.Show("No options have been set. Please set them now.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                stopScanningInterval();
                options showOptions = new options();
                showOptions.ShowDialog();
            }
            getSavedOptions();
        }
    }
}
