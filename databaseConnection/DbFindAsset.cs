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
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed ");
                connection.Close();
            }

            // get user input from searchEntryWindow.textbox and find asset in db

            string userInput = searchEntryWindow.search_bar.Text.ToString();

            // get results from db based on user input and if user inputs any character get all results from database


            string query = "SELECT * FROM ScottishGlen WHERE id LIKE " + "'%" + userInput + "%' " + "OR " 
                + "systemName LIKE " + "'%" + userInput + "%' " + "OR " 
                + "hardwareInfo LIKE " + "'%" + userInput + "%' " + "OR " 
                + "os LIKE " + "'%" + userInput + "%' " + "OR " 
                + "ipAddress LIKE " + "'%" + userInput + "%' " + "OR " 
                + "manufacturer LIKE " + "'%" + userInput + "%' " + "OR "
                + "type LIKE " + "'%" + userInput + "%' " + "OR "
                + "serialNumber LIKE " + "'%" + userInput + "%' " + "OR "
                + "notes LIKE " + "'%" + userInput + "%' " ;



            // if empty search bar get all results from db

            if (userInput == "")
            {
                query = "SELECT * FROM ScottishGlen";
            }
            
            // if no results found 

 
            MySqlCommand command = new MySqlCommand(query, connection);

       

            MySqlDataReader reader = command.ExecuteReader(); 
            
            StringBuilder sb = new StringBuilder();

            if (reader.HasRows)
            {   
                while (reader.Read())
            {

                sb.AppendFormat(" " +
                    "id:{0}\n\t Device name :{1} \n\t hardware information :{2}\n\t OS :{3}\n\t ip address:{4}\n\t Manufacturer :{5}\n\t Type :{6}\n\t Serial Number :{7}\n\t " +
                    "Date added :{8} \n\t Notes :{9} \n\t\n", reader.GetString(0), reader.GetString(1), reader.GetString(2),
                 reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));

            }

                 searchEntryWindow.searchDisplayBox.Text = sb.ToString();
               
            }
            else
            {
                searchEntryWindow.searchDisplayBox.Text = ("No results found");
            }


           

         

            connection.Close();

        }
    }
}

            
       





