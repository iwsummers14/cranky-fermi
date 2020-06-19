using MySql.Data.MySqlClient;
using ScheduleBoss.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace ScheduleBoss.Classes
{
    /// <summary>
    /// Class to process data transactions between the application and the backend database.
    /// </summary>
    public class DataProcessor
    {
        
        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set;}

        public UserSession Session { get; set; }

        // constructor requiring a database connection and logger 
        public DataProcessor( DatabaseConnection DbConn, EventLogger Log)
        {
            // set properties passed in constructor
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
        
        // method to return all table values for an entry type
        public DataTable GetAllTableValues(DatabaseEntries entryType)
        {

            // establish return variable
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
        public DataTable GetAppointmentsForUserWithDate(int userId, DateTime filterStartDate, DateTime filterEndDate)
        {
            var AllRecords = new DataTable();

            // open connection
            this.Database.ConnectToDatabase();

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();

            string queryTmp = "SELECT a.appointmentId, c.customerName, a.title, a.description, a.location, a.contact, a.type, a.url, a.start, a.end";
            queryTmp += " FROM appointment a INNER JOIN customer c ON a.customerId = c.customerId";
            queryTmp += " WHERE start >= @filterStartDate AND start <= @filterEndDate AND userId = @userId";
            queryTmp += " ORDER BY start ASC";

            query.CommandText = queryTmp;
            query.Parameters.AddWithValue("@filterStartDate", filterStartDate);
            query.Parameters.AddWithValue("@filterEndDate", filterEndDate);
            query.Parameters.AddWithValue("@userId", userId);


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

        // method to return appointments for a user 
        public DataTable GetUpcomingAppointmentsForUser(int userId, int minutes)
        {

            // declare variables
            var AllRecords = new DataTable();
            var filterStartDate = DateTime.UtcNow;
            var filterEndDate = filterStartDate.AddMinutes(minutes);

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();

            string queryTmp = "SELECT a.appointmentId, c.customerName, a.title, a.description, a.location, a.contact, a.type, a.url, a.start, a.end";
            queryTmp += " FROM appointment a INNER JOIN customer c ON a.customerId = c.customerId";
            queryTmp += " WHERE start >= @filterStartDate AND start <= @filterEndDate AND userId = @userId";
            queryTmp += " ORDER BY start ASC";

            query.CommandText = queryTmp;
            query.Parameters.AddWithValue("@filterStartDate", filterStartDate);
            query.Parameters.AddWithValue("@filterEndDate", filterEndDate);
            query.Parameters.AddWithValue("@userId", userId);
        
            // open connection
            this.Database.ConnectToDatabase();

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

        // method to get a single record by its ID value (primary key), uses generic typing
        public T GetRecordById<T>(int recordId, DatabaseEntries entryType)
        {
            // set up a dataTable object
            var Records = new DataTable();

            // set up return object
            object Record = new Object();

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

            return (T) Record;
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

        // method to insert a record (uses generic typing)
        public bool InsertData<T>(T Data, DatabaseEntries entryType) 
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
                        // get the type object for the generic T object to allow for getting properties
                        Type typeAddress = Data.GetType();
                        InsertCommand.CommandText = "INSERT INTO address VALUES ( @addressId, @address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                        InsertCommand.Parameters.AddWithValue("@addressId", typeAddress.GetProperty("addressId").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@address", typeAddress.GetProperty("address").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@address2", typeAddress.GetProperty("address2").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@cityId", typeAddress.GetProperty("cityId").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@postalCode", typeAddress.GetProperty("postalCode").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@phone", typeAddress.GetProperty("phone").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@createDate", typeAddress.GetProperty("createDate").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@createdBy", typeAddress.GetProperty("createdBy").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", typeAddress.GetProperty("lastUpdate").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", typeAddress.GetProperty("lastUpdateBy").GetValue(Data));
                        break;

                    case DatabaseEntries.Appointment:
                        // get the type object for the generic T object to allow for getting properties
                        Type typeAppointment = Data.GetType();
                        InsertCommand.CommandText = "INSERT INTO appointment VALUES ( @appointmentId, @customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy )";
                        InsertCommand.Parameters.AddWithValue("@appointmentId", typeAppointment.GetProperty("appointmentId").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@customerId", typeAppointment.GetProperty("customerId").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@userId", typeAppointment.GetProperty("userId").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@title", typeAppointment.GetProperty("title").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@description", typeAppointment.GetProperty("description").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@location", typeAppointment.GetProperty("location").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@contact", typeAppointment.GetProperty("contact").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@type", typeAppointment.GetProperty("type").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@url", typeAppointment.GetProperty("url").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@start", typeAppointment.GetProperty("start").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@end", typeAppointment.GetProperty("end").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@createDate", typeAppointment.GetProperty("createDate").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@createdBy", typeAppointment.GetProperty("createdBy").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", typeAppointment.GetProperty("lastUpdate").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", typeAppointment.GetProperty("lastUpdateBy").GetValue(Data));
                        break;

                    case DatabaseEntries.City:
                        break;

                    case DatabaseEntries.Country:
                        break;

                    case DatabaseEntries.Customer:
                        Type typeCust = Data.GetType();
                        InsertCommand.CommandText = "INSERT INTO customer VALUES ( @customerId, @customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                        InsertCommand.Parameters.AddWithValue("@customerId", typeCust.GetProperty("customerId").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@customerName", typeCust.GetProperty("customerName").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@addressId", typeCust.GetProperty("addressId").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@active", typeCust.GetProperty("active").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@createDate", typeCust.GetProperty("createDate").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@createdBy", typeCust.GetProperty("createdBy").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@lastUpdate", typeCust.GetProperty("lastUpdate").GetValue(Data));
                        InsertCommand.Parameters.AddWithValue("@lastUpdateBy", typeCust.GetProperty("lastUpdateBy").GetValue(Data));
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

        // method to update a record (uses generic typing)
        public bool UpdateData<T>(T Data, DatabaseEntries entryType)
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
                string queryTemp = String.Empty;

                switch (entryType)
                {
                    case DatabaseEntries.Address:
                        
                        // get a type object for the generic T Data to allow for getting property values
                        Type typeAddress = Data.GetType();
                        queryTemp = "UPDATE address";
                        queryTemp += " SET address = @address,";
                        queryTemp += " address2 = @address2,";
                        queryTemp += " cityId = @cityId,";
                        queryTemp += " postalCode = @postalCode,";
                        queryTemp += " phone = @phone,";
                        queryTemp += " lastUpdate = @lastUpdate,";
                        queryTemp += " lastUpdateBy = @lastUpdateBy";
                        queryTemp += " WHERE addressId = @addressId";
                        UpdateCommand.CommandText = queryTemp;
                        UpdateCommand.Parameters.AddWithValue("@addressId", typeAddress.GetProperty("addressId").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@address", typeAddress.GetProperty("address").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@address2", typeAddress.GetProperty("address2").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@cityId", typeAddress.GetProperty("cityId").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@postalCode", typeAddress.GetProperty("postalCode").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@phone", typeAddress.GetProperty("phone").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@lastUpdate", typeAddress.GetProperty("lastUpdate").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@lastUpdateBy", typeAddress.GetProperty("lastUpdateBy").GetValue(Data));
                        break;

                    case DatabaseEntries.Appointment:

                        // get a type object for the generic T Data to allow for getting property values
                        Type typeAppointment = Data.GetType();
                        queryTemp = "UPDATE appointment ";
                        queryTemp += " SET customerId = @customerId,";
                        queryTemp += " userId = @userId,";
                        queryTemp += " title = @title,";
                        queryTemp += " description = @description,";
                        queryTemp += " location = @location,";
                        queryTemp += " contact = @contact,";
                        queryTemp += " type = @type,";
                        queryTemp += " url = @url,";
                        queryTemp += " start = @start,";
                        queryTemp += " end = @end,";
                        queryTemp += " lastUpdate = @lastUpdate,";
                        queryTemp += " lastUpdateBy = @lastUpdateBy";
                        queryTemp += " WHERE appointmentId = @appointmentId";
                        
                        UpdateCommand.CommandText = queryTemp;
                        UpdateCommand.Parameters.AddWithValue("@appointmentId", typeAppointment.GetProperty("appointmentId").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@customerId", typeAppointment.GetProperty("customerId").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@userId", typeAppointment.GetProperty("userId").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@title", typeAppointment.GetProperty("title").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@description", typeAppointment.GetProperty("description").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@location", typeAppointment.GetProperty("location").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@contact", typeAppointment.GetProperty("contact").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@type", typeAppointment.GetProperty("type").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@url", typeAppointment.GetProperty("url").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@start", typeAppointment.GetProperty("start").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@end", typeAppointment.GetProperty("end").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@lastUpdate", typeAppointment.GetProperty("lastUpdate").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@lastUpdateBy", typeAppointment.GetProperty("lastUpdateBy").GetValue(Data));
                        break;

                    case DatabaseEntries.City:
                        break;

                    case DatabaseEntries.Country:
                        break;

                    case DatabaseEntries.Customer:

                        // get a type object for the generic T Data to allow for getting property values
                        Type typeCust = Data.GetType();
                        
                        queryTemp = "UPDATE customer";
                        queryTemp += " SET customerName = @customerName,";
                        queryTemp += " active = @active,";
                        queryTemp += " lastUpdate = @lastUpdate,";
                        queryTemp += " lastUpdateBy = @lastUpdateBy";
                        queryTemp += " WHERE customerId = @customerId";

                        UpdateCommand.CommandText = queryTemp;
                        UpdateCommand.Parameters.AddWithValue("@customerId", typeCust.GetProperty("customerId").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@customerName", typeCust.GetProperty("customerName").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@active", typeCust.GetProperty("active").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@lastUpdate", typeCust.GetProperty("lastUpdate").GetValue(Data));
                        UpdateCommand.Parameters.AddWithValue("@lastUpdateBy", typeCust.GetProperty("lastUpdateBy").GetValue(Data));
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

        // method to check for appointment overlap with optional appointmentId param
        public bool ValidateAppointmentTimesForUser(int userId, DateTime Start, DateTime End, int apptId = 0)
        {
            // declare a return value
            bool IsOverlapping = false;

            var ConflictingRecords = new DataTable();

            // open connection
            this.Database.ConnectToDatabase();

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();

            string queryTmp = "SELECT * FROM appointment";
            queryTmp += " WHERE userId = @userId";
            queryTmp += " AND appointmentId != @appointmentId";
            queryTmp += " AND ((start > @filterStartDate AND start < @filterEndDate)";
            queryTmp += " OR (end > @filterStartDate AND end < @filterEndDate)";
            queryTmp += " OR (start = @filterStartDate)";
            queryTmp += " OR (end = @filterEndDate))";


            query.CommandText = queryTmp;
            query.Parameters.AddWithValue("@appointmentId", apptId);
            query.Parameters.AddWithValue("@filterStartDate", Start);
            query.Parameters.AddWithValue("@filterEndDate", End);
            query.Parameters.AddWithValue("@userId", userId);
                       
            // execute the query 
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
            {
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(ConflictingRecords);
            }

            // close connection
            this.Database.DisconnectFromDatabase();

            // look for any records returned, if so, there was a conflict
            if (ConflictingRecords.Rows.Count > 0)
            {
                IsOverlapping = true;
            }

            return IsOverlapping;
        }
        
        #region REPORT METHODS

        // method to get the number of each Appointment type, ordered by Month
        public List<string> GetAppointmentTypesByMonth()
        {

            // set up local variables
            List<string> reportData = new List<string>();
            var AllRecords = new DataTable();

            // open connection
            this.Database.ConnectToDatabase();

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();

            string queryTmp = "SELECT type,";
            queryTmp += " COUNT(*) count,";
            queryTmp += " MONTH(start) month";
            queryTmp += " FROM U047yU.appointment";
            queryTmp += " GROUP BY type";
            queryTmp += " ORDER BY month";

            query.CommandText = queryTmp;

            // execute the query 
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
            {
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(AllRecords);
            }

            // close connection
            this.Database.DisconnectFromDatabase();

            // extract the unique months from the months column. uses a lambda to select the field value before sending it to LINQ
            // methods to only get unique values and return a list
            List<int> Months = AllRecords.AsEnumerable().Select(row => row.Field<int>("month")).Distinct().ToList();

            // add report lines. pivoting off of unique values for months, gets the other relevant data
            // and adds formatted strings to the return list. uses culture info to get the month name
            foreach (int Month in Months)
            {
                reportData.Add($"Appointment types for: {CultureInfo.CurrentUICulture.DateTimeFormat.GetMonthName(Month)}");
                reportData.Add($"================================================================================");

                var typesThisMonth = AllRecords.Select($"month = {Month}");

                foreach (DataRow row in typesThisMonth)
                {
                    reportData.Add($"\t{row["type"].ToString()}: {row["count"].ToString()}");
                }
                reportData.Add(" ");
            }


            return reportData;
        }

        // method to get a schedule - that is, all appointments for a given consultant 
        public List<string> GetScheduleByConsultant()
        {
            // set up local variables
            List<string> reportData = new List<string>();
            var AllRecords = new DataTable();

            // open connection
            this.Database.ConnectToDatabase();

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();

            string queryTmp = "SELECT ";
            queryTmp += " u.userName consultant,";
            queryTmp += " c.customerName customer,";
            queryTmp += " a.title title,";
            queryTmp += " a.start startTime,";
            queryTmp += " a.end endTime";
            queryTmp += " FROM appointment a";
            queryTmp += " INNER JOIN user u ON a.userId = u.userId";
            queryTmp += " INNER JOIN customer c ON a.customerId = c.customerId";
            queryTmp += " ORDER BY consultant, startTime ASC";

            query.CommandText = queryTmp;

            // execute the query 
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
            {
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(AllRecords);
            }

            // close connection
            this.Database.DisconnectFromDatabase();

            // extract the unique consultants from the consultants column. uses a lambda to select the field value before sending it to LINQ
            // methods to only get unique values and return a list
            List<string> Consultants = AllRecords.AsEnumerable().Select(row => row.Field<string>("consultant")).Distinct().ToList();

            // add report lines. pivoting off of unique values in consultants, gets the other relevant data
            // and adds formatted strings to the return list
            foreach (string Consultant in Consultants)
            {

                reportData.Add($"Appointments for: {Consultant}");
                reportData.Add($"================================================================");

                var apptsThisUser = AllRecords.Select($"consultant = '{Consultant}'");

                foreach (DataRow row in apptsThisUser)
                {
                    reportData.Add($"Meeting with: {row["customer"].ToString()}");
                    reportData.Add($"\t\t Start time: {row["startTime"].ToString()}\t\t End time: {row["endTime"].ToString()}");
                }
                reportData.Add(" ");
            }


            return reportData;
        }

        // method to get the number of appointments scheduled, by customer
        public List<string> GetAppointmentsByCustomer()
        {

            // set up local variables
            List<string> reportData = new List<string>();
            var AllRecords = new DataTable();

            // open connection
            this.Database.ConnectToDatabase();

            // create the query
            MySqlCommand query = this.Database.SqlConnection.CreateCommand();

            string queryTmp = "SELECT 	a.customerId,";
            queryTmp += " c.customerName,";
            queryTmp += " COUNT(*) count";
            queryTmp += " FROM U047yU.appointment a";
            queryTmp += " INNER JOIN U047yU.customer c on a.customerId = c.customerId";
            queryTmp += " GROUP BY customerName";
            queryTmp += " ORDER BY customerId";

            query.CommandText = queryTmp;

            // execute the query 
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query))
            {
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(AllRecords);
            }

            // close connection
            this.Database.DisconnectFromDatabase();

            // extract the unique customers from the customers column. uses a lambda to select the field value before sending it to LINQ
            // methods to only get unique values and return a list
            List<string> Customers = AllRecords.AsEnumerable().Select(row => row.Field<string>("customerName")).Distinct().ToList();

            // add report lines. pivoting off of unique values in customers, gets the other relevant data
            // and adds formatted strings to the return list
            foreach (string Customer in Customers)
            {
                reportData.Add($"Scheduled appointment counts for: {Customer}");
                reportData.Add($"================================================================================");

                var typesThisMonth = AllRecords.Select($"customerName = '{Customer}'");

                foreach (DataRow row in typesThisMonth)
                {
                    reportData.Add($"\tAppointments scheduled: {row["count"].ToString()}");
                }
                reportData.Add(" ");
            }

            // return data to report viewer
            return reportData;
        }
        
        #endregion

    }

}
