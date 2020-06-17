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

        public string LogFilePath { get; set; } = $".\\ScheduleBoss_UserActivity_{DateTime.Now.ToShortDateString().Replace("/", "-")}.log";

        public DataProcessor DataProc { get; set; }

        public CultureInfo CurrentCulture { get; set; }

        public Dictionary<string, DateTime> WeekFilterDates { get; set; }

        public Dictionary<string, DateTime> MonthFilterDates { get; set; }

        public DataTable WeekAppointments { get; set; }

        public BindingSource WeekViewSource { get; set; } = new BindingSource();

        public DataTable MonthAppointments { get; set; }

        public BindingSource MonthViewSource { get; set; } = new BindingSource();

        public BackgroundWorker AppointmentChecker { get; set; }  = new BackgroundWorker();

        public System.Windows.Forms.Timer AppointmentCheckerTimer { get; set; } = new System.Windows.Forms.Timer();


        public MainWindow()
        {
            InitializeComponent();

            // establish a database connection
            this.Database = new DatabaseConnection();

            // establish a logger
            this.Logger = new EventLogger(this.LogFilePath);
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

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // cancel any async tasks that are occurring and dispose
            CancelAndDisposeBackgroundWorker();
            this.Logger.Dispose();
        }

        private void btn_AddAppointment_Click(object sender, EventArgs e)
        {
            Form NewAppt = new NewAppointment(this.Database, this.Logger, this.Session);
            NewAppt.FormClosed += new FormClosedEventHandler(Child_FormClosed);
            NewAppt.Show();
        }

        private void btn_ModifyAppointment_Click(object sender, EventArgs e)
        {
            

            // get the active DGV from the tab control (using the tab that is selected)
            // this is a foreach but there is only one DGV per tab.
            tabControlAppts.SelectedTab.Controls.OfType<DataGridView>().ToList().ForEach(
                
                dgv =>
                {
                    // if a row was selected, get the underlying object to modify
                    if (dgv.SelectedRows.Count > 0)
                    {

                        // cast the selected row as a DataRowView and extract the row from it
                        DataRow row = ((DataRowView)dgv.CurrentRow.DataBoundItem).Row;
                        int apptId = int.Parse(row[0].ToString());
                        
                        // get the associated record from the database
                        Appointment Appt = this.DataProc.GetRecordById(apptId, DatabaseEntries.Appointment) as Appointment;

                        // create an instance of the form and display it
                        Form ModAppt = new ModifyAppointment(this.Database, this.Logger, this.Session, Appt);
                        ModAppt.FormClosed += new FormClosedEventHandler(Child_FormClosed);
                        ModAppt.Show();


                    }

                    // do nothing if nothing was selected
                    else
                    {

                        return;

                    }
                }
                
            );

        }

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            NewCustomer NewCust = new NewCustomer( this.Database, this.Logger, this.Session );
            NewCust.FormClosed += new FormClosedEventHandler(Child_FormClosed);
            NewCust.Show();

        }

        private void btn_ModifyCustomer_Click(object sender, EventArgs e)
        {
            CustomerList CustList = new CustomerList(this.Database, this.Logger, this.Session);
            CustList.FormClosed += new FormClosedEventHandler(Child_FormClosed);
            CustList.Show();
        }

        private void btn_ViewReports_Click(object sender, EventArgs e)
        {
            Form ReportVwr = new ReportViewer(this.Database, this.Logger, this.Session);
            ReportVwr.FormClosed += new FormClosedEventHandler(Child_FormClosed);
            ReportVwr.Show();
        }

        private void btn_ViewLog_Click(object sender, EventArgs e)
        {
            Form LogVwr = new LogViewer(this.LogFilePath);
            LogVwr.FormClosed += new FormClosedEventHandler(Child_FormClosed);
            LogVwr.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {

            // cancel any async tasks that are occurring and close the form
            CancelAndDisposeBackgroundWorker();
            this.Logger.Dispose();
            this.Close();
        }

        private void tabControlAppts_Selected(object sender, TabControlEventArgs e)
        {
            // set the date range label appropriately based on week or month view
            SetDateRangeLabel();

        }

        #region BACKGROUND WORKER METHODS
        private void InitializeBackgroundWorker()
        {
            // set the background worker to support cancellation
            this.AppointmentChecker.WorkerSupportsCancellation = true;

            // assign a method to the DoWork event handler with a lambda expression - simplifies syntax
            this.AppointmentChecker.DoWork += (obj, e) => AppointmentChecker_Worker(obj, e);
            
            // assign a method to the RunWorkerCompleted event handler with a lambda expression - simplifies syntax
            this.AppointmentChecker.RunWorkerCompleted += (obj, e) => AppointmentChecker_WorkCompleted(obj, e);
        }

        private void AppointmentChecker_Worker(object sender, DoWorkEventArgs e) 
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (!worker.CancellationPending) 
            {
                // start a task to check for upcoming appointments in next 15 minutes
                e.Result = this.DataProc.GetUpcomingAppointmentsForUser(Session.UserLoginInfo.UserId, 15);
            }
                    
        }

        private void AppointmentChecker_WorkCompleted(object sender, RunWorkerCompletedEventArgs e) 
        {
            
            BackgroundWorker worker = sender as BackgroundWorker;

            var UpcomingAppointments = e.Result as DataTable;

            if (UpcomingAppointments.Rows.Count > 0)
            {
                foreach (DataRow row in UpcomingAppointments.Rows)
                {
                    // convert the time from utc
                    var Start = Session.ConvertDateTimeFromUtc(DateTime.Parse(row["start"].ToString()));

                    // alert the user for each appointment
                    MessageBox.Show(
                            $"Upcoming appointment, starting at {Start}!\n\nAppointment Title: {row["title"].ToString()}\nCustomer: {row["customerName"].ToString()}\nLocation: {row["location"].ToString()}\nURL: {row["url"].ToString()}",
                            "Upcoming Appointment",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                    );
                }

            }

        }

        private void AppointmentChecker_TimerWrapper(object sender, EventArgs e)
        {
            // run the background worker 
            this.AppointmentChecker.RunWorkerAsync();
        }
        #endregion

        #region CHILD FORM CLOSE EVENT HANDLERS

        private void LoginPrompt_FormClosed(object sender, FormClosedEventArgs e)
        {
            // cast the sender as a UserLogin object 
            UserLogin login = sender as UserLogin;

            // check to see if it authenticated, exit application if it did not
            if (login.IsAuthenticated == true)
            {

                // initialize the session and set the culture
                this.Session = new UserSession();
                this.Session.CurrentCulture = this.CurrentCulture;

                // set the session properties returned from the login form
                this.Session.IsAuthenticated = login.IsAuthenticated;
                this.Session.UserLoginInfo = login.LoginResponse;
                this.Session.UserLoginTime = DateTime.Now;
                

                // set status bar text
                this.toolStripSessionLabel.Text = $"User: {this.Session.UserLoginInfo.Username} | Login Time: {this.Session.UserLoginTime.ToString()} | Current Time Zone: {this.Session.UserTimeZone.StandardName}";

                // get appointment data and bind to gridviews
                GetWeekAndMonthAppointments();

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
                        v.AllowUserToAddRows = false;
                        v.AllowUserToDeleteRows = false;
                        v.AllowUserToResizeRows = false;
                        v.AllowUserToOrderColumns = false;
                        v.MultiSelect = false;
                        v.RowHeadersVisible = false;
                        v.EditMode = DataGridViewEditMode.EditProgrammatically;
                        v.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        
                        // set DataGridView display options
                        v.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                        v.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        v.EnableHeadersVisualStyles = true;

                        v.Columns["appointmentId"].HeaderText = "ID";
                        v.Columns["appointmentId"].DisplayIndex = 0;
                        
                        v.Columns["customerName"].HeaderText = "Meeting With";
                        v.Columns["customerName"].DisplayIndex = 1;
                                                
                        v.Columns["title"].HeaderText = "Title";
                        v.Columns["title"].DisplayIndex = 2;

                        v.Columns["description"].HeaderText = "Description";
                        v.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        v.Columns["description"].DisplayIndex = 3;

                        v.Columns["location"].HeaderText = "Location";
                        v.Columns["location"].DisplayIndex = 4;

                        v.Columns["contact"].HeaderText = "Contact";
                        v.Columns["contact"].DisplayIndex = 5;

                        v.Columns["type"].HeaderText = "Type";
                        v.Columns["type"].DisplayIndex = 6;

                        v.Columns["url"].HeaderText = "URL";
                        v.Columns["url"].DisplayIndex = 7;

                        v.Columns["start"].HeaderText = "Starts";
                        v.Columns["start"].DisplayIndex = 8;

                        v.Columns["end"].HeaderText = "Ends";
                        v.Columns["end"].DisplayIndex = 9;

                    }
                );

                // set the date range label appropriately
                SetDateRangeLabel();

                // initialize background worker, run the task 
                InitializeBackgroundWorker();
                this.AppointmentChecker.RunWorkerAsync();

                // set up the timer with an interval of one minute, and start it so that the task continues executing
                this.AppointmentCheckerTimer.Tick += new EventHandler(AppointmentChecker_TimerWrapper);
                this.AppointmentCheckerTimer.Interval = 60000;
                this.AppointmentCheckerTimer.Start();

            }
            else
            {
                this.Close();
            }


        }

        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetWeekAndMonthAppointments();

            // refresh the controls
            dataGridWeek.Refresh();
            dataGridMonth.Refresh();
        }

        #endregion

        #region DATA GRID VIEW FORMATTERS 
        private void dataGridWeek_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime CellValue = (DateTime)e.Value;
                e.Value = this.Session.ConvertDateTimeFromUtc(CellValue);
            }
        }

        private void dataGridMonth_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime CellValue = (DateTime)e.Value;
                e.Value = this.Session.ConvertDateTimeFromUtc(CellValue);
            }
        }


        #endregion

        #region PRIVATE METHODS

        private void CancelAndDisposeBackgroundWorker()
        {
            // cancel any async tasks that are occurring and close the form
            try
            {
                this.AppointmentChecker.CancelAsync();
            }
            catch
            {
                // swallow the background worker exception
            }
            finally
            {
                // dispose of the background worker
                this.AppointmentChecker.Dispose();
            }
        }

        private void GetWeekAndMonthAppointments()
        {
            // get the ranges for this week and this month
            this.WeekFilterDates = Session.GetThisWeek(DateTime.Now);
            this.MonthFilterDates = Session.GetThisMonth(DateTime.Now);

            DateTime WeekFilterStart = Session.ConvertDateTimeToUtc(WeekFilterDates["WeekStart"]);
            DateTime WeekFilterEnd = Session.ConvertDateTimeToUtc(WeekFilterDates["WeekEnd"]);
            DateTime MonthFilterStart = Session.ConvertDateTimeToUtc(MonthFilterDates["MonthStart"]);
            DateTime MonthFilterEnd = Session.ConvertDateTimeToUtc(MonthFilterDates["MonthEnd"]);

            this.WeekAppointments = DataProc.GetAppointmentsForUserWithDate(this.Session.UserLoginInfo.UserId, WeekFilterStart, WeekFilterEnd);
            this.MonthAppointments = DataProc.GetAppointmentsForUserWithDate(this.Session.UserLoginInfo.UserId, MonthFilterStart, MonthFilterEnd);


            // set data binding on gridviews
            this.WeekViewSource.DataSource = this.WeekAppointments;
            dataGridWeek.DataSource = this.WeekViewSource;

            this.MonthViewSource.DataSource = this.MonthAppointments;
            dataGridMonth.DataSource = this.MonthViewSource;
        }

        private void SetDateRangeLabel()
        {
            // set the date range label appropriately
            if (tabControlAppts.SelectedTab == tabThisWeek)
            {
                lbl_DateRange.Text = $"Displaying dates: {this.WeekFilterDates["WeekStart"].ToShortDateString()} to {this.WeekFilterDates["WeekEnd"].ToShortDateString()}";
            }
            else
            {
                lbl_DateRange.Text = $"Displaying dates: {this.MonthFilterDates["MonthStart"].ToShortDateString()} to {this.MonthFilterDates["MonthEnd"].ToShortDateString()}";
            }

        }

        #endregion

        
    }
}
