﻿using System;
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
using ScheduleBoss.Forms;

namespace ScheduleBoss.Forms
{
    public partial class CustomerList : Form
    {
        public DatabaseConnection Database { get; set; }

        public EventLogger Logger { get; set; }

        public UserSession Session { get; set; }

        public DataTable Customers { get; set; }

        public DataProcessor DataProc { get; set; }

        public BindingSource ViewSource { get; set; }

        public CustomerList(DatabaseConnection db, EventLogger log, UserSession sess)
        {
            InitializeComponent();

            // set database, logger, and session properties
            this.Database = db;
            this.Logger = log;
            this.Session = sess;

            // initialize a data processor
            this.DataProc = new DataProcessor(this.Database);

            // set up datatable for binding source on grid view
            this.Customers = this.DataProc.GetAllTableValues(DatabaseEntries.Customer);
            
            // set up binding source and assign to gridview
            this.ViewSource = new BindingSource();
            this.ViewSource.DataSource = this.Customers;
            dgv_Customers.DataSource = this.ViewSource;
            
            // set gridview options 
            dgv_Customers.RowHeadersVisible = false;
            dgv_Customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Customers.AllowUserToAddRows = false;
            dgv_Customers.AllowUserToDeleteRows = false;
            dgv_Customers.AllowUserToResizeRows = false;
            dgv_Customers.AllowUserToOrderColumns = false;
            dgv_Customers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv_Customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Customers.MultiSelect = false;

            // set column display options
            dgv_Customers.Columns["customerId"].HeaderText = "Customer ID";
            dgv_Customers.Columns["customerId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Customers.Columns["customerId"].DisplayIndex = 0;

            dgv_Customers.Columns["customerName"].HeaderText = "Customer Name";
            dgv_Customers.Columns["customerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_Customers.Columns["customerName"].DisplayIndex = 1;

            dgv_Customers.Columns["addressId"].HeaderText = "Address Record ID";
            dgv_Customers.Columns["addressId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Customers.Columns["addressId"].DisplayIndex = 2;

            dgv_Customers.Columns["active"].HeaderText = "Active?";
            dgv_Customers.Columns["active"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Customers.Columns["active"].DisplayIndex = 3;

            dgv_Customers.Columns["createDate"].HeaderText = "Create Date";
            dgv_Customers.Columns["createDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Customers.Columns["createDate"].DisplayIndex = 4;

            dgv_Customers.Columns["createdBy"].HeaderText = "Created By";
            dgv_Customers.Columns["createdBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Customers.Columns["createdBy"].DisplayIndex = 5;

            dgv_Customers.Columns["lastUpdate"].HeaderText = "Last Update";
            dgv_Customers.Columns["lastUpdate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Customers.Columns["lastUpdate"].DisplayIndex = 6;

            dgv_Customers.Columns["lastUpdateBy"].HeaderText = "Updated By";
            dgv_Customers.Columns["lastUpdateBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Customers.Columns["lastUpdateBy"].DisplayIndex = 7;


        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {

            // if a row was selected, get the underlying object to modify
            if (dgv_Customers.SelectedRows.Count > 0)
            {

                // this code does not work
                DataRow row = ((DataRowView)dgv_Customers.CurrentRow.DataBoundItem).Row;
                int custId = int.Parse(row[0].ToString());
                int addrId = int.Parse(row[2].ToString());

                Customer Cust = this.DataProc.GetRecordById(custId, DatabaseEntries.Customer) as Customer;    
                CustomerAddress Addr = this.DataProc.GetRecordById(addrId, DatabaseEntries.Address) as CustomerAddress;

                // create an instance of the form and display it
                ModifyCustomer ModCust = new ModifyCustomer(this.Database, this.Logger, this.Session, Cust, Addr);
                ModCust.FormClosed += new FormClosedEventHandler(ModCust_FormClosed);
                ModCust.Show();
               
                  
            } 

            // do nothing if nothing was selected
            else
            {

                return;

            }

        } 
        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModCust_FormClosed(object sender, FormClosedEventArgs e) 
        {
            // refresh datatable for binding source on grid view - DOESNT WORK
            this.Customers = this.DataProc.GetAllTableValues(DatabaseEntries.Customer);
            this.ViewSource.DataSource = this.Customers;
//            this.ViewSource.ResetBindings(false);
            dgv_Customers.Refresh();
        }
       
    }
}
