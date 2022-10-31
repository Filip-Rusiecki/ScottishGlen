using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using ScottishGlen.view;

namespace ScottishGlen.databaseConnection
{
    internal class DbFindAsset
    {

        // find asset in the db and display it in a textbox

        public DbFindAsset(searchEntryWindow searchEntryWindow)
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

            // get user input from searchEntryWindow.textbox and find asset in db

            string userInput = searchEntryWindow.search_bar.Text.ToString();

            // get results from db based on user input


            string queryName = "SELECT * FROM ScottishGlen WHERE systemName  = '" + userInput + "'"; // find asset by system name in db -- this will be changed to more complex search later

            MySqlCommand command = new MySqlCommand(queryName,connection);

            MySqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {

                sb.AppendFormat("id:{0}\n Device name:{1}\n hardware information:{2}\n OS:{3}\n ip address:{4}\n Manufacturer:{5}\n Type:{6}\n Serial Number:{7}\n " +
                    "Date added:{8} \n Notes:{9} \n", reader.GetString(0), reader.GetString(1), reader.GetString(2),
                 reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));

            }

            searchEntryWindow.searchDisplayBox.Text = sb.ToString();

            connection.Close();

        }
    }
}

            
       





