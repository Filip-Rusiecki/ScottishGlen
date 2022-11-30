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
        private MainWindow mainWindow;

        public DbGetAll(MainWindow mainWindow)

        {

            // connect to the database


            StringBuilder sb = new StringBuilder();

            MySqlConnection connection = new MySqlConnection();

            string connetionString = null;

            connetionString = "server=lochnagar.abertay.ac.uk;database=sql2106215;uid=sql2106215;pwd=ZxLeTfsEDKLh;";
            connection = new MySqlConnection(connetionString); //leave if want to connect to a different database (prototype)
            try
            {
                connection.Open();
                MessageBox.Show("Connected"); //   leave for testing the connection to the database
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




                sb.AppendFormat(" " +
                    "id:{0}\n\t Device name :{1} \n\t hardware information :{2}\n\t OS :{3}\n\t ip address:{4}\n\t Manufacturer :{5}\n\t Type :{6}\n\t Serial Number :{7}\n\t " +
                    "Date added :{8} \n\t Notes :{9} \n\t\n", reader.GetString(0), reader.GetString(1), reader.GetString(2),
                 reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));



            }

            mainWindow.textBoxDisplay.Text = sb.ToString();





            reader.Close();
            connection.Close();

        }

    }


}
