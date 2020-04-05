using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterOfParts.Forms
{
    public partial class fPartAdd : Form
    {

        public fPartAdd()
        {
            InitializeComponent();
        }

        private void AddPartCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void isInHouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (isInHouseRadio.Checked == true)
            {
                isOutsourcedRadio.Checked = false;
                PartTypeLabel.Text = "MachineId";
            }
            
        }

        private void isOutsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (isOutsourcedRadio.Checked == true)
            {
                isInHouseRadio.Checked = false;
                PartTypeLabel.Text = "Company Name";
                
            }
        }

        private void AddPartSave_Click(object sender, EventArgs e)
        {
            
            if (isInHouseRadio.Checked == true)
            {
                // declare new inhouse part object
                Inhouse tmpPart = new Inhouse();

                try
                {
                    // parse numeric fields and set object properties
                    tmpPart.PartID = int.Parse(PartId.Text);
                    tmpPart.MachineId = int.Parse(PartSupplement.Text);
                    tmpPart.InStock = int.Parse(PartInventory.Text);
                    tmpPart.Max = int.Parse(PartMax.Text);
                    tmpPart.Min = int.Parse(PartMin.Text);
                    tmpPart.Price = decimal.Parse(PartCost.Text);

                    // add string properties to object
                    tmpPart.Name = PartName.Text;

                    if (tmpPart.InStock <= tmpPart.Max && tmpPart.InStock >= tmpPart.Min)
                    {
                        // add the part to the Inventory
                        Inventory.addPart(tmpPart);

                        //close the form 
                        this.Close();
                    }

                    else
                    {
                        if (tmpPart.InStock > tmpPart.Max)
                        {
                            MessageBox.Show("The value of Inventory must not exceed the value of Max", "Input out of range!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorProviderInventory.SetError(PartInventory, "The value of Inventory must not exceed the value of Max");
                        }
                        if (tmpPart.InStock < tmpPart.Min)
                        {
                            MessageBox.Show("The value of Inventory must not be less than the value of Min", "Input out of range!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorProviderInventory.SetError(PartInventory, "The value of Inventory must not be less than the value of Min");
                        }
                    }
                    

                }
                catch (FormatException fException)
                {
                    MessageBox.Show($"Error message: {fException.Message}", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            else
            {
                // declare new inhouse part object
                Outsourced tmpPart = new Outsourced();

                try
                {
                    // parse numeric fields and set object properties
                    tmpPart.PartID = int.Parse(PartId.Text);
                    tmpPart.InStock = int.Parse(PartInventory.Text);
                    tmpPart.Max = int.Parse(PartMax.Text);
                    tmpPart.Min = int.Parse(PartMin.Text);
                    tmpPart.Price = decimal.Parse(PartCost.Text);

                    // add string properties to object
                    tmpPart.CompanyName = PartSupplement.Text;
                    tmpPart.Name = PartName.Text;

                    if (tmpPart.InStock <= tmpPart.Max && tmpPart.InStock >= tmpPart.Min)
                    {
                        // add the part to the Inventory
                        Inventory.addPart(tmpPart);

                        //close the form 
                        this.Close();
                    }

                    else
                    {
                        if (tmpPart.InStock > tmpPart.Max)
                        {
                            MessageBox.Show("The value of Inventory must not exceed the value of Max", "Input out of range!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorProviderInventory.SetError(PartInventory, "The value of Inventory must not exceed the value of Max");
                        }
                        if (tmpPart.InStock < tmpPart.Min)
                        {
                            MessageBox.Show("The value of Inventory must not be less than the value of Min", "Input out of range!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorProviderInventory.SetError(PartInventory, "The value of Inventory must not be less than the value of Min");
                        }

                    }

                }
                catch (FormatException fException)
                {
                    MessageBox.Show($"Error message: {fException.Message}", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                                
            }
            
        }


        private void fPartAdd_Load(object sender, EventArgs e)
        {
            // generate new part ID
            int newPartId = new int();

            if (Inventory.AllParts.Count == 0)
            {
                newPartId = 1;
            }
            else
            {
                newPartId = (Inventory.AllParts.Count + 1);
            }

            PartId.Text = newPartId.ToString();

        }

        private void PartInventory_Validating(object sender, CancelEventArgs e)
        {
            // attempt to parse the value as the targeted datatype
            try
            {
                _ = int.Parse(PartInventory.Text);
                errorProviderInventory.Clear();
            }
            catch (FormatException)
            {

                errorProviderInventory.SetError(PartInventory, "Input must be digits and cannot contain letters or special characters.");
            }
            
        }

        private void PartName_Validating(object sender, CancelEventArgs e)
        {
            // ensure the name text is not null or empty
            if (string.IsNullOrEmpty(PartName.Text))
            {
                errorProviderName.SetError(PartName, "The part name must not be null or empty.");
                e.Cancel = true;
            }
            else
            {
                errorProviderName.Clear();
            }

        }

        private void PartCost_Validating(object sender, CancelEventArgs e)
        {
            // attempt to parse the value as the targeted datatype
            try
            {
                _ = decimal.Parse(PartCost.Text);
                errorProviderCost.Clear();
            }
            catch (FormatException)
            {
                // fire the error provider and cancel validation
                errorProviderCost.SetError(PartCost, "Input must be an integer or decimal value. Examples: '1', '1.99'.");
                e.Cancel = true;
            }

        }

        private void PartMax_Validating(object sender, CancelEventArgs e)
        {
            // attempt to parse the value as the targeted datatype
            try
            {
                _ = int.Parse(PartMax.Text);
                errorProviderMax.Clear();
                
            }
            catch (FormatException)
            {
                // fire the error provider and cancel validation
                errorProviderMax.SetError(PartMax, "Input must be an integer value, no letters or special characters.");
                e.Cancel = true;
            }
        }

        private void PartMin_Validating(object sender, CancelEventArgs e)
        {
            // attempt to parse the value as the targeted datatype
            try
            {
                _ = int.Parse(PartMin.Text);
                errorProviderMin.Clear();

            }
            catch (FormatException)
            {
                // fire the error provider and cancel validation
                errorProviderMin.SetError(PartMin, "Input must be an integer value, no letters or special characters.");
                e.Cancel = true;
            }
        }

        private void PartSupplement_Validating(object sender, CancelEventArgs e)
        {
            if (isOutsourcedRadio.Checked == true)
            {
                // ensure the company name is not null or empty
                if (string.IsNullOrEmpty(PartName.Text))
                {
                    // fire the error provider and cancel validation
                    errorProviderSupplement.SetError(PartSupplement, "The Company Name must not be null or empty.");
                    e.Cancel = true;
                }
                else
                {
                    errorProviderSupplement.Clear();
                }
            }
            else
            {
                // attempt to parse the value as the targeted datatype
                try
                {
                    _ = int.Parse(PartSupplement.Text);
                    errorProviderSupplement.Clear();

                }
                catch (FormatException)
                {
                    // fire the error provider and cancel validation
                    errorProviderSupplement.SetError(PartSupplement, "Input must be an integer value, no letters or special characters.");
                    e.Cancel = true;
                }

            }

        }
        
    }

}
