using ScheduleBoss.Classes;
using ScheduleBoss.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleBoss.Forms
{
    public partial class ReportViewer : Form
    {
        public DatabaseConnection Database { get; set; }

        public DataProcessor DataProc { get; set; }

        public EventLogger Logger { get; set; }

        public UserSession Session { get; set; }
                

        public ReportViewer(DatabaseConnection dbConn, EventLogger log, UserSession sess)
        {
            InitializeComponent();

            // set database, logger, and session properties
            this.Database = dbConn;
            this.Logger = log;
            this.Session = sess;

            // initialize the data processor object 
            this.DataProc = new DataProcessor(this.Database, this.Logger);
            
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            // bind the ReportType enum values to the combo box 
            cbox_ReportType.DataSource = Enum.GetValues(typeof(ReportTypes));
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            // clear the text box
            tbox_ReportData.Text = "";

            // get value of combo box
            ReportTypes ReportType = (ReportTypes)cbox_ReportType.SelectedItem;

            // create a reportdata list
            List<string> reportData = new List<string>();

            // execute query based on report type and sent results to display method
            switch (ReportType)
            {
                case ReportTypes.ScheduleByConsultant:
                    reportData = this.DataProc.GetScheduleByConsultant();
                    displayReport(reportData);
                    break;

                case ReportTypes.AppointmentsByCustomer:
                    reportData = this.DataProc.GetAppointmentsByCustomer();
                    displayReport(reportData);
                    break;

                case ReportTypes.AppointmentTypesByMonth:
                    
                    reportData = this.DataProc.GetAppointmentTypesByMonth();
                    displayReport(reportData);
                    break;

            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        // method to write lines to the report viewer text box
        private void displayReport(List<string> reportData)
        {
            reportData.ForEach(str =>
                {
                    // write the lines to the report viewer text box
                    tbox_ReportData.AppendText($"{str}");
                    tbox_ReportData.AppendText($"\r\n");
                }
            );
        }
    }
}
