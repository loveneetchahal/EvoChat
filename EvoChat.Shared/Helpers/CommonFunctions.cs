using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvoChat.Shared.Helpers
{
    public static class CommonFunctions
    {
        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static string getUserId(this ClaimsPrincipal user)
        {
            var identity = user.Identity as ClaimsIdentity;
            if (!identity.IsAuthenticated)
            {
                return "";
            }
            Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == "UserId");
            return identityClaim.Value.ToString();
        }

        public static string getUserRole(this ClaimsPrincipal user)
        {
            var identity = user.Identity as ClaimsIdentity;
            if (!identity.IsAuthenticated)
            {
                return "";
            }
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            return roles.FirstOrDefault();
        }

        public static int getFourDigitCode()
        {
            return new Random().Next(1000, 9999);
        }

        public static string GenerateOTP()
        {
            string OTPLength = "6";

            string NewCharacters = "";

            //This one tells you which characters are allowed in this new password
            string allowedChars = "";
            //Here Specify your OTP Characters
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);

            string IDString = "";
            string temp = "";

            //utilize the "random" class
            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(OTPLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewCharacters = IDString;
            }

            return NewCharacters;
        } 
        public static string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            return filename;
        }

        public static string RenameFileName(string filename)
        {
            var outFileName = "";
            if (filename != null || filename != "")
            {
                var extension = System.IO.Path.GetExtension(filename);
                //filename = DateTime.Now.ToString() + DateTime.Now.Millisecond.ToString() + filename;
                //filename = filename.Replace(' ', '0').Replace(':', '1').Replace('/', '0');
                outFileName = Guid.NewGuid().ToString() + extension;
            }
            return outFileName;
        }

        public static DateTime ConvertToIstTime(DateTime utcTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }

        public static decimal GetTimeDifferenceInMinutes(DateTime dt)
        {
            var ts = new TimeSpan(ConvertToIstTime(DateTime.UtcNow).Ticks - dt.Ticks);
            return Convert.ToDecimal(Math.Abs(ts.TotalHours));
        }

        public static int GetTimeDifferenceInYears(DateTime dt)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dt.Year;
            if (dt > now.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        public static string DetermineDeviceName(string IP)
        {
            string machineName = string.Empty;
            IPAddress myIP = IPAddress.Parse(IP);
            IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
            machineName = compName.First();
            return machineName;
        }

        public static string GetMachineNameFromIPAddress(string ipAdress)
        {
            string machineName = string.Empty;
            System.Net.IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(ipAdress);
            machineName = hostEntry.HostName;
            return machineName;
        }

        public static string GetMacAddress(string ipAddress)
        {
            string macAddress = string.Empty;
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a " + ipAddress;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                    + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                    + "-" + substrings[7] + "-"
                    + substrings[8].Substring(0, 2);
                return macAddress;
            }
            else
            {
                return "not found";
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string UniqueGuidString()
        {
            return DateTime.Now.ToFileTime() + "-" + Guid.NewGuid().ToString();
        }
    }
}
