using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ScheduleBoss.Classes
{
    public class DatabaseConnection
    {

        private string ConnectionString { get; set; }

        public MySqlConnection SqlConnection { get; set; }

        public DatabaseConnection()
        {
            // default constructor that uses connection string stored in app.config
            this.ConnectionString = ConfigurationManager.ConnectionStrings["ScheduleBossDatabase"].ConnectionString;

        }

        public DatabaseConnection(string connString)
        {
            // overload constructor allowing a connectionstring to be passed
            this.ConnectionString = connString;
        }

        public DatabaseConnection(string hostname, string databaseName, string username, string password)
        {
            // overload constructor that constructs a connstring out of four elements
            MySqlConnectionStringBuilder csBuilder = new MySqlConnectionStringBuilder();
            csBuilder.Server = hostname;
            csBuilder.UserID = username;
            csBuilder.Password = password;
            csBuilder.Database = databaseName;

            this.ConnectionString = csBuilder.ToString();  
        }

        public bool ConnectToDatabase()
        {
            // method to establish connection
            this.SqlConnection = new MySqlConnection(this.ConnectionString);

            try
            {
                this.SqlConnection.Open();
                return true;
            }
            catch (MySqlException msEx)
            {

                return false;
            }
                        
        }
        public bool DisconnectFromDatabase()
        {

            if (this.SqlConnection.State == System.Data.ConnectionState.Open)
            {
                this.SqlConnection.Close();
                return true;

            }
            else if (this.SqlConnection.State == System.Data.ConnectionState.Broken)
            {
                this.SqlConnection.Close();
                return true;
            }
            else
            {
                // do nothing, nothing to do
                return true;
            }

        }
    }

}
