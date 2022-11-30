using Microsoft.Identity.Client;
using MySql.Data.MySqlClient;
using ScottishGlen.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScottishGlen.databaseConnection
{
    internal class DbGetLogin
    {

        public DbGetLogin()
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
            // get all users (username + password) where username = ? and password = ?

            // get username and password from login page text boxes
            loginPage login = new loginPage();
            
            string username = login.username_txtBox.Text.ToString();
            string password = "test" ;

            string queryName = "SELECT * FROM ScottishGlenUsers WHERE username  = '" + username + "'" ;
            MySqlCommand command = new MySqlCommand(queryName, connection);

            // show the user if the username exists

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                MessageBox.Show("Username exists");
            }
            else
            {
                MessageBox.Show("Username does not exist");
            }







        }

    }












}


