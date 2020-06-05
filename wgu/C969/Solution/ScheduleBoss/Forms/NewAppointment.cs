using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleBoss.Classes;
using ScheduleBoss.Enums;


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


        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
