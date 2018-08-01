using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamixDNS.Helpers;

namespace DynamixDNS.Classes
{
    [Serializable]
    public class AfraidDNSSettings : DDNSService
    {
        public string HashedLogin
        {
            get
            {
                return GenericHelper.HashCode(Login + "|" + Password, new UTF8Encoding());
            }
        }
    }
}
