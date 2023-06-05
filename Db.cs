using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newsurvey
{

    /*
         I need to download the mysql connector then add the connector to my project,
         i also need create a connection now with mysql
        so i am just going to open xampp and start mysql & apache
        then go to phpmyadmin and create the users database
        */
    class Db
    {




        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=survey_app");



        //I will need to create a function to open the connection
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // a function to close the connection
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // and a function to return the connection
        public MySqlConnection getConnection()
        {
            return connection;
        }






    }
}
