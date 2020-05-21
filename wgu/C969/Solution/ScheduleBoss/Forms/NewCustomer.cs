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
    public partial class NewCustomer : Form
    {

        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set; }

        public DataProcessor DataProc { get; set; }

        public DataTable Cities { get; set; }

        public DataTable Countries { get; set; }

        public NewCustomer(DatabaseConnection db, EventLogger log)
        {
            InitializeComponent();

            // set properties for database connection and logger 
            this.Database = db;
            this.Logger = log;

            // initialize the data processor object 
            this.DataProc = new DataProcessor(this.Database);

            // get the next customer ID and assign it to the text box
            tbox_CustomerId.Text = this.DataProc.GetNextId(DatabaseEntries.Customer).ToString();

            // get the data for the city and country fields
            this.Cities = this.DataProc.GetAllTableValues(DatabaseEntries.City);
            this.Countries = this.DataProc.GetAllTableValues(DatabaseEntries.Country);

            // bind data to combo boxes
            cbox_City.DataSource = this.Cities.DefaultView;
            cbox_City.DisplayMember = "city";
            cbox_City.ValueMember = "cityId";
            
            cbox_Country.DataSource = this.Countries.DefaultView;
            cbox_Country.DisplayMember = "country";
            cbox_Country.ValueMember = "countryId";


        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // initialize a new customer object
            Customer NewCust = new Customer();



            CustomerAddress NewAddr = new CustomerAddress();


            bool AddrValidated = DataProc.ValidateData(DatabaseEntries.Address, NewAddr);
            bool CustValidated = DataProc.ValidateData(DatabaseEntries.Customer, NewCust);
            this.Close();

        }

        private void cbox_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the value for the selection as a string
            string selection = cbox_City.SelectedValue.ToString();
            
            // identify the countryId from the row that matches the selection and use it to filter the country combo box
            DataRow row = this.Cities.Rows.Find(selection);
            int countryId = row.Field<int>("countryId");
            this.Countries.DefaultView.RowFilter = String.Format("countryId = {0}", countryId);
            cbox_Country.Refresh();

            
        }

    }

}
