using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamixDNS.Helpers;

namespace DynamixDNS.Classes
{

    [Serializable]
    public class XPertDNSSettings : DDNSService
    {
        public string MD5Password
        {
            get
            {
                return GenericHelper.GetMD5Hash(Password);
            }
        }
    }
}
