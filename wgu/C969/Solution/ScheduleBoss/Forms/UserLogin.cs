using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using ScheduleBoss.Classes;
using MySql.Data.MySqlClient;

namespace ScheduleBoss.Forms
{
    public partial class UserLogin : Form
    {

        public DatabaseConnection Connection { get; set; }

        public bool IsAuthenticated { get; set; } = false;

        public int LoginAttempts { get; set; } = 0;

        public LoginResponse LoginResponse { get; set; }

        public EventLogger EventLogger { get; set; }

        public UserLogin(CultureInfo culture, DatabaseConnection DbConn, ref EventLogger Logger)
        {
            InitializeComponent();

            // set this form's connection object to the passed connection
            this.Connection = DbConn;

            // set this form's logger object to the passed eventlogger
            this.EventLogger = Logger;
            this.EventLogger.WriteLog($"{DateTime.Now.ToString()} [INFO] Processing user login");

            // set the current ui culture based on the passed culture info
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture.Name);
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // get username and password entered by user
            string Username = mTextBox_username.Text;
            string Password = mTextBox_password.Text;

            if (this.LoginAttempts < 3)
            {

                // create the login query with parameters to prevent injection
                MySqlCommand query = this.Connection.SqlConnection.CreateCommand();
                query.CommandText = "SELECT * FROM user WHERE username = @username AND password = @password";
                query.Parameters.AddWithValue("@username", Username);
                query.Parameters.AddWithValue("@password", Password);

                // execute the query and read results
                MySqlDataReader queryReader = query.ExecuteReader();

                if (queryReader.HasRows)
                {
                    MessageBox.Show(
                        $"User {Username} was authenticated successfully!",
                        "Authentication successful.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // initialize the login response property
                    this.LoginResponse = new LoginResponse();

                    // read the query data
                    queryReader.Read();

                    // assign login response fields from query data
                    this.LoginResponse.UserId = queryReader.GetInt32(0);
                    this.LoginResponse.Username = queryReader.GetString(1);
                    this.LoginResponse.IsActive = queryReader.GetBoolean(3);
                    this.LoginResponse.CreateDate = queryReader.GetDateTime(4);
                    this.LoginResponse.CreatedBy = queryReader.GetString(5);
                    this.LoginResponse.LastUpdate = queryReader.GetDateTime(6);
                    this.LoginResponse.LastUpdateBy = queryReader.GetString(7);
                    
                    queryReader.Close();

                    // log the event
                    this.EventLogger.WriteLog($"{DateTime.Now.ToString()} [INFO] User {Username} authenticated successfully.");

                    // set property and exit
                    this.IsAuthenticated = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        $"The username or password was incorrect. Please check your entries and try again.",
                        "Authentication failed.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    // log the event
                    this.EventLogger.WriteLog($"{DateTime.Now.ToString()} [WARN] User {Username} failed to authenticate.");

                    // increment the attempt counter
                    this.LoginAttempts++;

                    // log the attempt counter
                    this.EventLogger.WriteLog($"{DateTime.Now.ToString()} [INFO] User {Username} has attempted authentication {LoginAttempts.ToString()} times.");

                    queryReader.Close();
                }

            }
                  
            else
            {
                
                // display message to user
                MessageBox.Show(
                       $"You have exceeded the maximum number of attempts. The application will now close.",
                       "Authentication failed.",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                   );

                // log that the attempt counter max was reached
                this.EventLogger.WriteLog($"{DateTime.Now.ToString()} [ERROR] User {Username} has failed authentication {LoginAttempts.ToString()} times.");
                this.EventLogger.WriteLog($"{DateTime.Now.ToString()} [INFO] Application exiting due to repeated login failures.");
                
                // close 
                this.Close();
            }
            
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
                       
        }
    }
}
