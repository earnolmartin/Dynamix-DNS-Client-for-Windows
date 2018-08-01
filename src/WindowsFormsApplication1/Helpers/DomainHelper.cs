using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DynamixDNS.Classes;

namespace DynamixDNS.Helpers
{
    public static class DomainHelper
    {
        public static string filterDomain(string filtered)
        {
            // Check for https://
            if (filtered.IndexOf("https://") != -1)
            {
                filtered = filtered.Replace("https://", "");
            }

            // Check for http://
            if (filtered.IndexOf("http://") != -1)
            {
                filtered = filtered.Replace("http://", "");
            }

            filtered = filtered.ToLower();

            Regex rgx = new Regex(@"[^a-z0-9\-\.]");
            filtered = rgx.Replace(filtered, "");

            return filtered.ToLower();
        }

        public static bool isValidSubdomainOrDomain(string filtered)
        {
            string[] parts = filtered.Split(new string[]{"."}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2 || parts.Length > 3)
            {
                return false;
            }

            if (parts[0].Length > 63)
            {
                return false;
            }

            if (parts[1].Length > 63)
            {
                return false;
            }

            return true;
        }

        public static SubdomainDomain getSubdomainDomainFromString(string str)
        {
            SubdomainDomain subDom = new SubdomainDomain();
            string[] parts = str.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 3)
            {
                subDom.subdomain = parts[0];
                subDom.domain = parts[1] + "." + parts[2];
            }
            else if (parts.Length == 2)
            {
                subDom.subdomain = string.Empty;
                subDom.domain = parts[0] + "." + parts[1];
            }
            else
            {
                return null;
            }

            return subDom;
        }
    }
}
