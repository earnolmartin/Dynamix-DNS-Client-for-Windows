using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamixDNS.Classes
{
    [Serializable]
    public class DDNSService
    {
        public DDNSService()
        {
            Hosts = new List<string>();
            Enabled = false;
        }

        public string Login { get; set; }
        public string Password {get;set;}
        public bool Enabled { get; set; }
        public List<string> Hosts { get; set; }
    }
}
