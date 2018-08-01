using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DynamixDNS.Classes
{
    public class WebAuthentication
    {
        public WebAuthentication()
        {
            CredCache = new CredentialCache();
        }

        public CredentialCache CredCache { get; set; }
        public string Agent { get; set; }
    }
}
