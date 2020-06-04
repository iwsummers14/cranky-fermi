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
using ScheduleBoss.Enums;

namespace ScheduleBoss.Forms
{
    public partial class UserLogin : Form
    {

        public DatabaseConnection Connection { get; set; }

        public bool IsAuthenticated { get; set; } = false;

        public int LoginAttempts { get; set; } = 0;

        public LoginResponse LoginResponse { get; set; }

        public EventLogger Logger { get; set; }

        public DataProcessor DataProcessor { get; set; }

        public UserLogin(CultureInfo culture, DatabaseConnection DbConn, EventLogger Log)
        {
            InitializeComponent();

            // set this form's connection object to the passed connection
            this.Connection = DbConn;

            // set this form's logger object to the passed eventlogger
            this.Logger = Log;
            this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Processing user login");

            // initialize the data processor 
            this.DataProcessor = new DataProcessor(this.Connection, this.Logger);

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
                // attempt to authenticate the user 
                this.LoginResponse = this.DataProcessor.AuthenticateUser(Username, Password);
                
                if (this.LoginResponse != null) {

                    // log the event
                    this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] User {Username} authenticated successfully.");

                    // notify the user
                    MessageBox.Show(
                       $"User {Username} was authenticated successfully!",
                       "Authentication successful.",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                   );

                    // set property and exit
                    this.IsAuthenticated = true;
                    this.Close();

                }

                else
                {
                    // notify the user of the failure
                    MessageBox.Show(
                       $"The username or password was incorrect. Please check your entries and try again.",
                       "Authentication failed.",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning
                    );

                    // log the event
                    this.Logger.WriteLog($"{DateTime.Now.ToString()} [WARN] User {Username} failed to authenticate.");

                    // increment the attempt counter
                    this.LoginAttempts++;

                    // log the attempt counter
                    this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] User {Username} has attempted authentication {LoginAttempts.ToString()} times.");
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
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] User {Username} has failed authentication {LoginAttempts.ToString()} times.");
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Application exiting due to repeated login failures.");
                
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
