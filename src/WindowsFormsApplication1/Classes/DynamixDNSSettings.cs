using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamixDNS.Classes
{
    [Serializable]
    public class DynamixDNSSettings
    {
        public DynamixDNSSettings()
        {
            TimeIntervalMode = 1;
            TimeInterval = 120;
            AutoStart = true;
            IPService = 1;
            RunDynamicServices = true;
            ExternalScriptToRun = new List<string>();
        }

        public int TimeIntervalMode { get; set; }
        public int TimeInterval { get; set; }
        public bool AutoStart { get; set; }
        public int IPService { get; set; }
        public bool RunDynamicServices { get; set; }
        public List<string> ExternalScriptToRun { get; set; }
    }
}
