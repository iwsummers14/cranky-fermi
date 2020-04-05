using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterOfParts
{
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set binding list options on inventory static object
            Inventory.Products.AllowNew = true;
            Inventory.Products.AllowEdit = true;
            Inventory.Products.AllowRemove = true;

            Inventory.AllParts.AllowNew = true;
            Inventory.AllParts.AllowEdit = true;
            Inventory.AllParts.AllowRemove = true;

            // define binding data sources
            BindingSource bPart = new BindingSource();
            bPart.DataSource = Inventory.AllParts;

            BindingSource bProduct = new BindingSource();
            bProduct.DataSource = Inventory.Products;

            // assign data sources to grid views
            GridViewPart.DataSource = bPart;
            GridViewProduct.DataSource = bProduct;

            // set gridview options 
            GridViewPart.RowHeadersVisible = false;
            GridViewPart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewPart.AllowUserToAddRows = false;
            GridViewPart.AllowUserToDeleteRows = false;
            GridViewPart.AllowUserToResizeRows = false;
            GridViewPart.AllowUserToOrderColumns = false;
            GridViewPart.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridViewPart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewPart.MultiSelect = false;

            GridViewProduct.RowHeadersVisible = false;
            GridViewProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewProduct.AllowUserToAddRows = false;
            GridViewProduct.AllowUserToDeleteRows = false;
            GridViewProduct.AllowUserToResizeRows = false;
            GridViewProduct.AllowUserToOrderColumns = false;
            GridViewProduct.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridViewProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewProduct.MultiSelect = false;

            // set column options on each Part gridview column
            GridViewPart.Columns["PartId"].HeaderText = "Part ID";
            GridViewPart.Columns["PartId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewPart.Columns["PartID"].DisplayIndex = 0;

            GridViewPart.Columns["Name"].HeaderText = "Name";
            GridViewPart.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridViewPart.Columns["Name"].DisplayIndex = 1;

            GridViewPart.Columns["InStock"].HeaderText = "Inventory";
            GridViewPart.Columns["InStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewPart.Columns["InStock"].DisplayIndex = 2;

            GridViewPart.Columns["Price"].HeaderText = "Price";
            GridViewPart.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewPart.Columns["Price"].DisplayIndex = 3;

            GridViewPart.Columns["Min"].HeaderText = "Min";
            GridViewPart.Columns["Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
            GridViewPart.Columns["Min"].DisplayIndex = 4;


            GridViewPart.Columns["Max"].HeaderText = "Max";
            GridViewPart.Columns["Max"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewPart.Columns["Max"].DisplayIndex = 5;

            // set column options on each Product gridview column
            GridViewProduct.Columns["ProductId"].HeaderText = "Product ID";
            GridViewProduct.Columns["ProductId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewProduct.Columns["ProductID"].DisplayIndex = 0;

            GridViewProduct.Columns["Name"].HeaderText = "Name";
            GridViewProduct.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridViewProduct.Columns["Name"].DisplayIndex = 1;

            GridViewProduct.Columns["InStock"].HeaderText = "Inventory";
            GridViewProduct.Columns["InStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewProduct.Columns["InStock"].DisplayIndex = 2;

            GridViewProduct.Columns["Price"].HeaderText = "Price";
            GridViewProduct.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewProduct.Columns["Price"].DisplayIndex = 3;

            GridViewProduct.Columns["Min"].HeaderText = "Min";
            GridViewProduct.Columns["Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewProduct.Columns["Min"].DisplayIndex = 4;
            
            GridViewProduct.Columns["Max"].HeaderText = "Max";
            GridViewProduct.Columns["Max"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridViewProduct.Columns["Max"].DisplayIndex = 5;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddPart_Click(object sender, EventArgs e)
        {
            // create an instance of the form and display it
            Forms.fPartAdd fNewPart = new Forms.fPartAdd();
            fNewPart.Show();
        }

        private void ModifyPart_Click(object sender, EventArgs e)
        {

            // if a row was selected, get the underlying object to modify the part
            if (GridViewPart.SelectedRows.Count > 0)
            {
                // get the underlying object type of the current row
                string type = GridViewPart.CurrentRow.DataBoundItem.GetType().ToString();

                if (type == "MasterOfParts.Inhouse")
                {
                    // cast the current row as an Inhouse part
                    Inhouse partToModify = GridViewPart.CurrentRow.DataBoundItem as Inhouse;

                    // create an instance of the form and display it
                    Forms.fPartModify fModifyPart = new Forms.fPartModify(partToModify);
                    fModifyPart.FormClosed += new FormClosedEventHandler(fModifyPart_FormClosed);
                    fModifyPart.Show();

                }

                else
                {
                    // cast the current row as an Outsourced part
                    Outsourced partToModify = GridViewPart.CurrentRow.DataBoundItem as Outsourced;

                    // create an instance of the form and display it
                    Forms.fPartModify fModifyPart = new Forms.fPartModify(partToModify);
                    fModifyPart.FormClosed += new FormClosedEventHandler(fModifyPart_FormClosed);
                    fModifyPart.Show();
                }

            }

            // do nothing if nothing was selected
            else
            {

                return;

            }
            
        }
        private void DeletePart_Click(object sender, EventArgs e)
        {
            // if a row was selected, delete the associated object
            if (GridViewPart.SelectedRows.Count > 0)
            {
                // get the underlying object type of the current row
                string type = GridViewPart.CurrentRow.DataBoundItem.GetType().ToString();

                if (type == "MasterOfParts.Inhouse")
                {
                    // cast the current row as an Inhouse part
                    Inhouse partToDelete = GridViewPart.CurrentRow.DataBoundItem as Inhouse;

                    // get user confirmation before deleting
                    DialogResult confirmation = MessageBox.Show(
                        $"Are you sure you wish to delete product '{partToDelete.Name}'?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation
                        );

                    // if confirmed, delete and notify user of result
                    if (confirmation == System.Windows.Forms.DialogResult.Yes)
                    {
                        // delete and notify user of the result
                        bool result = Inventory.deletePart(partToDelete);

                        if (result == true)
                        {
                            MessageBox.Show(
                                $"Successfully deleted in-house part '{partToDelete.Name}' from the inventory.",
                                "Part deleted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                        }
                        else
                        {
                            MessageBox.Show(
                                $"Unable to delete in-house part '{partToDelete.Name}' from the inventory.",
                                "Part not deleted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }

                    }

                    // do nothing if confirmation was not given
                    else
                    {
                        return;
                    }
                    
                }

                else
                {
                    // cast the current row as an Outsourced part
                    Outsourced partToDelete = GridViewPart.CurrentRow.DataBoundItem as Outsourced;

                    // get user confirmation before deleting
                    DialogResult confirmation = MessageBox.Show(
                        $"Are you sure you wish to delete product '{partToDelete.Name}'?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation
                        );

                    // if confirmed, delete and notify user of result
                    if (confirmation == System.Windows.Forms.DialogResult.Yes)
                    {
                        // delete and notify user of the result
                        bool result = Inventory.deletePart(partToDelete);

                        if (result == true)
                        {
                            MessageBox.Show(
                                $"Successfully deleted outsourced part '{partToDelete.Name}' from the inventory.",
                                "Part deleted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                        }
                        else
                        {
                            MessageBox.Show(
                                $"Unable to delete outsourced part '{partToDelete.Name}' from the inventory.",
                                "Part not deleted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }

                    }

                    // do nothing if confirmation was not given
                    else
                    {
                        return;
                    }

                }

            }

            // do nothing if nothing was selected
            else
            {
                
                return;
            }
                        
        }

        private void fModifyPart_FormClosed(object sender, FormClosedEventArgs e)
        {
            GridViewProduct.Refresh();
            GridViewPart.Refresh();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            // exit the application 
            this.Close();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            // create an instance of the form and display it
            Forms.fProductAdd fNewProduct = new Forms.fProductAdd();
            fNewProduct.Show();
        }

        private void ModifyProduct_Click(object sender, EventArgs e)
        {

            // if a row was selected, get the underlying object to modify the part
            if (GridViewProduct.SelectedRows.Count > 0)
            {
                
                // cast the current row as an Outsourced part
                Product productToModify = GridViewProduct.CurrentRow.DataBoundItem as Product;

                // create an instance of the form and display it
                Forms.fProductModify fModifyProduct = new Forms.fProductModify(productToModify);
                fModifyProduct.FormClosed += new FormClosedEventHandler(fModifyProduct_FormClosed);
                fModifyProduct.Show();


            }

            // do nothing if nothing was selected
            else
            {

                return;

            }
                        
        }

        private void fModifyProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            GridViewProduct.Refresh();
            GridViewPart.Refresh();
        }

        private void DeleteProduct_Click(object sender, EventArgs e)
        {

            // if a row was selected, delete the underlying object
            if (GridViewProduct.SelectedRows.Count > 0)
            {

                // cast the current row as a Product
                Product productToDelete = GridViewProduct.CurrentRow.DataBoundItem as Product;

                // check to see if Parts are associated with the Product
                if (productToDelete.AssociatedParts.Count() > 0)
                {
                    MessageBox.Show(
                        $"Cannot delete product '{productToDelete.Name}' from the inventory, because it has one or more associated parts.",
                        "Product cannot be deleted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // get user confirmation before deleting
                DialogResult confirmation = MessageBox.Show(
                    $"Are you sure you wish to delete product '{productToDelete.Name}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation
                    );

                // if confirmed, delete and notify user of result
                if (confirmation == System.Windows.Forms.DialogResult.Yes)
                {
                    // delete and notify user of the result
                    bool result = Inventory.removeProduct(productToDelete.ProductID);

                    if (result == true)
                    {
                        MessageBox.Show(
                            $"Successfully deleted product '{productToDelete.Name}' from the inventory.",
                            "Product deleted",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                    }
                    else
                    {
                        MessageBox.Show(
                            $"Unable to delete product '{productToDelete.Name}' from the inventory.",
                            "Product not deleted",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                    }

                }
                
                // do nothing if confirmation was not given
                else
                {
                    return;
                }
            }

            else
            {
                // do nothing if nothing was selected
                return;
            }
        }

        private void SearchProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // cast a currencymanager to allow for hiding rows
                CurrencyManager cmProduct = (CurrencyManager)BindingContext[GridViewProduct.DataSource];

                if (SearchPartInput.Text.Length < 1)
                {

                    cmProduct.SuspendBinding();

                    // mark all rows visible and return if no text is in the search field
                    foreach (DataGridViewRow row in GridViewProduct.Rows)
                    {

                        DataGridViewBand rowBand = row;
                        rowBand.Visible = true;


                    }

                    cmProduct.ResumeBinding();
                    GridViewProduct.ClearSelection();
                    return;

                }
                else
                {
                    try
                    {
                        // parse input as an integer
                        int productId = int.Parse(SearchProductInput.Text);

                        // lookup by productId
                        Product matchedProduct = Inventory.lookupProduct(productId);

                        // filter the gridview
                        cmProduct.SuspendBinding();

                        foreach (DataGridViewRow row in GridViewProduct.Rows)
                        {
                            Product tmpProduct = row.DataBoundItem as Product;

                            if (tmpProduct.ProductID == matchedProduct.ProductID)
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

                        cmProduct.ResumeBinding();

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

                // notify the user that there was no match for the search criteria
                MessageBox.Show("No parts match the entered Product ID.", "Invalid entry!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // mark all rows visible and return if no text is in the search field
                foreach (DataGridViewRow row in GridViewProduct.Rows)
                {

                    DataGridViewBand rowBand = row;
                    rowBand.Visible = true;

                }

                GridViewProduct.ClearSelection();
                return;
            }

        }

        private void SearchPart_Click(object sender, EventArgs e)
        {
            try
            {
                // cast a currencymanager to allow for hiding rows
                CurrencyManager cmPart = (CurrencyManager)BindingContext[GridViewPart.DataSource];

                if (SearchPartInput.Text.Length < 1)
                {

                    cmPart.SuspendBinding();

                    // mark all rows visible and return if no text is in the search field
                    foreach (DataGridViewRow row in GridViewPart.Rows)
                    {

                        DataGridViewBand rowBand = row;
                        rowBand.Visible = true;


                    }

                    cmPart.ResumeBinding();
                    GridViewPart.ClearSelection();
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
                        cmPart.SuspendBinding();

                        foreach (DataGridViewRow row in GridViewPart.Rows)
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

                        cmPart.ResumeBinding();

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
                // notify the user that there was no match for the search criteria
                MessageBox.Show("No parts match the entered PartId.", "Invalid entry!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                // mark all rows visible and return if no text is in the search field
                foreach (DataGridViewRow row in GridViewPart.Rows)
                {

                    DataGridViewBand rowBand = row;
                    rowBand.Visible = true;
                    
                }

                GridViewPart.ClearSelection();
                return;
            }
                           
        }
                
    }

}

