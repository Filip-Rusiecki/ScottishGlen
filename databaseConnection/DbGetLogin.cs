using Microsoft.Identity.Client;
using MySql.Data.MySqlClient;
using ScottishGlen.view;
using sun.security.util;
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
          
            loginPage login = new loginPage();

            string username = login.username_txtBox.Text.ToString();
            string password = login.password_txtBox.Password.ToString();

            // password hash + salt


            string salt = "salt";

            string passwordHash = HashString(password + salt);

            // query to check if the username and password match
   

            string sql = "SELECT * FROM ScottishGlenUsers WHERE username = '" + username + "' AND password = '" + passwordHash + "'";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string usernameFromDb = rdr[1].ToString();
                string passwordFromDb = rdr[2].ToString();

                if (usernameFromDb == username && passwordFromDb == passwordHash)
                {
                    MessageBox.Show("Login successful");
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
            }

            rdr.Close();

            

            
        }

        public static string HashString(string password)
        {
            // hashing the password

            byte[] salt;

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);

            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }
    }












}


