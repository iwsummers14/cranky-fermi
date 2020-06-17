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

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
