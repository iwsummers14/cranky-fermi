using MySql.Data.MySqlClient;
using System.Configuration;

namespace ScheduleBoss.Classes
{

    /// <summary>
    /// class to hold information pertaining to the backend database connection required by ScheduleBoss
    /// </summary>
    public class DatabaseConnection
    {

        private string ConnectionString { get; set; }

        public MySqlConnection SqlConnection { get; set; }

        // default constructor that uses connection string stored in app.config
        public DatabaseConnection()
        {
            
            this.ConnectionString = ConfigurationManager.ConnectionStrings["ScheduleBossDatabase"].ConnectionString;

        }

        // overload constructor allowing a specific connectionstring to be passed
        public DatabaseConnection(string connString)
        {
            
            this.ConnectionString = connString;
        }

        // overload constructor that constructs a connstring out of four elements
        public DatabaseConnection(string hostname, string databaseName, string username, string password)
        {
            
            MySqlConnectionStringBuilder csBuilder = new MySqlConnectionStringBuilder();
            csBuilder.Server = hostname;
            csBuilder.UserID = username;
            csBuilder.Password = password;
            csBuilder.Database = databaseName;

            this.ConnectionString = csBuilder.ToString();  
        }

        // method to establish connection to backend database
        public bool ConnectToDatabase()
        {
            // initialize the sql connection
            this.SqlConnection = new MySqlConnection(this.ConnectionString);

            // do nothing if the connection state is open 
            if (this.SqlConnection.State == System.Data.ConnectionState.Open)
            {
                return true;
            }

            // establish a connection
            else
            {
                try
                {
                    this.SqlConnection.Open();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
            
                        
        }

        // method to disconnect from the backend database
        public bool DisconnectFromDatabase()
        {
            // close the connection if it is open
            if (this.SqlConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    this.SqlConnection.Close();
                    return true;
                } 
                catch
                {
                    return false;
                }

            }


            // close the connection if it is broken
            else if (this.SqlConnection.State == System.Data.ConnectionState.Broken)
            {
                try
                {
                    this.SqlConnection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            // do nothing if closed
            else
            {
                return true;
            }

        }
    }

}
