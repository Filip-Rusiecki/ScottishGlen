using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ScottishGlen.databaseConnection
{
    internal class DbConnection
    {
        public DbConnection()
        {
            // connect to the database


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
        }
    }
}

      



