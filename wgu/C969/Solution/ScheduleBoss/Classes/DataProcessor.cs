using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleBoss.Enums;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace ScheduleBoss.Classes
{
    public class DataProcessor
    {
        
        public DatabaseConnection Database {get; set;}

        public DataProcessor( DatabaseConnection DbConn)
        {
           this.Database = DbConn;
        }

        public bool ValidateData(DatabaseEntries entryType, object Data)
        {
            // declare local variable to track validation
            bool IsValid = false;

            switch (entryType)
            {
                case DatabaseEntries.Address:

                    try
                    {
                        CustomerAddress addressTemp = Data as CustomerAddress;

                        IsValid = true;

                    }

                    catch (InvalidCastException icEx)
                    {
                        // display exception message to user
                        MessageBox.Show(icEx.Message, "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    break;

                case DatabaseEntries.Appointment:
                    break;

                case DatabaseEntries.City:
                    break;

                case DatabaseEntries.Country:
                    break;

                case DatabaseEntries.Customer:
                    break;

            }

            // return the tracking value
            return IsValid;
        }

        public bool InsertData(object Data) 
        {
            // declare local variable to track status
            bool IsInserted = false;



            return IsInserted;
        }

        public bool UpdateData(object Data)
        {
            // declare local variable to track status
            bool IsUpdated = false;



            return IsUpdated;
        }

        public DataTable GetAllTableValues(DatabaseEntries entryType)
        {
            var AllRecords = new DataTable();

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();

            switch (entryType)
            {
                case DatabaseEntries.Address:
                    query.CommandText = "SELECT * FROM address";
                    break;

                case DatabaseEntries.Appointment:
                    query.CommandText = "SELECT * FROM appointment";
                    break;

                case DatabaseEntries.City:
                    query.CommandText = "SELECT * FROM city";
                    break;

                case DatabaseEntries.Country:
                    query.CommandText = "SELECT * FROM country";
                    break;

                case DatabaseEntries.Customer:
                    query.CommandText = "SELECT * FROM customer";
                    break;

            }

            // execute the query 
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
            {
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(AllRecords);
            }

            return AllRecords;
            
        }

        // method to get the value of the next 'id' for a given entry type
        public int GetNextId(DatabaseEntries entryType)
        {
            // create variable for return value
            int nextId = 0;

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();
            
            switch (entryType)
            {
                case DatabaseEntries.Address:
                    query.CommandText = "SELECT MAX(addressId) FROM address"; 
                    break;

                case DatabaseEntries.Appointment:
                    query.CommandText = "SELECT MAX(appointmentId) FROM appointment";
                    break;

                case DatabaseEntries.City:
                    query.CommandText = "SELECT MAX(cityId) FROM city";
                    break;

                case DatabaseEntries.Country:
                    query.CommandText = "SELECT MAX(countryId) FROM country";
                    break;

                case DatabaseEntries.Customer:
                    query.CommandText = "SELECT MAX(customerId) FROM customer";
                    break;

            }

            // execute the query
            MySqlDataReader queryReader = query.ExecuteReader();

            if (queryReader.HasRows)
            {
                // read the record, increment it by 1 to generate the next id value, and close the query reader
                queryReader.Read();
                nextId = queryReader.GetInt32(0) + 1;
                queryReader.Close();
            }

            return nextId;
        }

        // method to authenticate a user
        public LoginResponse AuthenticateUser( string username, string password)
        {
            // create the login query with parameters 
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();
            query.CommandText = "SELECT * FROM user WHERE username = @username AND password = @password";
            query.Parameters.AddWithValue("@username", username);
            query.Parameters.AddWithValue("@password", password);

            // execute the query and read results
            MySqlDataReader queryReader = query.ExecuteReader();

            if (queryReader.HasRows)
            {
               
                // initialize the login response property
                LoginResponse Response = new LoginResponse();

                // read the query data
                queryReader.Read();

                // assign login response fields from query data
                Response.UserId = queryReader.GetInt32(0);
                Response.Username = queryReader.GetString(1);
                Response.IsActive = queryReader.GetBoolean(3);
                Response.CreateDate = queryReader.GetDateTime(4);
                Response.CreatedBy = queryReader.GetString(5);
                Response.LastUpdate = queryReader.GetDateTime(6);
                Response.LastUpdateBy = queryReader.GetString(7);

                queryReader.Close();

                return Response;
            }
            else
            {

                queryReader.Close();
                return null;
                
            }

            

        }

    }
    
}
