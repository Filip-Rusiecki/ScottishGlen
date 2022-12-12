using MySql.Data.MySqlClient;
using System;
using System.Windows;
using ScottishGlen.view;

namespace ScottishGlen.databaseConnection
{
    internal class DbUpdateThisAsset
    {


        public DbUpdateThisAsset(editEntryWindow editEntry)
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

            // get entry data from database and add text to editEntryWindow

            string sql = "SELECT * FROM ScottishGlen";
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                editEntry.systemName_textBox.Text = rdr[1].ToString();
                editEntry.hardwareInfo_textBox.Text = rdr[2].ToString();
                editEntry.Os_textBox.Text = rdr[3].ToString();
                editEntry.ipAddress_textBox.Text = rdr[4].ToString();
                editEntry.manufacturer_textBox.Text = rdr[5].ToString();
                editEntry.notes_textBox.Text = rdr[6].ToString();
            }

            rdr.Close();
            


         

            // update data in the database if user clicks edit button

           editEntry.edit_btn.Click += (sender, e) =>
            {
                string system_Name = editEntry.systemName_textBox.Text.ToString();
                string hardware_Information = editEntry.hardwareInfo_textBox.Text.ToString();
                string os = editEntry.Os_textBox.Text.ToString();
                string ipAddress = editEntry.ipAddress_textBox.Text.ToString();
                string manufacturer = editEntry.manufacturer_textBox.Text.ToString();
                string notes = editEntry.notes_textBox.Text.ToString();

                string sqlUpdate = "UPDATE ScottishGlen SET systemName = '" + system_Name + "', hardwareInfo = '" + hardware_Information + "', os = '" + os + "'," +
                " ipAddress = '" + ipAddress + "', manufacturer = '" + manufacturer + "', notes = '" + notes + "' WHERE systemName = '" + system_Name + "'";
                
                MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, connection);
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Entry updated");

                connection.Close();

                editEntry.Close(); // close editEntryWindow
            };




        }
    }
}







