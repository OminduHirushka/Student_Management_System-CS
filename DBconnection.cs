using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student_Management_System
{
    class DBconnection
    {
        private string server = "localhost";
        private string database = "student_management_system";
        private string username = "root";
        private string password = "";

        private string connectionString;

        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public DBconnection()
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public MySqlDataReader executeQuery(string sql)
        {
            command = new MySqlCommand(sql, connection);
            reader = command.ExecuteReader();
            return reader;
        }

        public int executeUpdate(string sql)
        {
            command = new MySqlCommand(sql, connection);
            int x = command.ExecuteNonQuery();
            return x;
        }

        public void openConnection()
        {
            connection.Open();
        }

        public void closeConnection()
        {
            connection.Close();
        }
    }
}
