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


        public UserLogin(CultureInfo culture, DatabaseConnection DbConn)
        {
            InitializeComponent();

            // set this form's connection object to the passed connection
            this.Connection = DbConn;

            // set the current ui culture based on the passed culture info
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture.Name);
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            
            if (this.LoginAttempts < 3)
            {

                // get username and password entered by user
                string Username = mTextBox_username.Text;
                string Password = mTextBox_password.Text;

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

                    queryReader.Close();

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

                    // increment the attempt counter
                    this.LoginAttempts++;

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
