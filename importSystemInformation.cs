using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using System.Management;
using System.Windows.Input;

namespace ScottishGlen
{
    public class importSystemInformation
    {
        StringBuilder systemInformation = new StringBuilder();


        // system Information 
       
        string computerName = System.Environment.MachineName;
        string userName = System.Environment.UserName;
        string operatingSystem = System.Environment.OSVersion.ToString();
        string systemDirectory = System.Environment.SystemDirectory;
        string systemPageSize = System.Environment.SystemPageSize.ToString();
        string version = System.Environment.Version.ToString();
        string workingSet = System.Environment.WorkingSet.ToString();
        string manufacturer = System.Environment.GetEnvironmentVariable("MANUFACTURER");


        public string GetMACAddress()
        {
            {
                string macAddresses = "";
                foreach (System.Management.ManagementObject mo in new System.Management.ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        macAddresses = mo["MacAddress"].ToString();
                        break;
                    }
                }
                return macAddresses;
            }
        }

        public string GetIPAddress()
        {
            string localIP = "";
            foreach (System.Net.IPAddress ip in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()))
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public string GetManufacturer()
        {
            string manufacturer = "";
            foreach (System.Management.ManagementObject mo in new System.Management.ManagementClass("Win32_ComputerSystem").GetInstances())
            {
                manufacturer = mo["Manufacturer"].ToString();
                break;
            }
            return manufacturer;
        }



        public override string ToString()
        {
            // StringBuilder 
            systemInformation.AppendLine("IP Address : " + GetIPAddress()); 
            systemInformation.AppendLine("MAC Address : " + GetMACAddress());
            systemInformation.AppendLine("Computer Name: " + computerName);
            systemInformation.AppendLine("Manufacturer: " + manufacturer);
            systemInformation.AppendLine("User Name: " + userName);
            systemInformation.AppendLine("Operating System: " + operatingSystem);
            systemInformation.AppendLine("System Directory: " + systemDirectory);
            systemInformation.AppendLine("System Page Size: " + systemPageSize);
            systemInformation.AppendLine("Version: " + version);
            systemInformation.AppendLine("Working Set: " + workingSet);
      

            

            return systemInformation.ToString();
        }

    }

    
}
