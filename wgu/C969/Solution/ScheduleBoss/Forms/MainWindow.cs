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
using ScheduleBoss.Forms;


namespace ScheduleBoss
{
    public partial class MainWindow : Form
    {

        public UserSession Session { get; set; }

        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // establish a database connection
            this.Database = new DatabaseConnection();
            //var connected = Database.ConnectToDatabase();

            // establish a logger
            this.Logger = new EventLogger(".\\UserAuth.log");
            this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Application started");

            // get the current culture of the user's system
            CultureInfo CurrentCulture = Thread.CurrentThread.CurrentCulture; 

            // launch the user login form using the culture information and database connection,
            // with an event handler to deal with the login status
            UserLogin LoginPrompt = new Forms.UserLogin(CurrentCulture, this.Database, this.Logger );
            LoginPrompt.FormClosed += new FormClosedEventHandler(LoginPrompt_FormClosed);
            LoginPrompt.Show();
            
                        
        }

        

        private void btn_AddAppointment_Click(object sender, EventArgs e)
        {
            Form NewAppt = new NewAppointment();
            NewAppt.FormClosed += new FormClosedEventHandler(Appt_FormClosed);
            NewAppt.Show();
        }

        private void btn_ModifyAppointment_Click(object sender, EventArgs e)
        {
           // Form ModAppt = new ModifyAppointment();
           // ModAppt.FormClosed += new FormClosedEventHandler(Appt_FormClosed);
           // ModAppt.Show();
        }

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            NewCustomer NewCust = new NewCustomer( this.Database, this.Logger, this.Session );
            NewCust.FormClosed += new FormClosedEventHandler(Cust_FormClosed);
            NewCust.Show();

        }

        private void btn_ModifyCustomer_Click(object sender, EventArgs e)
        {
            CustomerList CustList = new CustomerList(this.Database, this.Logger, this.Session);
            CustList.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            //this.Database.DisconnectFromDatabase();
            this.Close();
        }

        private void toolStripSessionLabel_Click(object sender, EventArgs e)
        {

        }

        // FORM CLOSE EVENT HANDLERS

        private void LoginPrompt_FormClosed(object sender, FormClosedEventArgs e)
        {
            // cast the sender as a UserLogin object 
            UserLogin login = sender as UserLogin;

            // check to see if it authenticated, exit application if it did not
            if (login.IsAuthenticated == true)
            {

                // initialize the session
                this.Session = new UserSession();

                // set the session properties returned from the login form
                this.Session.IsAuthenticated = login.IsAuthenticated;
                this.Session.UserLoginInfo = login.LoginResponse;
                this.Session.UserLoginTime = DateTime.Now;

                // set status bar text
                this.toolStripSessionLabel.Text = $"User: {this.Session.UserLoginInfo.Username} | Login Time: {this.Session.UserLoginTime.ToString()} | Current Time Zone: {this.Session.UserTimeZone.StandardName}";

            }
            else
            {
                this.Close();
            }


        }

        private void Appt_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Cust_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        // END FORM CLOSE EVENT HANDLERS


    }
}
