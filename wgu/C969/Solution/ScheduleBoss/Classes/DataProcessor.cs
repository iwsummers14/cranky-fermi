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

        public bool InsertData(object Data, DatabaseEntries entryType) 
        {
            // declare local variable to track status
            bool IsInserted = false;

            // create a command object
            MySqlCommand InsertCommand = this.Database.SqlConnection.CreateCommand();
                        
            // create a transaction object
            MySqlTransaction InsertTransaction = this.Database.SqlConnection.BeginTransaction();

            // assign the transaction to the command object
            InsertCommand.Transaction = InsertTransaction;


            try
            {

                switch (entryType)
                {
                    case DatabaseEntries.Address:
                        CustomerAddress Address = Data as CustomerAddress;
                        InsertCommand.CommandText = "INSERT INTO address VALUES ( @addressId, @address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                        InsertCommand.Parameters.AddWithValue("@addressId", Address.AddressId);
                        InsertCommand.Parameters.AddWithValue("@address", Address.Address);
                        InsertCommand.Parameters.AddWithValue("@address2", Address.Address2);
                        InsertCommand.Parameters.AddWithValue("@cityId", Address.CityId);
                        InsertCommand.Parameters.AddWithValue("@postalCode", Address.PostalCode);
                        InsertCommand.Parameters.AddWithValue("@phone", Address.Phone);
                        InsertCommand.Parameters.AddWithValue("@createDate", Address.CreateDate);
                        InsertCommand.Parameters.AddWithValue("@createdBy", Address.CreatedBy);
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", Address.UpdateDate);
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", Address.UpdatedBy);
                        break;

                    case DatabaseEntries.Appointment:
                        Appointment Appt = Data as Appointment;
                        InsertCommand.CommandText = "INSERT INTO appointment VALUES ( @appointmentId, @customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy )";
                        InsertCommand.Parameters.AddWithValue("@appointmentId", Appt.AppointmentId);
                        InsertCommand.Parameters.AddWithValue("@customerId", Appt.CustomerId);
                        InsertCommand.Parameters.AddWithValue("@userId", Appt.UserId);
                        InsertCommand.Parameters.AddWithValue("@title", Appt.Title);
                        InsertCommand.Parameters.AddWithValue("@description", Appt.Description);
                        InsertCommand.Parameters.AddWithValue("@location", Appt.Location);
                        InsertCommand.Parameters.AddWithValue("@contact", Appt.Contact);
                        InsertCommand.Parameters.AddWithValue("@type", Appt.Type);
                        InsertCommand.Parameters.AddWithValue("@url", Appt.Url);
                        InsertCommand.Parameters.AddWithValue("@start", Appt.Start);
                        InsertCommand.Parameters.AddWithValue("@end", Appt.End);
                        InsertCommand.Parameters.AddWithValue("@createDate", Appt.CreateDate);
                        InsertCommand.Parameters.AddWithValue("@createdBy", Appt.CreatedBy);
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", Appt.UpdateDate);
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", Appt.UpdatedBy);
                        break;

                    case DatabaseEntries.City:
                        break;

                    case DatabaseEntries.Country:
                        break;

                    case DatabaseEntries.Customer:
                        Customer Cust = Data as Customer;
                        InsertCommand.CommandText = "INSERT INTO customer VALUES ( @customerId, @customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                        InsertCommand.Parameters.AddWithValue("@customerId", Cust.CustomerId);
                        InsertCommand.Parameters.AddWithValue("@customerName", Cust.CustomerName);
                        InsertCommand.Parameters.AddWithValue("@addressId", Cust.AddressId);
                        InsertCommand.Parameters.AddWithValue("@active", Cust.IsActive);
                        InsertCommand.Parameters.AddWithValue("@createDate", Cust.CreateDate);
                        InsertCommand.Parameters.AddWithValue("@createdBy", Cust.CreatedBy);
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", Cust.UpdateDate);
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", Cust.UpdatedBy);
                        break;


                }

            // execute the query and commit the transaction    
            InsertCommand.ExecuteNonQuery();
            InsertTransaction.Commit();

            IsInserted = true;

            }

            catch 
            {
                
                InsertTransaction.Rollback();
                
            }
            

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
