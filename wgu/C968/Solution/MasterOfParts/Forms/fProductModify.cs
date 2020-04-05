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
    public partial class fProductModify : Form
    {

        public Product modifiedProduct = new Product();

        public fProductModify(Product productToModify)
        {
            InitializeComponent();

            // set binding list options on the associated parts binding list
            modifiedProduct.AssociatedParts.AllowNew = true;
            modifiedProduct.AssociatedParts.AllowEdit = true;
            modifiedProduct.AssociatedParts.AllowRemove = true;

            // load the existing product values into the modified product object property
            ProductId.Text = productToModify.ProductID.ToString();
            ProductName.Text = productToModify.Name;
            ProductCost.Text = productToModify.Price.ToString();
            ProductInventory.Text = productToModify.InStock.ToString();
            ProductMax.Text = productToModify.Max.ToString();
            ProductMin.Text = productToModify.Min.ToString();

            foreach (Part AssociatedPart in productToModify.AssociatedParts)
            {
                modifiedProduct.AssociatedParts.Add(AssociatedPart);
            }
                    
        }

        private void fProductModify_Load(object sender, EventArgs e)
        {
            // define binding data sources
            BindingSource bSourceAllParts = new BindingSource();
            bSourceAllParts.DataSource = Inventory.AllParts;

            BindingSource bSourceAssociatedParts = new BindingSource();
            bSourceAssociatedParts.DataSource = this.modifiedProduct.AssociatedParts;

            // assign data sources to grid views
            GridViewAllParts.DataSource = bSourceAllParts;
            GridViewAssociatedParts.DataSource = bSourceAssociatedParts;

            // set gridview options
            GridViewAllParts.RowHeadersVisible = false;
            GridViewAllParts.AllowUserToAddRows = false;
            GridViewAllParts.AllowUserToDeleteRows = false;
            GridViewAllParts.AllowUserToResizeRows = false;
            GridViewAllParts.AllowUserToOrderColumns = false;
            GridViewAllParts.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridViewAllParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewAllParts.MultiSelect = true;

            GridViewAssociatedParts.RowHeadersVisible = false;
            GridViewAssociatedParts.AllowUserToAddRows = false;
            GridViewAssociatedParts.AllowUserToDeleteRows = false;
            GridViewAssociatedParts.AllowUserToResizeRows = false;
            GridViewAssociatedParts.AllowUserToOrderColumns = false;
            GridViewAssociatedParts.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridViewAssociatedParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewAssociatedParts.MultiSelect = false;


            // set column options on each Part gridview column
            GridViewAllParts.Columns["PartId"].HeaderText = "Part ID";
            GridViewAllParts.Columns["PartId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAllParts.Columns["PartID"].DisplayIndex = 0;

            GridViewAllParts.Columns["Name"].HeaderText = "Name";
            GridViewAllParts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridViewAllParts.Columns["Name"].DisplayIndex = 1;

            GridViewAllParts.Columns["InStock"].HeaderText = "Inventory";
            GridViewAllParts.Columns["InStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAllParts.Columns["InStock"].DisplayIndex = 2;

            GridViewAllParts.Columns["Price"].HeaderText = "Price";
            GridViewAllParts.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAllParts.Columns["Price"].DisplayIndex = 3;

            GridViewAllParts.Columns["Min"].HeaderText = "Min";
            GridViewAllParts.Columns["Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAllParts.Columns["Min"].DisplayIndex = 4;


            GridViewAllParts.Columns["Max"].HeaderText = "Max";
            GridViewAllParts.Columns["Max"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAllParts.Columns["Max"].DisplayIndex = 5;

            // set column options on each Product gridview column
            GridViewAssociatedParts.Columns["PartId"].HeaderText = "Part ID";
            GridViewAssociatedParts.Columns["PartId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAssociatedParts.Columns["PartID"].DisplayIndex = 0;

            GridViewAssociatedParts.Columns["Name"].HeaderText = "Name";
            GridViewAssociatedParts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridViewAssociatedParts.Columns["Name"].DisplayIndex = 1;

            GridViewAssociatedParts.Columns["InStock"].HeaderText = "Inventory";
            GridViewAssociatedParts.Columns["InStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAssociatedParts.Columns["InStock"].DisplayIndex = 2;

            GridViewAssociatedParts.Columns["Price"].HeaderText = "Price";
            GridViewAssociatedParts.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAssociatedParts.Columns["Price"].DisplayIndex = 3;

            GridViewAssociatedParts.Columns["Min"].HeaderText = "Min";
            GridViewAssociatedParts.Columns["Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAssociatedParts.Columns["Min"].DisplayIndex = 4;

            GridViewAssociatedParts.Columns["Max"].HeaderText = "Max";
            GridViewAssociatedParts.Columns["Max"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewAssociatedParts.Columns["Max"].DisplayIndex = 5;
        }

        private void DeletePart_Click(object sender, EventArgs e)
        {
            // delete the underlying object if a row was selected
            if (GridViewAssociatedParts.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow selectedRow in GridViewAssociatedParts.SelectedRows)
                {
                    // get the part for the current row and remove it
                    Part partToRemove = selectedRow.DataBoundItem as Part;
                    bool result = modifiedProduct.removeAssociatedPart(partToRemove.PartID);

                }

            }

            // do nothing if nothing was selected
            else
            {

                return;

            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //close the current form
            this.Close();
        }

        private void SaveProduct_Click(object sender, EventArgs e)
        {

            try
            {
                // parse numeric fields and set object properties
                modifiedProduct.ProductID = int.Parse(ProductId.Text);
                modifiedProduct.InStock = int.Parse(ProductInventory.Text);
                modifiedProduct.Max = int.Parse(ProductMax.Text);
                modifiedProduct.Min = int.Parse(ProductMin.Text);
                modifiedProduct.Price = decimal.Parse(ProductCost.Text);

                // add string properties to object
                modifiedProduct.Name = ProductName.Text;

                // validate that the inventory value is between max and min
                if (modifiedProduct.InStock <= modifiedProduct.Max && modifiedProduct.InStock >= modifiedProduct.Min)
                {
                    // update the part in the inventory
                    Inventory.updateProduct(modifiedProduct.ProductID, modifiedProduct);

                    //close the form 
                    this.Close();
                }

                else
                {
                    // show error if inventory is greater than max value
                    if (modifiedProduct.InStock > modifiedProduct.Max)
                    {
                        MessageBox.Show("The value of Inventory must not exceed the value of Max", "Input out of range!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProviderInventory.SetError(ProductInventory, "The value of Inventory must not exceed the value of Max");
                    }

                    // show error if inventory is less than min value
                    if (modifiedProduct.InStock < modifiedProduct.Min)
                    {
                        MessageBox.Show("The value of Inventory must not be less than the value of Min", "Input out of range!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProviderInventory.SetError(ProductInventory, "The value of Inventory must not be less than the value of Min");
                    }
                }


            }
            catch (FormatException fException)
            {
                // show a generic error if a format exception was caught
                MessageBox.Show($"Error message: {fException.Message}", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddPart_Click(object sender, EventArgs e)
        {
            if (GridViewAllParts.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow selectedRow in GridViewAllParts.SelectedRows)
                {
                    // get the underlying object type of the current row
                    string type = selectedRow.DataBoundItem.GetType().ToString();

                    if (type == "MasterOfParts.Inhouse")
                    {
                        // cast the current row as an Inhouse part
                        Inhouse partToAdd = selectedRow.DataBoundItem as Inhouse;
                        modifiedProduct.AssociatedParts.Add(partToAdd);
                        GridViewAssociatedParts.Refresh();
                    }

                    else
                    {
                        // cast the current row as an Outsourced part
                        Outsourced partToAdd = selectedRow.DataBoundItem as Outsourced;
                        modifiedProduct.AssociatedParts.Add(partToAdd);
                        GridViewAssociatedParts.Refresh();
                    }

                }

            }

            else
            {

                return;

            }
        }

        private void SearchPart_Click(object sender, EventArgs e)
        {
            try
            {
                // cast a currencymanager to allow for hiding rows
                CurrencyManager cmAllParts = (CurrencyManager)BindingContext[GridViewAllParts.DataSource];

                if (SearchPartInput.Text.Length < 1)
                {

                    cmAllParts.SuspendBinding();

                    // mark all rows visible and return if no text is in the search field
                    foreach (DataGridViewRow row in GridViewAllParts.Rows)
                    {

                        DataGridViewBand rowBand = row;
                        rowBand.Visible = true;


                    }

                    cmAllParts.ResumeBinding();
                    GridViewAllParts.ClearSelection();
                    return;

                }
                else
                {
                    try
                    {
                        // parse input as an integer
                        int partId = int.Parse(SearchPartInput.Text);

                        // lookup by partId
                        Part matchedPart = Inventory.lookupPart(partId);

                        // filter the gridview
                        cmAllParts.SuspendBinding();

                        foreach (DataGridViewRow row in GridViewAllParts.Rows)
                        {
                            Part tmpPart = row.DataBoundItem as Part;

                            if (tmpPart.PartID == matchedPart.PartID)
                            {

                                DataGridViewBand rowBand = row;
                                rowBand.Visible = true;

                                row.Selected = true;

                            }
                            else
                            {
                                DataGridViewBand rowBand = row;
                                rowBand.Visible = false;

                                row.Selected = false;
                            }

                        }

                        cmAllParts.ResumeBinding();

                    }

                    // catch format exception that would prevent integer parsing
                    catch (FormatException fEx)
                    {
                        MessageBox.Show(fEx.Message, "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

            catch (InvalidOperationException)
            {
                MessageBox.Show("No parts match the entered PartId.", "Invalid entry!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // mark all rows visible and return if no text is in the search field
                foreach (DataGridViewRow row in GridViewAllParts.Rows)
                {

                    DataGridViewBand rowBand = row;
                    rowBand.Visible = true;

                }

                GridViewAllParts.ClearSelection();
                return;
            }
        }

        private void ProductName_Validating(object sender, CancelEventArgs e)
        {
            // check to see if the text box is empty
            if (string.IsNullOrEmpty(ProductName.Text))
            {
                errorProviderName.SetError(ProductName, "The part name must not be null or empty.");
                e.Cancel = true;
            }
            else
            {
                errorProviderName.Clear();
            }
        }

        private void ProductInventory_Validating(object sender, CancelEventArgs e)
        {

            // attempt to parse the value as the targeted datatype
            try
            {
                _ = int.Parse(ProductInventory.Text);
                errorProviderInventory.Clear();
            }
            catch (FormatException)
            {

                errorProviderInventory.SetError(ProductInventory, "Input must be digits and cannot contain letters or special characters.");
            }
        }

        private void ProductCost_Validating(object sender, CancelEventArgs e)
        {
            // attempt to parse the value as the targeted datatype
            try
            {
                _ = decimal.Parse(ProductCost.Text);
                errorProviderCost.Clear();
            }
            catch (FormatException)
            {
                // fire the error provider and cancel validation
                errorProviderCost.SetError(ProductCost, "Input must be an integer or decimal value. Examples: '1', '1.99'.");
                e.Cancel = true;
            }
        }

        private void ProductMax_Validating(object sender, CancelEventArgs e)
        {
            // attempt to parse the value as the targeted datatype
            try
            {
                _ = int.Parse(ProductMax.Text);
                errorProviderMax.Clear();

            }
            catch (FormatException)
            {
                // fire the error provider and cancel validation
                errorProviderMax.SetError(ProductMax, "Input must be an integer value, no letters or special characters.");
                e.Cancel = true;
            }
        }

        private void ProductMin_Validating(object sender, CancelEventArgs e)
        {
            // attempt to parse the value as the targeted datatype
            try
            {
                _ = int.Parse(ProductMin.Text);
                errorProviderMin.Clear();

            }
            catch (FormatException)
            {
                // fire the error provider and cancel validation
                errorProviderMax.SetError(ProductMin, "Input must be an integer value, no letters or special characters.");
                e.Cancel = true;
            }
        }
    }
}
