using ScheduleBoss.Classes;
using ScheduleBoss.Enums;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScheduleBoss.Forms
{
    public partial class ModifyCustomer : Form
    {

        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set; }

        public UserSession Session { get; set; }

        public DataProcessor DataProc { get; set; }

        public DataTable Cities { get; set; }

        public DataTable Countries { get; set; }

        public Customer Customer { get; set; }

        public CustomerAddress Address { get; set; }
        
        public ModifyCustomer(DatabaseConnection db, EventLogger log, UserSession sess, Customer cust, CustomerAddress addr)
        {
            InitializeComponent();

            // set properties for database connection, logger, and session 
            this.Database = db;
            this.Logger = log;
            this.Session = sess;
            this.Customer = cust;
            this.Address = addr;

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

            // set field values from loaded objects
            tbox_CustomerId.Text = this.Customer.customerId.ToString();
            mbox_CustomerName.Text = this.Customer.customerName;
            chk_IsActive.Checked = (this.Customer.active == true) ? true : false;
            mbox_CustomerAddress.Text = this.Address.address;
            mbox_CustomerAddress2.Text = this.Address.address2;
            mbox_CustomerPhone.Text = this.Address.phone;
            mbox_CustomerPostalCode.Text = this.Address.postalCode;
            cbox_City.SelectedValue = this.Address.cityId;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // initialize a new customer object and address object
            Customer ModCust = new Customer();
            CustomerAddress ModAddr = new CustomerAddress();

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
                    throw new ArgumentOutOfRangeException($"{mbox_CustomerPhone.Tag.ToString()}", $"Input in the {mbox_CustomerPhone.Tag.ToString()} field contains invalid characters or is incomplete. Only numbers are allowed.");
                }

                // validate the phone and postal code fields
                if (PostalValidator.IsMatch(mbox_CustomerPostalCode.Text))
                {
                    throw new ArgumentOutOfRangeException($"{mbox_CustomerPostalCode.Tag.ToString()}", $"Input in the {mbox_CustomerPostalCode.Tag.ToString()} field contains invalid characters or is incomplete. Only numbers are allowed.");
                }


                // process the address object

                // get next ID value for address table
                ModAddr.addressId = this.Address.addressId;
                

                // process address lines 1 and 2
                ModAddr.address = mbox_CustomerAddress.Text;
                ModAddr.address2 = (mbox_CustomerAddress2.Text.Length > 0) ? mbox_CustomerAddress2.Text : String.Empty;

                // get the selected city from the combo box
                ModAddr.cityId = int.Parse(cbox_City.SelectedValue.ToString());

                // get the phone and postal code - masked fields
                ModAddr.phone = mbox_CustomerPhone.Text;
                ModAddr.postalCode = mbox_CustomerPostalCode.Text;

                // set the user and timestamp fields for create and update - this is a new record
                // datetime values are UTC 
                ModAddr.lastUpdateBy = this.Session.UserLoginInfo.Username;
                ModAddr.lastUpdate = DateTime.UtcNow;

                // insert the data - possbily make this async/awaitable
                bool AddressInsert = this.DataProc.UpdateData(ModAddr, DatabaseEntries.Address);

                if (AddressInsert == false)
                {
                    //throw exception here
                }

                // log the operation
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Address record updated with AddressId:{ModAddr.addressId.ToString()}");

                // process the customer object

                // get customerId value from text field (generated on form load)
                ModCust.customerId = this.Customer.customerId;
                
                // get entered name 
                ModCust.customerName = mbox_CustomerName.Text;

                // handle the checkbox for isActive
                ModCust.active = chk_IsActive.Checked ? true : false;
                
                // assign the addressId of the new address
                ModCust.addressId = ModAddr.addressId;

                // set the user and timestamp fields for create and update - this is a new record
                // datetime values are UTC 
                ModCust.lastUpdateBy = this.Session.UserLoginInfo.Username;
                ModCust.lastUpdate = DateTime.UtcNow;

                // insert the data 
                bool CustUpdate = this.DataProc.UpdateData(ModCust, DatabaseEntries.Customer);

                // log the operation
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [INFO] Customer record updated with CustomerId:{ModCust.customerId.ToString()}");


                this.Close();

            }

            catch (ArgumentOutOfRangeException argEx)
            {
                MessageBox.Show($"{argEx.Message}", "Invalid Entry!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Logger.WriteLog($"{DateTime.Now.ToString()} [ERROR] Input error: {argEx.Message}");
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
