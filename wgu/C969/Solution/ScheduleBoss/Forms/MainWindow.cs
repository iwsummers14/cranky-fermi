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
        public MainWindow()
        {
            InitializeComponent();

            // establish a database connection
            DatabaseConnection DbConn = new DatabaseConnection();

            var connected = DbConn.ConnectToDatabase();


            // get the current culture of the user's system
            CultureInfo CurrentCulture = Thread.CurrentThread.CurrentCulture; 

            // launch the user login form using the culture information and database connection,
            // with an event handler to deal with the login status
            UserLogin LoginPrompt = new Forms.UserLogin(CurrentCulture, DbConn);
            LoginPrompt.FormClosed += new FormClosedEventHandler(LoginPrompt_FormClosed);
            LoginPrompt.Show();
            
                        
        }

        private void LoginPrompt_FormClosed(object sender, FormClosedEventArgs e)
        {
            // cast the sender as a UserLogin object 
            UserLogin login = sender as UserLogin;

            // check to see if it authenticated, exit application if it did not
            if (login.IsAuthenticated == false)
            {
                this.Close();
            }

        }

    }
}
