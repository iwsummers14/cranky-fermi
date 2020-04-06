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
    public partial class fPartModify : Form
    {

        public fPartModify(Inhouse partToModify)
        {

            InitializeComponent();

            // load the values from the part object
            isInHouseRadio.Checked = true;
            isOutsourcedRadio.Checked = false;
            PartId.Text = partToModify.PartID.ToString();
            PartName.Text = partToModify.Name;
            PartCost.Text = partToModify.Price.ToString();
            PartInventory.Text = partToModify.InStock.ToString();
            PartMax.Text = partToModify.Max.ToString();
            PartMin.Text = partToModify.Min.ToString();
            PartTypeLabel.Text = "MachineId";
            PartSupplement.Text = partToModify.MachineId.ToString();

        }
        public fPartModify(Outsourced partToModify) {
            
            InitializeComponent();

            // load the values from the part object
            isOutsourcedRadio.Checked = true;
            isInHouseRadio.Checked = false;
            PartId.Text = partToModify.PartID.ToString();
            PartName.Text = partToModify.Name;
            PartCost.Text = partToModify.Price.ToString();
            PartInventory.Text = partToModify.InStock.ToString();
            PartMax.Text = partToModify.Max.ToString();
            PartMin.Text = partToModify.Min.ToString();
            PartTypeLabel.Text = "Company Name";
            PartSupplement.Text = partToModify.CompanyName;
            
        }

        private void ModifyPartCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fPartModify_Load(object sender, EventArgs e)
        {
            
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

        private void ModifyPartSave_Click(object sender, EventArgs e)
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
                        // update the part in the inventory
                        Inventory.updatePart(tmpPart.PartID, tmpPart);

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
                    // show a generic error if a format exception was caught
                    MessageBox.Show($"Expected numeric input in one or more fields. \nSee error indicators on form for more information.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                        // update the part in the inventory
                        Inventory.updatePart(tmpPart.PartID, tmpPart);

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
                    // show a generic error if a format exception was caught
                    MessageBox.Show($"Expected numeric input in one or more fields. \nSee error indicators on form for more information.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void PartName_Validating(object sender, CancelEventArgs e)
        {
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

        private void PartInventory_Validating(object sender, CancelEventArgs e)
        {
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

        private void PartCost_Validating(object sender, CancelEventArgs e)
        {
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
                if (string.IsNullOrEmpty(PartName.Text))
                {
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
