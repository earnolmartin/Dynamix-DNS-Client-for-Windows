using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using DynamixDNS.Classes;
using System.Text.RegularExpressions;

namespace DynamixDNS.Helpers
{
    public static class GenericHelper
    {
        static GenericHelper()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)3072;
        }

        public static string EncodeTo64(string toEncode)
        {
            if (!string.IsNullOrEmpty(toEncode))
            {
                byte[] toEncodeAsBytes = ASCIIEncoding.ASCII.GetBytes(toEncode);
                string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
                return returnValue;
            }
            return String.Empty;
        }

        public static string DecodeFrom64(string encodedData)
        {
            if (!string.IsNullOrEmpty(encodedData))
            {
                byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
                string returnValue = ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
                return returnValue;
            }
            return String.Empty;
        }

        public static string MakeHTTPGETRequest(string url, WebAuthentication auth = null)
        {
            try
            {
                string textResponse;
                WebRequest request;
                request = WebRequest.Create(url);
                request.Timeout = 5000;
                WebResponse response;

                if (auth != null)
                {
                    HttpWebRequest webRequest = (HttpWebRequest)request;
                    webRequest.Credentials = auth.CredCache;
                    if (!string.IsNullOrEmpty(auth.Agent))
                    {
                        webRequest.UserAgent = auth.Agent;
                    }
                    response = webRequest.GetResponse();
                }
                else
                {
                    response = request.GetResponse();
                }

                StreamReader stream = new StreamReader(response.GetResponseStream());
                textResponse = stream.ReadToEnd();
                stream.Close();
                response.Close();
                if (!string.IsNullOrEmpty(textResponse))
                {
                    return textResponse;
                }
            }
            catch(Exception e)
            {
                return "Exception: " + e.ToString();
            }

            return string.Empty;
        }

        public static bool IsNumeric(string str)
        {
            bool textIsNumeric = true;
            try
            {
                int.Parse(str);
            }
            catch
            {
                textIsNumeric = false;
            }

            return textIsNumeric;
        }

        public static string GetMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string HashCode(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 =
            new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(
                cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static string ParseIPv4Addr(string ip)
        {
            try
            {
                Regex ipCheck = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                MatchCollection result = ipCheck.Matches(ip);
                ip = result[0].ToString();
            }
            catch
            {
                Regex rgx = new Regex(@"[^0-9\.]");
                ip = rgx.Replace(ip, "");
            }

            return ip.ToLower();
        }

        public static bool CheckIPValid(string strIP)
        {
            IPAddress result = null;
            return
                !String.IsNullOrEmpty(strIP) &&
                IPAddress.TryParse(strIP, out result);
        }
    }
}
