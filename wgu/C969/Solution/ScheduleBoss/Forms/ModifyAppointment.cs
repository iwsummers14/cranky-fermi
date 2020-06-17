using ScheduleBoss.Classes;
using ScheduleBoss.Enums;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace ScheduleBoss.Forms
{
    public partial class ModifyAppointment : Form
    {
        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set; }

        public UserSession Session { get; set; }

        public DataProcessor DataProc { get; set; }

        public DataTable Consultants { get; set; }

        public DataTable Customers { get; set; }

        public Appointment Appointment { get; set; }
        
        public ModifyAppointment(DatabaseConnection dbConn, EventLogger log, UserSession sess, Appointment appt)
        {
            InitializeComponent();

            // set properties
            this.Database = dbConn;
            this.Logger = log;
            this.Session = sess;
            this.Appointment = appt;

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

            // set field values from loaded objects - converting times from UTC to local time zone
            mbox_ApptTitle.Text = this.Appointment.title;
            cbox_Consultant.SelectedValue = this.Appointment.userId;
            cbox_Customer.SelectedValue = this.Appointment.customerId;
            dtp_StartDate.Value = this.Appointment.start.Date;
            dtp_StartTime.Value = this.Session.ConvertDateTimeFromUtc(DateTime.Parse(this.Appointment.start.ToString()));
            dtp_EndDate.Value = this.Appointment.end.Date;
            dtp_EndTime.Value = this.Session.ConvertDateTimeFromUtc(DateTime.Parse(this.Appointment.end.ToString()));
            mbox_ApptContact.Text = this.Appointment.contact;
            mbox_ApptType.Text = this.Appointment.type;
            mbox_ApptLocation.Text = this.Appointment.location;
            mbox_Url.Text = this.Appointment.url;
            tbox_ApptDescription.Text = this.Appointment.description;

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // initialize a new appointment object
            Appointment ModAppt = new Appointment();

            //set up data validation regexes
            Regex TextValidator = new Regex("[^a-zA-Z0-9\\-\\,\\.\\;\\'\\/\\(\\)\\s]");
            Regex UrlValidator = new Regex("^(http:\\/\\/|https:\\/\\/)");

            try {

                // validate the text fields are not empty, and evaluate them against the regex validators.  Using a lambda here
                // and LINQ selecting by type to avoid repetitive statements against each field.
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

                // validate the times to ensure start does not come after end
                if (dtp_StartTime.Value.TimeOfDay > dtp_EndTime.Value.TimeOfDay)
                {
                    throw new ArgumentOutOfRangeException($"{dtp_StartTime.Tag.ToString()}", $"{dtp_StartTime.Tag.ToString()} cannot be after {dtp_EndTime.Tag.ToString()}.");
                }
                
                // validate the datetime to ensure start is not in the past
                if ((dtp_StartDate.Value.Date + dtp_StartTime.Value.TimeOfDay) < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException($"{dtp_StartTime.Tag.ToString()}", $"{dtp_StartTime.Tag.ToString()} cannot be in the past.");
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

                // construct a DateTime with the start and end time & date to validate them, and convert to UTC
                DateTime Start = Session.ConvertDateTimeToUtc(dtp_StartDate.Value.Date + dtp_StartTime.Value.TimeOfDay);
                DateTime End = Session.ConvertDateTimeToUtc(dtp_EndDate.Value.Date + dtp_EndTime.Value.TimeOfDay);

                //validate that there is not a conflict with another appointment
                bool ConflictDetected = this.DataProc.ValidateAppointmentTimesForUser(Session.UserLoginInfo.UserId, Start, End, this.Appointment.appointmentId);

                if (ConflictDetected)
                {
                    throw new ApplicationException("A conflict with another appointment was detected. Please review Start and End times and dates and ensure they do not overlap with another appointment.");
                }

                // process the Appointment object

                // assign the ID value
                ModAppt.appointmentId = this.Appointment.appointmentId;

                // set customer and userId values from combo boxes
                ModAppt.customerId = int.Parse(cbox_Customer.SelectedValue.ToString());
                ModAppt.userId = int.Parse(cbox_Consultant.SelectedValue.ToString());

                // set text values based on text box entries - title, description, location, contaact, type, url
                ModAppt.title = mbox_ApptTitle.Text;
                ModAppt.description = tbox_ApptDescription.Text;
                ModAppt.location = mbox_ApptLocation.Text;
                ModAppt.contact = mbox_ApptContact.Text;
                ModAppt.type = mbox_ApptType.Text;
                ModAppt.url = mbox_Url.Text;

                // set start and end date time properties 
                ModAppt.start = Start;
                ModAppt.end = End;

                // set updated by, and update date fields
                ModAppt.lastUpdateBy = Session.UserLoginInfo.Username;
                ModAppt.lastUpdate = DateTime.UtcNow;

                // insert the data - possbily make this async/awaitable
                bool ApptUpdate = this.DataProc.UpdateData(ModAppt, DatabaseEntries.Appointment);

                if (ApptUpdate == false)
                {
                    throw new Exception("Error during UPDATE operation. The SQL transaction has been rolled back.");
                }

                // log the operation and close the form
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Appointment record inserted with AppointmentId:{ModAppt.appointmentId.ToString()}");

                this.Close();
                
            }

            // process argument exception
            catch (ApplicationException appEx)
            {
                MessageBox.Show($"{appEx.Message}", "Conflict detected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Schedule conflict detected: {appEx.Message}");
            }

            // process argument out of range exception
            catch (ArgumentOutOfRangeException argEx)
            {
                MessageBox.Show($"{argEx.Message}", "Invalid Entry!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Input error: {argEx.Message}");
            }

            // process general exception
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occurred while creating your appointment. Please consult the log for more information.", "Insert error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Operation error: {ex.Message}");
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // request user confirmation before deleting the record
            DialogResult DeleteConfirmation = MessageBox.Show($"Are you sure you wish to delete this appointment?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DeleteConfirmation == DialogResult.Yes)
            {
                // delete the address and customer records
                bool apptDeleted = this.DataProc.DeleteRecord(this.Appointment.appointmentId, DatabaseEntries.Appointment);

                // show confirmation if everything was successful and log it, otherwise direct the user to the logs if an error occurred.  
                if (apptDeleted == true )
                {
                    MessageBox.Show($"Appointment {this.Appointment.title} has been deleted from the system.", "Appointment deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Deleted appointment record {this.Appointment.appointmentId}");

                }
                else
                {
                    MessageBox.Show($"Appointment {this.Appointment.title} was not fully deleted from the system. Please review the logs for more information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.Close();
            }
            else
            {
                // do nothing if confirmation was not given
                return;
            }

        }

        private void dtp_StartDate_ValueChanged(object sender, EventArgs e)
        {
            // make the two date fields match
            dtp_EndDate.Value = dtp_StartDate.Value;
        }

        private void dtp_EndDate_ValueChanged(object sender, EventArgs e)
        {
            // make the two date fields match
            dtp_StartDate.Value = dtp_EndDate.Value;
        }
    }

}
