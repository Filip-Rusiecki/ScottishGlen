
using Microsoft.Identity.Client;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using ScottishGlen;
using System;
using System.Net;
using System.Text;
using System.Web;
using System.Windows;
using static System.Net.WebRequestMethods;

public class VulnrabilityCheck
{
    public VulnrabilityCheck()
    {



        importSystemInformation systemInformation = new importSystemInformation();
        MainWindow main = new MainWindow();

        string operatingSystem = System.Environment.OSVersion.ToString();
        string manufacturer =  systemInformation.GetManufacturer();

        StringBuilder sb = new StringBuilder();
        
        sb.Append(operatingSystem);



        var url = "https://services.nvd.nist.gov/rest/json/cves/1.0?namingFormat=2.3&keyword=" + "Windows 10"  ;
        var request = (HttpWebRequest)WebRequest.Create(url);

        request.Method = Http.Get;

        var response = (HttpWebResponse)request.GetResponse();

        var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();

        var json = JObject.Parse(responseString);



        // get all the cves from the json file

        var cves = json["result"]["CVE_Items"].ToString();




        string cve = json["result"]["CVE_Items"][0]["cve"]["description"]["description_data"].ToString();



        // cve results to file 

        System.IO.File.WriteAllText(@"C:\Users\flaqy\Desktop\Uni Projects\ScottishGlen\Api\cveDump.txt", cves);


    










    }
}

        

         




    