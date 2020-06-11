using ScheduleBoss.Classes;
using ScheduleBoss.Enums;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace ScheduleBoss.Forms
{
    public partial class NewAppointment : Form
    {
        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set; }

        public UserSession Session { get; set; }

        public DataProcessor DataProc { get; set; }

        public DataTable Consultants { get; set; }

        public DataTable Customers { get; set; }
        

        public NewAppointment(DatabaseConnection dbConn, EventLogger log, UserSession sess)
        {
            InitializeComponent();

            // set properties
            this.Database = dbConn;
            this.Logger = log;
            this.Session = sess;

            // initialize the data processor object 
            this.DataProc = new DataProcessor(this.Database, this.Logger);

            // get the data for the city and country fields
            this.Customers = this.DataProc.GetAllTableValues(DatabaseEntries.Customer);
            this.Consultants = this.DataProc.GetAllTableValues(DatabaseEntries.User);

            // bind data to combo boxes
            cbox_Consultant.DataSource = this.Consultants.DefaultView;
            cbox_Consultant.DisplayMember = "userName";
            cbox_Consultant.ValueMember = "userId";

            cbox_Customer.DataSource = this.Customers.DefaultView;
            cbox_Customer.DisplayMember = "customerName";
            cbox_Customer.ValueMember = "customerId";

            // set properties on date pickers
            dtp_StartDate.MinDate = DateTime.Today;
            dtp_EndDate.MinDate = DateTime.Today;

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // initialize a new appointment object
            Appointment NewAppt = new Appointment();

            //set up data validation regexes
            Regex TextValidator = new Regex("[^a-zA-Z0-9\\-\\,\\.\\;\\'\\/\\(\\)\\s]");
            Regex UrlValidator = new Regex("^(http:\\/\\/|https:\\/\\/)");

            try {

                // validate the text fields are not empty, and evaluate them against the regex validators
                this.apptPanel.Controls.OfType<TextBox>().ToList().ForEach(
                    tb =>
                        {
                            if (tb.Text.Length == 0)
                            {
                                throw new ArgumentOutOfRangeException($"{tb.Tag.ToString()}", $"All fields must contain an entry. Please enter data in the {tb.Tag.ToString()} field.");
                            }

                            if (TextValidator.IsMatch(tb.Text))
                            {
                                throw new ArgumentOutOfRangeException($"{tb.Tag.ToString()}", $"Input in the {tb.Tag.ToString()} field contains invalid characters. Letters, numbers, commas, periods, parentheses, semicolons, single quotes, and forward slashes are allowed.");
                            }
                        }
                );
                this.apptPanel.Controls.OfType<MaskedTextBox>().ToList().ForEach(
                    mtb =>
                        {
                            if (mtb.Name == mbox_Url.Name)
                            {
                                if (UrlValidator.IsMatch(mtb.Text) == false)
                                {
                                    throw new ArgumentOutOfRangeException($"{mtb.Tag.ToString()}", $"Input in the {mtb.Tag.ToString()} field must start with http:// or https://.");
                                }
                            }

                            else
                            {
                                if (mtb.Text.Length == 0)
                                {
                                    throw new ArgumentOutOfRangeException($"{mtb.Tag.ToString()}", $"All fields must contain an entry. Please enter data in the {mtb.Tag.ToString()} field.");
                                }
                                if (TextValidator.IsMatch(mtb.Text))
                                {
                                    throw new ArgumentOutOfRangeException($"{mtb.Tag.ToString()}", $"Input in the {mtb.Tag.ToString()} field contains invalid characters. Letters, numbers, commas, periods, parentheses, semicolons, single quotes, and forward slashes are allowed.");
                                }
                            }
                        }
                );

                // validate the dates for start and end time
                if (dtp_StartTime.Value.TimeOfDay > this.Session.WorkDayEnd || dtp_StartTime.Value.TimeOfDay < this.Session.WorkDayStart)
                {
                    throw new ArgumentOutOfRangeException($"{dtp_StartTime.Tag.ToString()}", $"Appointment {dtp_StartTime.Tag.ToString()} is outside of normal business hours. Normal business hours are {Session.WorkDayStart.ToString()} to {Session.WorkDayEnd.ToString()}.");
                }
                if (dtp_EndTime.Value.TimeOfDay > this.Session.WorkDayEnd || dtp_EndTime.Value.TimeOfDay < this.Session.WorkDayStart)
                {
                    throw new ArgumentOutOfRangeException($"{dtp_EndTime.Tag.ToString()}", $"Appointment {dtp_EndTime.Tag.ToString()} time is outside of normal business hours. Normal business hours are {Session.WorkDayStart.ToString()} to {Session.WorkDayEnd.ToString()}.");
                }

                // validate that the dates for the appointment fall during a workday
                if (Session.WorkDays.Contains(dtp_StartDate.Value.DayOfWeek.ToString()) == false) 
                {
                    throw new ArgumentOutOfRangeException($"{dtp_StartDate.Tag.ToString()}", $"Appointment {dtp_StartDate.Tag.ToString()} day is outside of normal work days. Normal work days are Monday-Friday.");
                }
                if (Session.WorkDays.Contains(dtp_EndDate.Value.DayOfWeek.ToString()) == false)
                {
                    throw new ArgumentOutOfRangeException($"{dtp_EndDate.Tag.ToString()}", $"Appointment {dtp_EndDate.Tag.ToString()} day is outside of normal work days. Normal work days are Monday-Friday.");
                }

                // process the Appointment object
                
                // get next ID value
                NewAppt.appointmentId = this.DataProc.GetNextId(DatabaseEntries.Appointment);

                // set customer and userId values from combo boxes
                NewAppt.customerId = int.Parse(cbox_Customer.SelectedValue.ToString());
                NewAppt.userId = int.Parse(cbox_Consultant.SelectedValue.ToString());

                // set text values based on text box entries - title, description, location, contaact, type, url
                NewAppt.title = mbox_ApptTitle.Text;
                NewAppt.description = tbox_ApptDescription.Text;
                NewAppt.location = mbox_ApptLocation.Text;
                NewAppt.contact = mbox_ApptContact.Text;
                NewAppt.type = mbox_ApptType.Text;
                NewAppt.url = mbox_Url.Text;

                // set start and end date time objects and convert to utc
                DateTime Start = dtp_StartDate.Value.Date + dtp_StartTime.Value.TimeOfDay;
                DateTime End = dtp_EndDate.Value.Date + dtp_EndTime.Value.TimeOfDay;

                NewAppt.start = Session.ConvertDateTimeToUtc(Start);
                NewAppt.end = Session.ConvertDateTimeToUtc(End);

                // set created by, create date, updated by, and update date fields (equal since this is a new record)
                NewAppt.createdBy = NewAppt.lastUpdateBy = Session.UserLoginInfo.Username;
                NewAppt.createDate = NewAppt.lastUpdate = DateTime.UtcNow;

                // insert the data - possbily make this async/awaitable
                bool ApptInsert = this.DataProc.InsertData(NewAppt, DatabaseEntries.Appointment);

                if (ApptInsert == false)
                {
                    //throw exception here
                }

                // log the operation and close the form
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Appointment record inserted with AppointmentId:{NewAppt.appointmentId.ToString()}");

                this.Close();
                
            }

            catch (ArgumentOutOfRangeException argEx)
            {
                MessageBox.Show($"{argEx.Message}", "Invalid Entry!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Input error: {argEx.Message}");
            }
            

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
