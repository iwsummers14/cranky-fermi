namespace ScheduleBoss.Forms
{
    partial class NewCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCustomer));
            this.lbl_NewCustomer = new System.Windows.Forms.Label();
            this.lbl_CustName = new System.Windows.Forms.Label();
            this.lbl_CustId = new System.Windows.Forms.Label();
            this.lbl_CustAddress2 = new System.Windows.Forms.Label();
            this.lbl_CustAddress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_PostalCode = new System.Windows.Forms.Label();
            this.lbl_City = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.tbox_CustomerId = new System.Windows.Forms.TextBox();
            this.lbl_PanelCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mbox_CustomerAddress = new System.Windows.Forms.MaskedTextBox();
            this.mbox_CustomerAddress2 = new System.Windows.Forms.MaskedTextBox();
            this.mbox_CustomerPhone = new System.Windows.Forms.MaskedTextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cbox_City = new System.Windows.Forms.ComboBox();
            this.mbox_CustomerName = new System.Windows.Forms.MaskedTextBox();
            this.mbox_CustomerPostalCode = new System.Windows.Forms.MaskedTextBox();
            this.cbox_Country = new System.Windows.Forms.ComboBox();
            this.lbl_Country = new System.Windows.Forms.Label();
            this.chk_IsActive = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_NewCustomer
            // 
            this.lbl_NewCustomer.AutoSize = true;
            this.lbl_NewCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewCustomer.Location = new System.Drawing.Point(12, 9);
            this.lbl_NewCustomer.Name = "lbl_NewCustomer";
            this.lbl_NewCustomer.Size = new System.Drawing.Size(137, 21);
            this.lbl_NewCustomer.TabIndex = 0;
            this.lbl_NewCustomer.Text = "NEW CUSTOMER";
            // 
            // lbl_CustName
            // 
            this.lbl_CustName.AutoSize = true;
            this.lbl_CustName.Location = new System.Drawing.Point(32, 64);
            this.lbl_CustName.Name = "lbl_CustName";
            this.lbl_CustName.Size = new System.Drawing.Size(91, 13);
            this.lbl_CustName.TabIndex = 1;
            this.lbl_CustName.Text = "Customer Name:";
            // 
            // lbl_CustId
            // 
            this.lbl_CustId.AutoSize = true;
            this.lbl_CustId.Location = new System.Drawing.Point(51, 38);
            this.lbl_CustId.Name = "lbl_CustId";
            this.lbl_CustId.Size = new System.Drawing.Size(72, 13);
            this.lbl_CustId.TabIndex = 2;
            this.lbl_CustId.Text = "Customer Id:";
            // 
            // lbl_CustAddress2
            // 
            this.lbl_CustAddress2.AutoSize = true;
            this.lbl_CustAddress2.Location = new System.Drawing.Point(39, 54);
            this.lbl_CustAddress2.Name = "lbl_CustAddress2";
            this.lbl_CustAddress2.Size = new System.Drawing.Size(84, 13);
            this.lbl_CustAddress2.TabIndex = 3;
            this.lbl_CustAddress2.Text = "Address Line 2:";
            // 
            // lbl_CustAddress
            // 
            this.lbl_CustAddress.AutoSize = true;
            this.lbl_CustAddress.Location = new System.Drawing.Point(20, 28);
            this.lbl_CustAddress.Name = "lbl_CustAddress";
            this.lbl_CustAddress.Size = new System.Drawing.Size(103, 13);
            this.lbl_CustAddress.TabIndex = 4;
            this.lbl_CustAddress.Text = "Customer Address:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk_IsActive);
            this.panel1.Controls.Add(this.mbox_CustomerName);
            this.panel1.Controls.Add(this.lbl_PanelCustomer);
            this.panel1.Controls.Add(this.tbox_CustomerId);
            this.panel1.Controls.Add(this.lbl_CustId);
            this.panel1.Controls.Add(this.lbl_CustName);
            this.panel1.Location = new System.Drawing.Point(16, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 119);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbox_Country);
            this.panel2.Controls.Add(this.lbl_Country);
            this.panel2.Controls.Add(this.mbox_CustomerPostalCode);
            this.panel2.Controls.Add(this.cbox_City);
            this.panel2.Controls.Add(this.mbox_CustomerPhone);
            this.panel2.Controls.Add(this.mbox_CustomerAddress2);
            this.panel2.Controls.Add(this.mbox_CustomerAddress);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_Phone);
            this.panel2.Controls.Add(this.lbl_City);
            this.panel2.Controls.Add(this.lbl_PostalCode);
            this.panel2.Controls.Add(this.lbl_CustAddress);
            this.panel2.Controls.Add(this.lbl_CustAddress2);
            this.panel2.Location = new System.Drawing.Point(16, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 124);
            this.panel2.TabIndex = 6;
            // 
            // lbl_PostalCode
            // 
            this.lbl_PostalCode.AutoSize = true;
            this.lbl_PostalCode.Location = new System.Drawing.Point(329, 83);
            this.lbl_PostalCode.Name = "lbl_PostalCode";
            this.lbl_PostalCode.Size = new System.Drawing.Size(71, 13);
            this.lbl_PostalCode.TabIndex = 5;
            this.lbl_PostalCode.Text = "Postal Code:";
            // 
            // lbl_City
            // 
            this.lbl_City.AutoSize = true;
            this.lbl_City.Location = new System.Drawing.Point(371, 27);
            this.lbl_City.Name = "lbl_City";
            this.lbl_City.Size = new System.Drawing.Size(29, 13);
            this.lbl_City.TabIndex = 6;
            this.lbl_City.Text = "City:";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.AutoSize = true;
            this.lbl_Phone.Location = new System.Drawing.Point(59, 83);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(64, 13);
            this.lbl_Phone.TabIndex = 7;
            this.lbl_Phone.Text = "Telephone:";
            // 
            // tbox_CustomerId
            // 
            this.tbox_CustomerId.Location = new System.Drawing.Point(129, 33);
            this.tbox_CustomerId.Name = "tbox_CustomerId";
            this.tbox_CustomerId.ReadOnly = true;
            this.tbox_CustomerId.Size = new System.Drawing.Size(190, 22);
            this.tbox_CustomerId.TabIndex = 3;
            this.tbox_CustomerId.TabStop = false;
            // 
            // lbl_PanelCustomer
            // 
            this.lbl_PanelCustomer.AutoSize = true;
            this.lbl_PanelCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PanelCustomer.Location = new System.Drawing.Point(3, 0);
            this.lbl_PanelCustomer.Name = "lbl_PanelCustomer";
            this.lbl_PanelCustomer.Size = new System.Drawing.Size(145, 17);
            this.lbl_PanelCustomer.TabIndex = 4;
            this.lbl_PanelCustomer.Text = "Customer Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customer Address";
            // 
            // mbox_CustomerAddress
            // 
            this.mbox_CustomerAddress.Location = new System.Drawing.Point(129, 24);
            this.mbox_CustomerAddress.Name = "mbox_CustomerAddress";
            this.mbox_CustomerAddress.Size = new System.Drawing.Size(190, 22);
            this.mbox_CustomerAddress.TabIndex = 5;
            // 
            // mbox_CustomerAddress2
            // 
            this.mbox_CustomerAddress2.Location = new System.Drawing.Point(129, 51);
            this.mbox_CustomerAddress2.Name = "mbox_CustomerAddress2";
            this.mbox_CustomerAddress2.Size = new System.Drawing.Size(190, 22);
            this.mbox_CustomerAddress2.TabIndex = 6;
            // 
            // mbox_CustomerPhone
            // 
            this.mbox_CustomerPhone.Location = new System.Drawing.Point(129, 80);
            this.mbox_CustomerPhone.Mask = "000-0000";
            this.mbox_CustomerPhone.Name = "mbox_CustomerPhone";
            this.mbox_CustomerPhone.Size = new System.Drawing.Size(190, 22);
            this.mbox_CustomerPhone.TabIndex = 9;
            // 
            // btn_Save
            // 
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Save.Location = new System.Drawing.Point(302, 311);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(114, 36);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancel.Location = new System.Drawing.Point(440, 311);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(113, 36);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // cbox_City
            // 
            this.cbox_City.FormattingEnabled = true;
            this.cbox_City.Location = new System.Drawing.Point(405, 25);
            this.cbox_City.Name = "cbox_City";
            this.cbox_City.Size = new System.Drawing.Size(132, 21);
            this.cbox_City.TabIndex = 7;
            this.cbox_City.SelectedIndexChanged += new System.EventHandler(this.cbox_City_SelectedIndexChanged);
            // 
            // mbox_CustomerName
            // 
            this.mbox_CustomerName.Location = new System.Drawing.Point(129, 61);
            this.mbox_CustomerName.Name = "mbox_CustomerName";
            this.mbox_CustomerName.Size = new System.Drawing.Size(190, 22);
            this.mbox_CustomerName.TabIndex = 3;
            // 
            // mbox_CustomerPostalCode
            // 
            this.mbox_CustomerPostalCode.Location = new System.Drawing.Point(405, 80);
            this.mbox_CustomerPostalCode.Mask = "00000";
            this.mbox_CustomerPostalCode.Name = "mbox_CustomerPostalCode";
            this.mbox_CustomerPostalCode.Size = new System.Drawing.Size(132, 22);
            this.mbox_CustomerPostalCode.TabIndex = 10;
            this.mbox_CustomerPostalCode.ValidatingType = typeof(int);
            // 
            // cbox_Country
            // 
            this.cbox_Country.FormattingEnabled = true;
            this.cbox_Country.Location = new System.Drawing.Point(405, 52);
            this.cbox_Country.Name = "cbox_Country";
            this.cbox_Country.Size = new System.Drawing.Size(132, 21);
            this.cbox_Country.TabIndex = 8;
            // 
            // lbl_Country
            // 
            this.lbl_Country.AutoSize = true;
            this.lbl_Country.Location = new System.Drawing.Point(349, 55);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(51, 13);
            this.lbl_Country.TabIndex = 13;
            this.lbl_Country.Text = "Country:";
            // 
            // chk_IsActive
            // 
            this.chk_IsActive.AutoSize = true;
            this.chk_IsActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_IsActive.Checked = true;
            this.chk_IsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_IsActive.Location = new System.Drawing.Point(83, 89);
            this.chk_IsActive.Name = "chk_IsActive";
            this.chk_IsActive.Size = new System.Drawing.Size(59, 17);
            this.chk_IsActive.TabIndex = 4;
            this.chk_IsActive.Text = "Active:";
            this.chk_IsActive.UseVisualStyleBackColor = true;
            // 
            // NewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 358);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_NewCustomer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCHEDULE BOSS - New Customer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_NewCustomer;
        private System.Windows.Forms.Label lbl_CustName;
        private System.Windows.Forms.Label lbl_CustId;
        private System.Windows.Forms.Label lbl_CustAddress2;
        private System.Windows.Forms.Label lbl_CustAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox mbox_CustomerName;
        private System.Windows.Forms.Label lbl_PanelCustomer;
        private System.Windows.Forms.TextBox tbox_CustomerId;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox mbox_CustomerPostalCode;
        private System.Windows.Forms.ComboBox cbox_City;
        private System.Windows.Forms.MaskedTextBox mbox_CustomerPhone;
        private System.Windows.Forms.MaskedTextBox mbox_CustomerAddress2;
        private System.Windows.Forms.MaskedTextBox mbox_CustomerAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_City;
        private System.Windows.Forms.Label lbl_PostalCode;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ComboBox cbox_Country;
        private System.Windows.Forms.Label lbl_Country;
        private System.Windows.Forms.CheckBox chk_IsActive;
    }
}