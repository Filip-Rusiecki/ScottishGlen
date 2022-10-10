using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ScottishGlen.databaseConnection
{
    internal class DbGetAll
    {
        public DbGetAll(databaseConnection.DbConnection connection)
        {

            DbConnection dbConnection = new DbConnection();
            
                MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM `sql2106215`.`ScottishGlen`");

            MySqlDataReader reader = sqlCommand.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                    
                }
            }
            else
            {
                Console.WriteLine("no rows found");
            }

            reader.Close();

       


            

        }
      

    }
}
