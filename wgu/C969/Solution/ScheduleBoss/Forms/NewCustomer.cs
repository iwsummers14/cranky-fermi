using ScheduleBoss.Classes;
using ScheduleBoss.Enums;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            this.DataProc = new DataProcessor(this.Database, this.Logger);

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
            Regex PhoneValidator = new Regex("[^0-9\\-]");
            Regex PostalValidator = new Regex("[^0-9]");
            
            try
            {
                // validate the fields are not empty
                foreach (TextBox tb in this.custPanel.Controls.OfType<TextBox>())
                {
                    if (tb.Text.Length == 0)
                    {
                        throw new ArgumentOutOfRangeException($"{tb.Tag.ToString()}", $"All fields must contain an entry. Please enter data in the {tb.Tag.ToString()} field.");
                    }
                }
                foreach (MaskedTextBox mtb in this.custPanel.Controls.OfType<MaskedTextBox>())
                {
                    if (mtb.Name == mbox_CustomerAddress2.Name)
                    {
                        continue;
                    }

                    if (mtb.Text.Length == 0)
                    {
                        throw new ArgumentOutOfRangeException($"{mtb.Tag.ToString()}", $"All fields must contain an entry. Please enter data in the {mtb.Tag.ToString()} field.");
                    }
                }

                //  validate customer name and address text fields
                if (NameValidator.IsMatch(mbox_CustomerName.Text))
                {
                    throw new ArgumentOutOfRangeException($"{mbox_CustomerName.Tag.ToString()}", $"Input in the {mbox_CustomerName.Tag.ToString()} field contains invalid characters. Letters, hyphens, and spaces are allowed.");
                }

                if (AddressValidator.IsMatch(mbox_CustomerAddress.Text))
                {
                    throw new ArgumentOutOfRangeException($"{mbox_CustomerAddress.Tag.ToString()}", $"Input in the {mbox_CustomerAddress.Tag.ToString()} field contains invalid characters. Alphanumerics, hyphens, and spaces are allowed.");
                }

                if (AddressValidator.IsMatch(mbox_CustomerAddress2.Text))
                {
                    throw new ArgumentOutOfRangeException($"{mbox_CustomerAddress2.Tag.ToString()}", $"Input in the {mbox_CustomerAddress2.Tag.ToString()} field contains invalid characters. Alphanumerics, hyphens, and spaces are allowed.");
                }
                

                if (PhoneValidator.IsMatch(mbox_CustomerPhone.Text))
                {
                    throw new ArgumentOutOfRangeException($"{mbox_CustomerPhone.Tag.ToString()}",$"Input in the {mbox_CustomerPhone.Tag.ToString()} field contains invalid characters or is incomplete. Only numbers are allowed.");
                }

                // validate the phone and postal code fields
                if (PostalValidator.IsMatch(mbox_CustomerPostalCode.Text))
                {
                    throw new ArgumentOutOfRangeException($"{mbox_CustomerPostalCode.Tag.ToString()}", $"Input in the {mbox_CustomerPostalCode.Tag.ToString()} field contains invalid characters or is incomplete. Only numbers are allowed.");
                }


                // process the address object

                // get next ID value for address table
                NewAddr.addressId = this.DataProc.GetNextId(DatabaseEntries.Address);
                
                // process address lines 1 and 2
                NewAddr.address = mbox_CustomerAddress.Text;
                NewAddr.address2 = (mbox_CustomerAddress2.Text.Length > 0) ? mbox_CustomerAddress2.Text : String.Empty;

                // get the selected city from the combo box
                NewAddr.cityId = int.Parse(cbox_City.SelectedValue.ToString());

                // get the phone and postal code - masked fields
                NewAddr.phone = mbox_CustomerPhone.Text;
                NewAddr.postalCode = mbox_CustomerPostalCode.Text;

                // set the user and timestamp fields for create and update - this is a new record
                // datetime values are UTC 
                NewAddr.createdBy = NewAddr.lastUpdateBy = this.Session.UserLoginInfo.Username;
                NewAddr.createDate = NewAddr.lastUpdate = DateTime.UtcNow;

                // insert the data - possbily make this async/awaitable
                bool AddressInsert = this.DataProc.InsertData(NewAddr, DatabaseEntries.Address);

                if (AddressInsert == false)
                {
                    throw new Exception("Error during INSERT operation on 'address' table. The SQL transaction has been rolled back.");
                }

                // log the operation
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Address record inserted with AddressId:{NewAddr.addressId.ToString()}");

                // process the customer object

                // get customerId value from text field (generated on form load)
                NewCust.customerId = int.Parse(tbox_CustomerId.Text);
                
                // get entered name 
                NewCust.customerName = mbox_CustomerName.Text;

                // handle the checkbox for isActive
                NewCust.active = chk_IsActive.Checked ? true : false;
                
                // assign the addressId of the new address
                NewCust.addressId = NewAddr.addressId;

                // set the user and timestamp fields for create and update - this is a new record
                // datetime values are UTC 
                NewCust.createdBy = NewCust.lastUpdateBy = this.Session.UserLoginInfo.Username;
                NewCust.createDate = NewCust.lastUpdate = DateTime.UtcNow;

                // insert the data 
                bool CustInsert = this.DataProc.InsertData(NewCust, DatabaseEntries.Customer);

                if (AddressInsert == false)
                {
                    // throw exception if operation failed
                    throw new Exception("Error during INSERT operation on 'customer' table. The SQL transaction has been rolled back.");
                }

                // log the operation
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Customer record inserted with CustomerId:{NewCust.customerId.ToString()}");


                this.Close();

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
                MessageBox.Show($"An error has occurred while creating a new customer record. Please consult the log for more information.", "Insert error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Operation error: {ex.Message}");
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
