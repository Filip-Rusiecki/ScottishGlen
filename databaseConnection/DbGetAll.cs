using Microsoft.Identity.Client;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ScottishGlen.databaseConnection
{
    public class DbGetAll
    {
        
        

     
        public DbGetAll()
        {

            
            
            // connect to the database
            
            StringBuilder sb = new StringBuilder();
            
            MySqlConnection connection = new MySqlConnection();

            string connetionString = null;

            connetionString = "server=lochnagar.abertay.ac.uk;database=sql2106215;uid=sql2106215;pwd=ZxLeTfsEDKLh;";
            connection = new MySqlConnection(connetionString);
            try
            {
                connection.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed ");
                connection.Close();
            }

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `ScottishGlen`", connection);


            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                

                
                sb.AppendFormat("{0} {1} {2} {3} {4} {5}", reader.GetString(0), reader.GetString(1), reader.GetString(2),
                reader.GetString(3), reader.GetString(4), reader.GetString(5));


            }


            
            reader.Close();
            connection.Close();

            MessageBox.Show(sb.ToString());

            sb.ToString();

        }

   
    } 
}
