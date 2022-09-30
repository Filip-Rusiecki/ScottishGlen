using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;


namespace ScottishGlen
{

    public class importHardwareInformation
    {
        StringBuilder hardwareInformation = new StringBuilder();


        // hardware Information

        ManagementObjectSearcher processorSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

        ManagementObjectSearcher memorySearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");





        public override string ToString()
        {

            //Display hardware information to the user in the text box
            // note : some of these are not working yet 
            // note : need to connect to System.management and get the information from there 
          
             foreach(ManagementObject queryObj in processorSearcher.Get())
        {
            hardwareInformation.AppendLine("Processor: " + queryObj["Name"]);
            hardwareInformation.AppendLine("Processor ID: " + queryObj["ProcessorId"]);
            hardwareInformation.AppendLine("Processor Speed: " + queryObj["MaxClockSpeed"]);
            hardwareInformation.AppendLine("Processor Cores: " + queryObj["NumberOfCores"]);
            hardwareInformation.AppendLine("Processor Threads: " + queryObj["NumberOfLogicalProcessors"]);
        }

            foreach (ManagementObject queryObj in memorySearcher.Get())
            {
                {
                    hardwareInformation.AppendLine(" RAM Memory: " + queryObj["Capacity"]);
                }
            }





                return hardwareInformation.ToString();
        }

    }
  
        
      

    }

