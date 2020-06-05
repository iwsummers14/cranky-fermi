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

        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set;}

        public DataProcessor( DatabaseConnection DbConn, EventLogger Log)
        {
            this.Database = DbConn;
            this.Logger = Log;
        }

        // method to authenticate a user
        public LoginResponse AuthenticateUser(string username, string password)
        {

            // open connection
            this.Database.ConnectToDatabase();

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

                // close connection
                this.Database.DisconnectFromDatabase();

                return Response;
            }
            else
            {

                // close connection
                this.Database.DisconnectFromDatabase();

                queryReader.Close();
                return null;

            }



        }

        // method to get the value of the next 'id' for a given entry type
        public int GetNextId(DatabaseEntries entryType)
        {
            // create variable for return value
            int nextId = 0;

            // open connection
            this.Database.ConnectToDatabase();

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

            // close connection
            this.Database.DisconnectFromDatabase();

            return nextId;
        }

        // method to return all table values for an entry type
        public DataTable GetAllTableValues(DatabaseEntries entryType)
        {
            var AllRecords = new DataTable();

            // open connection
            this.Database.ConnectToDatabase();

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

                // special case to not select passwords for the user table 
                case DatabaseEntries.User:
                    query.CommandText = "SELECT userId, username, active, createDate, createdBy, lastUpdate, lastUpdateBy FROM user";
                    break;

            }

            // execute the query 
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
            {
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(AllRecords);
            }

            // close connection
            this.Database.DisconnectFromDatabase();

            return AllRecords;

        }

        // method to return all table values for an entry type
        public DataTable GetAppointmentsForUserWithDate(string user, DateTime filterStartDate, DateTime filterEndDate)
        {
            var AllRecords = new DataTable();

            // open connection
            this.Database.ConnectToDatabase();

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();

            query.CommandText = "SELECT * FROM appointment WHERE start >= @filterStartDate AND start <= @filterEndDate";
            query.Parameters.AddWithValue("@filterStartDate", filterStartDate);
            query.Parameters.AddWithValue("@filterEndDate", filterEndDate);


            // execute the query 
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
            {
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(AllRecords);
            }

            // close connection
            this.Database.DisconnectFromDatabase();

            return AllRecords;

        }

        // method to get a single record by its ID value (primary key)
        public object GetRecordById(int recordId, DatabaseEntries entryType)
        {
            // set up a dataTable object
            var Records = new DataTable();

            // set up return object
            Object Record = new Object();

            // open connection
            this.Database.ConnectToDatabase();

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();
            
            switch (entryType)
            {
                case DatabaseEntries.Address:
                    
                    // build the query
                    query.CommandText = "SELECT * FROM address WHERE addressId = @addressId";
                    query.Parameters.AddWithValue("@addressId", recordId);

                    // execute the query 
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
                    {
                        dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        dataAdapter.Fill(Records);
                    }

                    // generate a new object using the datarow
                    Record = new CustomerAddress(Records.Rows[0]);
                    break;

                case DatabaseEntries.Appointment:

                    // build the query
                    query.CommandText = "SELECT * FROM appointment WHERE appointmentId = @appointmentId";
                    query.Parameters.AddWithValue("@appointmentId", recordId);

                    // execute the query 
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
                    {
                        dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        dataAdapter.Fill(Records);
                    }

                    // generate a new object using the datarow
                    Record = new Appointment(Records.Rows[0]);

                    break;

                case DatabaseEntries.City:

                    // build the query
                    query.CommandText = "SELECT * FROM city WHERE cityId = @cityId";
                    query.Parameters.AddWithValue("@cityId", recordId);

                    // execute the query 
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
                    {
                        dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        dataAdapter.Fill(Records);
                    }

                    // generate a new object using the datarow
                    Record = new CustomerCity(Records.Rows[0]);

                    break;

                case DatabaseEntries.Country:

                    // build the query
                    query.CommandText = "SELECT * FROM country WHERE countryId = @countryId";
                    query.Parameters.AddWithValue("@countryId", recordId);

                    // execute the query 
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
                    {
                        dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        dataAdapter.Fill(Records);
                    }

                    // generate a new object using the datarow
                    Record = new CustomerCountry(Records.Rows[0]);
                    break;
                

                case DatabaseEntries.Customer:

                    // build the query
                    query.CommandText = "SELECT * FROM customer WHERE customerId = @customerId";
                    query.Parameters.AddWithValue("@customerId", recordId);

                    // execute the query 
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
                    {
                        dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        dataAdapter.Fill(Records);
                    }

                    // generate a new object using the datarow
                    Record = new Customer(Records.Rows[0]);
                    break;

            }

            // close connection
            this.Database.DisconnectFromDatabase();

            return Record;
        }

        // method to delete a record
        public bool DeleteRecord(int recordId, DatabaseEntries entryType)
        {
            // set up a bool return variable
            var IsDeleted = false;

            // open connection
            this.Database.ConnectToDatabase();

            // create the query
            MySqlCommand DeleteCommand = this.Database.SqlConnection.CreateCommand();

            // create a transaction object
            MySqlTransaction DeleteTransaction = this.Database.SqlConnection.BeginTransaction();

            // assign the transaction to the command object
            DeleteCommand.Transaction = DeleteTransaction;

            try { 

                switch (entryType)
                {
                    case DatabaseEntries.Address:

                        // build the query
                        DeleteCommand.CommandText = "DELETE FROM address WHERE addressId = @addressId";
                        DeleteCommand.Parameters.AddWithValue("@addressId", recordId);
                        break;

                    case DatabaseEntries.Appointment:

                        // build the query
                        DeleteCommand.CommandText = "DELETE FROM appointment WHERE appointmentId = @appointmentId";
                        DeleteCommand.Parameters.AddWithValue("@appointmentId", recordId);
                        break;

                    case DatabaseEntries.City:

                        // build the query
                        DeleteCommand.CommandText = "DELETE FROM city WHERE cityId = @cityId";
                        DeleteCommand.Parameters.AddWithValue("@cityId", recordId);
                        break;

                    case DatabaseEntries.Country:

                        // build the query
                        DeleteCommand.CommandText = "DELETE FROM country WHERE countryId = @countryId";
                        DeleteCommand.Parameters.AddWithValue("@countryId", recordId);
                        break;


                    case DatabaseEntries.Customer:

                        // build the query
                        DeleteCommand.CommandText = "DELETE FROM customer WHERE customerId = @customerId";
                        DeleteCommand.Parameters.AddWithValue("@customerId", recordId);
                        break;

                }


            // execute the query and commit the transaction    
            DeleteCommand.ExecuteNonQuery();
            DeleteTransaction.Commit();

            IsDeleted = true;

            }

            catch (Exception ex)
            {
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Error during DELETE operation: {ex.Message}");
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Rolling back Database transaction.");
                DeleteTransaction.Rollback();
                
            }


            // close connection
            this.Database.DisconnectFromDatabase();

            return IsDeleted;
        }

        // method to insert a record
        public bool InsertData(object Data, DatabaseEntries entryType) 
        {
            // declare local variable to track status
            bool IsInserted = false;

            // open connection
            this.Database.ConnectToDatabase();

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
                        InsertCommand.Parameters.AddWithValue("@addressId", Address.addressId);
                        InsertCommand.Parameters.AddWithValue("@address", Address.address);
                        InsertCommand.Parameters.AddWithValue("@address2", Address.address2);
                        InsertCommand.Parameters.AddWithValue("@cityId", Address.cityId);
                        InsertCommand.Parameters.AddWithValue("@postalCode", Address.postalCode);
                        InsertCommand.Parameters.AddWithValue("@phone", Address.phone);
                        InsertCommand.Parameters.AddWithValue("@createDate", Address.createDate);
                        InsertCommand.Parameters.AddWithValue("@createdBy", Address.createdBy);
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", Address.lastUpdate);
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", Address.lastUpdateBy);
                        break;

                    case DatabaseEntries.Appointment:
                        Appointment Appt = Data as Appointment;
                        InsertCommand.CommandText = "INSERT INTO appointment VALUES ( @appointmentId, @customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy )";
                        InsertCommand.Parameters.AddWithValue("@appointmentId", Appt.appointmentId);
                        InsertCommand.Parameters.AddWithValue("@customerId", Appt.customerId);
                        InsertCommand.Parameters.AddWithValue("@userId", Appt.userId);
                        InsertCommand.Parameters.AddWithValue("@title", Appt.title);
                        InsertCommand.Parameters.AddWithValue("@description", Appt.description);
                        InsertCommand.Parameters.AddWithValue("@location", Appt.location);
                        InsertCommand.Parameters.AddWithValue("@contact", Appt.contact);
                        InsertCommand.Parameters.AddWithValue("@type", Appt.type);
                        InsertCommand.Parameters.AddWithValue("@url", Appt.url);
                        InsertCommand.Parameters.AddWithValue("@start", Appt.start);
                        InsertCommand.Parameters.AddWithValue("@end", Appt.end);
                        InsertCommand.Parameters.AddWithValue("@createDate", Appt.createDate);
                        InsertCommand.Parameters.AddWithValue("@createdBy", Appt.createdBy);
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", Appt.lastUpdate);
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", Appt.lastUpdateBy);
                        break;

                    case DatabaseEntries.City:
                        break;

                    case DatabaseEntries.Country:
                        break;

                    case DatabaseEntries.Customer:
                        Customer Cust = Data as Customer;
                        InsertCommand.CommandText = "INSERT INTO customer VALUES ( @customerId, @customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                        InsertCommand.Parameters.AddWithValue("@customerId", Cust.customerId);
                        InsertCommand.Parameters.AddWithValue("@customerName", Cust.customerName);
                        InsertCommand.Parameters.AddWithValue("@addressId", Cust.addressId);
                        InsertCommand.Parameters.AddWithValue("@active", Cust.active);
                        InsertCommand.Parameters.AddWithValue("@createDate", Cust.createDate);
                        InsertCommand.Parameters.AddWithValue("@createdBy", Cust.createdBy);
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", Cust.lastUpdate);
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", Cust.lastUpdateBy);
                        break;


                }

            // execute the query and commit the transaction    
            InsertCommand.ExecuteNonQuery();
            InsertTransaction.Commit();

            IsInserted = true;

            }

            catch (Exception ex)
            {
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Error during INSERT operation: {ex.Message}");
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Rolling back Database transaction.");
                InsertTransaction.Rollback();
                
            }

            // close connection
            this.Database.DisconnectFromDatabase();

            return IsInserted;
        }

        // method to update a record 
        public bool UpdateData(object Data, DatabaseEntries entryType)
        {
            // declare local variable to track status
            bool IsUpdated = false;

            // open connection
            this.Database.ConnectToDatabase();

            // create a command object
            MySqlCommand UpdateCommand = this.Database.SqlConnection.CreateCommand();

            // create a transaction object
            MySqlTransaction UpdateTransaction = this.Database.SqlConnection.BeginTransaction();

            // assign the transaction to the command object
            UpdateCommand.Transaction = UpdateTransaction;

            try
            {

                switch (entryType)
                {
                    case DatabaseEntries.Address:
                        CustomerAddress Address = Data as CustomerAddress;
                        UpdateCommand.CommandText = "UPDATE address SET address = @address, address2 = @address2, cityId = @cityId, postalCode = @postalCode, phone = @phone, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy WHERE addressId = @addressId";
                        UpdateCommand.Parameters.AddWithValue("@addressId", Address.addressId);
                        UpdateCommand.Parameters.AddWithValue("@address", Address.address);
                        UpdateCommand.Parameters.AddWithValue("@address2", Address.address2);
                        UpdateCommand.Parameters.AddWithValue("@cityId", Address.cityId);
                        UpdateCommand.Parameters.AddWithValue("@postalCode", Address.postalCode);
                        UpdateCommand.Parameters.AddWithValue("@phone", Address.phone);
                        UpdateCommand.Parameters.AddWithValue("@lastUpdate", Address.lastUpdate);
                        UpdateCommand.Parameters.AddWithValue("@lastUpdateBy", Address.lastUpdateBy);
                        break;

                    case DatabaseEntries.Appointment:
                        Appointment Appt = Data as Appointment;
                        UpdateCommand.CommandText = "" +
                            "UPDATE appointment" +
                            "SET  customerId = @customerId, " +
                            "     userId = @userId, " +
                            "     title = @title, " +
                            "     description = @description, " +
                            "     location = @location, " +
                            "     contact = @contact, " +
                            "     type = @type, " +
                            "     url = @url, " +
                            "     start = @start, " +
                            "     end = @end, " +
                            "     lastUpdate = @lastUpdate, " +
                            "     lastUpdateBy = @lastUpdateBy" +
                            "WHERE appointmentId = @appointmentId";
                        UpdateCommand.Parameters.AddWithValue("@appointmentId", Appt.appointmentId);
                        UpdateCommand.Parameters.AddWithValue("@customerId", Appt.customerId);
                        UpdateCommand.Parameters.AddWithValue("@userId", Appt.userId);
                        UpdateCommand.Parameters.AddWithValue("@title", Appt.title);
                        UpdateCommand.Parameters.AddWithValue("@description", Appt.description);
                        UpdateCommand.Parameters.AddWithValue("@location", Appt.location);
                        UpdateCommand.Parameters.AddWithValue("@contact", Appt.contact);
                        UpdateCommand.Parameters.AddWithValue("@type", Appt.type);
                        UpdateCommand.Parameters.AddWithValue("@url", Appt.url);
                        UpdateCommand.Parameters.AddWithValue("@start", Appt.start);
                        UpdateCommand.Parameters.AddWithValue("@end", Appt.end);
                        UpdateCommand.Parameters.AddWithValue("@lastUpdate", Appt.lastUpdate);
                        UpdateCommand.Parameters.AddWithValue("@lastUpdateBy", Appt.lastUpdateBy);
                        break;

                    case DatabaseEntries.City:
                        break;

                    case DatabaseEntries.Country:
                        break;

                    case DatabaseEntries.Customer:
                        Customer Cust = Data as Customer;
                        UpdateCommand.CommandText = "UPDATE customer SET customerName = @customerName, active = @active, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy WHERE customerId = @customerId";
                            
                        UpdateCommand.Parameters.AddWithValue("@customerId", Cust.customerId);
                        UpdateCommand.Parameters.AddWithValue("@customerName", Cust.customerName);
                        UpdateCommand.Parameters.AddWithValue("@active", Cust.active);
                        UpdateCommand.Parameters.AddWithValue("@lastUpdate", Cust.lastUpdate);
                        UpdateCommand.Parameters.AddWithValue("@lastUpdateBy", Cust.lastUpdateBy);
                        break;


                }

                // execute the query and commit the transaction    
                UpdateCommand.ExecuteNonQuery();
                UpdateTransaction.Commit();

                IsUpdated = true;

            }

            catch (Exception ex)
            {
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Error during UPDATE operation: {ex.Message}");
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Rolling back Database transaction.");
                UpdateTransaction.Rollback();

            }

            // close connection
            this.Database.DisconnectFromDatabase();

            return IsUpdated;
        }

    }
    
}
