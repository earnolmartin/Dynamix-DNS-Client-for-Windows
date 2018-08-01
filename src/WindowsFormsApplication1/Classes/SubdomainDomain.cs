using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamixDNS.Classes
{
    public class SubdomainDomain
    {
        public string subdomain { get; set; }
        public string domain { get; set; }
        public string fullHost
        {
            get
            {
                return subdomain + "." + domain;
            }
        }
    }
}
