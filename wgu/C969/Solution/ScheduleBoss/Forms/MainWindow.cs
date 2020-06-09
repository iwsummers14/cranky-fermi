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
using ScheduleBoss.Enums;


namespace ScheduleBoss
{
    public partial class MainWindow : Form
    {

        public UserSession Session { get; set; }

        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set; }

        public DataProcessor DataProc { get; set; }

        public CultureInfo CurrentCulture { get; set; }

        public DataTable Customers { get; set; }

        public DataTable Users { get; set; }

        public DataTable WeekAppointments { get; set; }

        public BindingSource WeekViewSource { get; set; } = new BindingSource();

        public DataTable MonthAppointments { get; set; }

        public BindingSource MonthViewSource { get; set; } = new BindingSource();

        public MainWindow()
        {
            InitializeComponent();

            // establish a database connection
            this.Database = new DatabaseConnection();

            // establish a logger
            this.Logger = new EventLogger(".\\UserAuth.log");
            this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Application started");

            // initialize a data processor
            this.DataProc = new DataProcessor(this.Database, this.Logger);

            // get the current culture of the user's system
            this.CurrentCulture = Thread.CurrentThread.CurrentCulture; 
           
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // launch the user login form using the culture information and database connection,
            // with an event handler to deal with the login status
            UserLogin LoginPrompt = new Forms.UserLogin(this.CurrentCulture, this.Database, this.Logger);
            LoginPrompt.FormClosed += new FormClosedEventHandler(LoginPrompt_FormClosed);
            LoginPrompt.Show();

        }


        private void btn_AddAppointment_Click(object sender, EventArgs e)
        {
            Form NewAppt = new NewAppointment(this.Database, this.Logger, this.Session);
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

                // get user and customer datatables
                this.Customers = DataProc.GetAllTableValues(DatabaseEntries.Customer);
                this.Users = DataProc.GetAllTableValues(DatabaseEntries.User);

                // get the appointments for next 7 and next 30 days
                DateTime FilterStart = Session.ConvertDateTimeToUtc(DateTime.Now);
                DateTime WeekFilterEnd = Session.ConvertDateTimeToUtc(DateTime.Now.AddDays(7));
                DateTime MonthFilterEnd = Session.ConvertDateTimeToUtc(DateTime.Now.AddDays(31));

                this.WeekAppointments = DataProc.GetAppointmentsForUserWithDate(this.Session.UserLoginInfo.Username, FilterStart, WeekFilterEnd);
                this.MonthAppointments = DataProc.GetAppointmentsForUserWithDate(this.Session.UserLoginInfo.Username, FilterStart, MonthFilterEnd);



                /* create a dataset - this may need to be a new function in DataProcessor
                DataSet GridViewDataSetWeek = new DataSet();
                GridViewDataSetWeek.Tables.AddRange(this.Customers, this.Users, this.WeekAppointments);

                var DataTableWeek =
                    from rows in GridViewDataSetWeek.Tables["appointment"].AsEnumerable()
                    join rows2 in GridViewDataSetWeek.Tables["customer"].AsEnumerable()
                    on rows.Field<int>("customerId") equals rows2.Field<int>("customerId") into jointable
                    from joinedrows in jointable.DefaultIfEmpty()
                    select tableResult.LoadDataRow(new object[] 
                    {
                        
                    
                    });
                */


                // set data binding on gridviews
                this.WeekViewSource.DataSource = this.WeekAppointments;
                dataGridWeek.DataSource = this.WeekViewSource;

                this.MonthViewSource.DataSource = this.MonthAppointments;
                dataGridMonth.DataSource = this.MonthViewSource;

                // set gridview display options

                // set gridview options for both views - lambda expressions used to reduce repetitive code.
                // first lambda is for the tab pages in the tab control; this adds the DataGridViews to the global list
                var TabPages = tabControlAppts.TabPages.OfType<TabPage>().ToList();
                var DataGridList = new List<DataGridView>();

                // add all DataGridView controls to the global list
                TabPages.ForEach(
                        p => DataGridList.AddRange(
                            p.Controls.OfType<DataGridView>()
                        )
                    );
                
                // second lambda sets the same options across both gridviews since they have the same data but for different ranges
                // set standard options on all datagrid views for this form
                DataGridList.ForEach( 
                    v => {
                        // set options
                        v.RowHeadersVisible = false;
                        v.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        v.AllowUserToAddRows = false;
                        v.AllowUserToDeleteRows = false;
                        v.AllowUserToResizeRows = false;
                        v.AllowUserToOrderColumns = false;
                        v.EditMode = DataGridViewEditMode.EditProgrammatically;
                        v.MultiSelect = false;
                        
                        // set column display options
                        v.Columns["appointmentId"].HeaderText = "Appointment ID";
                        v.Columns["appointmentId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["appointmentId"].DisplayIndex = 0;
                        
                        v.Columns["customerId"].HeaderText = "Customer ID";
                        v.Columns["customerId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["customerId"].DisplayIndex = 1;

                        v.Columns["userId"].HeaderText = "User ID";
                        v.Columns["userId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["userId"].DisplayIndex = 2;

                        v.Columns["title"].HeaderText = "Title";
                        v.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        v.Columns["title"].DisplayIndex = 3;

                        v.Columns["description"].HeaderText = "Description";
                        v.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["description"].DisplayIndex = 4;

                        v.Columns["location"].HeaderText = "Location";
                        v.Columns["location"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["location"].DisplayIndex = 5;

                        v.Columns["contact"].HeaderText = "Contact";
                        v.Columns["contact"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["contact"].DisplayIndex = 6;

                        v.Columns["type"].HeaderText = "Type";
                        v.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["type"].DisplayIndex = 7;

                        v.Columns["url"].HeaderText = "URL";
                        v.Columns["url"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["url"].DisplayIndex = 8;

                        v.Columns["start"].HeaderText = "Starts";
                        v.Columns["start"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["start"].DisplayIndex = 9;

                        v.Columns["end"].HeaderText = "Ends";
                        v.Columns["end"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["end"].DisplayIndex = 10;

                        v.Columns["createDate"].HeaderText = "Create Date";
                        v.Columns["createDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["createDate"].DisplayIndex = 11;

                        v.Columns["createdBy"].HeaderText = "Created By";
                        v.Columns["createdBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["createdBy"].DisplayIndex = 12;

                        v.Columns["lastUpdate"].HeaderText = "Last Update";
                        v.Columns["lastUpdate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["lastUpdate"].DisplayIndex = 13;

                        v.Columns["lastUpdateBy"].HeaderText = "Updated By";
                        v.Columns["lastUpdateBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        v.Columns["lastUpdateBy"].DisplayIndex = 14;
                    }
                );
               

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
