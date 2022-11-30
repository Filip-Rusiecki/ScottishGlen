using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Management;
using Microsoft.Identity.Client;
using System.Security.Cryptography;

namespace ScottishGlen.databaseConnection
{
    internal class DbAddThisAsset
    {


        public DbAddThisAsset()
        {


            // connect to the database

            MySqlConnection connection = new MySqlConnection();

            string connetionString = null;

            connetionString = "server=lochnagar.abertay.ac.uk;database=sql2106215;uid=sql2106215;pwd=ZxLeTfsEDKLh;";

            connection = new MySqlConnection(connetionString);

            try
            {
                connection.Open();
                MessageBox.Show("Connected"); // leave for testing the connection to the database
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed ");
                connection.Close();
            }

            // add data to the database



            ManagementObjectSearcher processorSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            // add data from importHardwareInformation + importSystemInformation to database
            importSystemInformation importSystem = new importSystemInformation();
            importHardwareInformation importHardware = new importHardwareInformation();


            string system_Name = System.Environment.MachineName;
            string hardware_Information = importHardware.ToString();
            string os = System.Environment.OSVersion.ToString();
            string ipAddress = importSystem.GetIPAddress();
            string manufacturer = importSystem.GetManufacturer();
            string type = "desktop"; // this will eventualy be changed to a text box in the future to allow the user to select the type of asset
            string serialNumber = null; // this will be changed to a text box in the future to allow the user to enter the serial number
            string addedToTheList = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string notes = null; // this will be changed to a text box in the future to allow the user to add notes to the asset

            foreach (ManagementObject queryObj in processorSearcher.Get())
            {
                hardware_Information = "Processor: " + queryObj["Name"] + "Processor ID: " + queryObj["ProcessorId"] + "Processor Speed: " + queryObj["MaxClockSpeed"] + "Processor Cores: " + queryObj["NumberOfCores"] + "Processor Threads: " + queryObj["NumberOfLogicalProcessors"];
            }
            // add data to the database

            string sql = "INSERT INTO `ScottishGlen` (systemName,hardwareInfo,os,ipAddress,manufacturer,type,serialNumber,dateAdded,notes) VALUES " +
                "(" + "'" + system_Name + "'" + "," + "'" + hardware_Information + "'" + "," + "'" + os + "'" + "," + "'" + ipAddress + "'" + "," + "'" + manufacturer + "'" + "," + "'" + type + "'" + "," + "'" + serialNumber + "'" + "," + "'" + addedToTheList + "'" + "," + "'" + notes + "'" + ")";


            try
            { 
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data added to the database");  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : Could not add asset to the database");
            }

            // if there is duplication in the db then update the data

            //check if the data is already in the database

            


            connection.Close();



        }

            

        }
    }






