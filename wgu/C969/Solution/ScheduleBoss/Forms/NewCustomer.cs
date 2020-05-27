using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ScheduleBoss.Classes;
using ScheduleBoss.Enums;

namespace ScheduleBoss.Forms
{
    public partial class NewCustomer : Form
    {

        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set; }

        public UserSession Session { get; set; }

        public DataProcessor DataProc { get; set; }

        public DataTable Cities { get; set; }

        public DataTable Countries { get; set; }

        

        public NewCustomer(DatabaseConnection db, EventLogger log, UserSession sess)
        {
            InitializeComponent();

            // set properties for database connection, logger, and session 
            this.Database = db;
            this.Logger = log;
            this.Session = sess;

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
            // initialize a new customer object and address object
            Customer NewCust = new Customer();
            CustomerAddress NewAddr = new CustomerAddress();

            // set up data validation regexes
            Regex AddressValidator = new Regex("[^a-zA-Z0-9\\-\\s]");
            Regex NameValidator = new Regex("[^a-zA-Z\\s\\-]");
            


            try
            {

                //  validate customer name and address text fields
                // validate address fields
                if (AddressValidator.IsMatch(mbox_CustomerAddress.Text))
                {
                    throw new ArgumentOutOfRangeException("Customer Address", "Input contains invalid characters. Alphanumerics, hyphens, and spaces are allowed.");
                }

                if (AddressValidator.IsMatch(mbox_CustomerAddress2.Text))
                {
                    throw new ArgumentOutOfRangeException("Address Line 2", "Input contains invalid characters. Alphanumerics, hyphens, and spaces are allowed.");
                }

                if (NameValidator.IsMatch(mbox_CustomerName.Text))
                {
                    throw new ArgumentOutOfRangeException("Customer Name", "Input contains invalid characters. Letters, hyphens, and spaces are allowed.");
                }


                // process the address object

                // get next ID value for address table
                NewAddr.AddressId = this.DataProc.GetNextId(DatabaseEntries.Address);
                
                // process address lines 1 and 2
                NewAddr.Address = mbox_CustomerAddress.Text;
                NewAddr.Address2 = (mbox_CustomerAddress2.Text.Length > 0) ? mbox_CustomerAddress2.Text : String.Empty;

                // get the selected city from the combo box
                NewAddr.CityId = int.Parse(cbox_City.SelectedValue.ToString());

                // get the phone and postal code - masked fields
                NewAddr.Phone = mbox_CustomerPhone.Text;
                NewAddr.PostalCode = mbox_CustomerPostalCode.Text;

                // set the user and timestamp fields for create and update - this is a new record
                // datetime values are UTC 
                NewAddr.CreatedBy = NewAddr.UpdatedBy = this.Session.UserLoginInfo.Username;
                NewAddr.CreateDate = NewAddr.UpdateDate = DateTime.UtcNow;

                // insert the data - possbily make this async/awaitable
                bool AddressInsert = this.DataProc.InsertData(NewAddr, DatabaseEntries.Address);

                if (AddressInsert == false)
                {
                    //throw exception here
                }

                // process the customer object
                
                // get customerId value from text field (generated on form load)
                NewCust.CustomerId = int.Parse(tbox_CustomerId.Text);
                
                // get entered name 
                NewCust.CustomerName = mbox_CustomerName.Text;

                // handle the checkbox for isActive
                NewCust.IsActive = chk_IsActive.Checked ? 1 : 0;
                
                // assign the addressId of the new address
                NewCust.AddressId = NewAddr.AddressId;

                // set the user and timestamp fields for create and update - this is a new record
                // datetime values are UTC 
                NewCust.CreatedBy = NewCust.UpdatedBy = this.Session.UserLoginInfo.Username;
                NewCust.CreateDate = NewCust.UpdateDate = DateTime.UtcNow;

                // insert the data 
                bool CustInsert = this.DataProc.InsertData(NewCust, DatabaseEntries.Customer);

                this.Close();

            }

            catch (ArgumentOutOfRangeException argEx)
            {
                MessageBox.Show($"{argEx.Message}", $"{argEx.ParamName} - Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Input error - Parameter: {argEx.ParamName} Message: {argEx.Message}");
            }

            catch
            {

            }

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
