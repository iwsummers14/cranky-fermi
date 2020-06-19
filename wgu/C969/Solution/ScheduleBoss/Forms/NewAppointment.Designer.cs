namespace ScheduleBoss.Forms
{
    partial class NewAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAppointment));
            this.mbox_ApptTitle = new System.Windows.Forms.MaskedTextBox();
            this.lbl_PanelAppt = new System.Windows.Forms.Label();
            this.cbox_Customer = new System.Windows.Forms.ComboBox();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.mbox_Url = new System.Windows.Forms.MaskedTextBox();
            this.cbox_Consultant = new System.Windows.Forms.ComboBox();
            this.lbl_ApptTitle = new System.Windows.Forms.Label();
            this.mbox_ApptType = new System.Windows.Forms.MaskedTextBox();
            this.lbl_Consultant = new System.Windows.Forms.Label();
            this.lbl_Url = new System.Windows.Forms.Label();
            this.lbl_CustAddress = new System.Windows.Forms.Label();
            this.lbl_ApptDescription = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.apptPanel = new System.Windows.Forms.Panel();
            this.mbox_ApptContact = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ApptContact = new System.Windows.Forms.Label();
            this.lbl_EndTime = new System.Windows.Forms.Label();
            this.lbl_StartTime = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_StartTime = new System.Windows.Forms.DateTimePicker();
            this.tbox_ApptDescription = new System.Windows.Forms.TextBox();
            this.lbl_ApptEnd = new System.Windows.Forms.Label();
            this.lbl_ApptStart = new System.Windows.Forms.Label();
            this.dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.mbox_ApptLocation = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ApptLocation = new System.Windows.Forms.Label();
            this.lbl_NewAppointment = new System.Windows.Forms.Label();
            this.apptPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mbox_ApptTitle
            // 
            this.mbox_ApptTitle.Location = new System.Drawing.Point(111, 34);
            this.mbox_ApptTitle.Name = "mbox_ApptTitle";
            this.mbox_ApptTitle.Size = new System.Drawing.Size(249, 20);
            this.mbox_ApptTitle.TabIndex = 1;
            this.mbox_ApptTitle.Tag = "Appointment Title";
            // 
            // lbl_PanelAppt
            // 
            this.lbl_PanelAppt.AutoSize = true;
            this.lbl_PanelAppt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PanelAppt.Location = new System.Drawing.Point(3, 0);
            this.lbl_PanelAppt.Name = "lbl_PanelAppt";
            this.lbl_PanelAppt.Size = new System.Drawing.Size(137, 17);
            this.lbl_PanelAppt.TabIndex = 4;
            this.lbl_PanelAppt.Text = "Appointment Details";
            // 
            // cbox_Customer
            // 
            this.cbox_Customer.FormattingEnabled = true;
            this.cbox_Customer.Location = new System.Drawing.Point(111, 87);
            this.cbox_Customer.Name = "cbox_Customer";
            this.cbox_Customer.Size = new System.Drawing.Size(249, 21);
            this.cbox_Customer.TabIndex = 3;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.Location = new System.Drawing.Point(46, 90);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(54, 13);
            this.lbl_Customer.TabIndex = 13;
            this.lbl_Customer.Text = "Customer:";
            // 
            // mbox_Url
            // 
            this.mbox_Url.Location = new System.Drawing.Point(111, 303);
            this.mbox_Url.Name = "mbox_Url";
            this.mbox_Url.Size = new System.Drawing.Size(249, 20);
            this.mbox_Url.TabIndex = 11;
            this.mbox_Url.Tag = "URL";
            // 
            // cbox_Consultant
            // 
            this.cbox_Consultant.FormattingEnabled = true;
            this.cbox_Consultant.Location = new System.Drawing.Point(111, 60);
            this.cbox_Consultant.Name = "cbox_Consultant";
            this.cbox_Consultant.Size = new System.Drawing.Size(249, 21);
            this.cbox_Consultant.TabIndex = 2;
            // 
            // lbl_ApptTitle
            // 
            this.lbl_ApptTitle.AutoSize = true;
            this.lbl_ApptTitle.Location = new System.Drawing.Point(7, 37);
            this.lbl_ApptTitle.Name = "lbl_ApptTitle";
            this.lbl_ApptTitle.Size = new System.Drawing.Size(92, 13);
            this.lbl_ApptTitle.TabIndex = 1;
            this.lbl_ApptTitle.Text = "Appointment Title:";
            // 
            // mbox_ApptType
            // 
            this.mbox_ApptType.Location = new System.Drawing.Point(111, 251);
            this.mbox_ApptType.Name = "mbox_ApptType";
            this.mbox_ApptType.Size = new System.Drawing.Size(249, 20);
            this.mbox_ApptType.TabIndex = 9;
            this.mbox_ApptType.Tag = "Appointment Type";
            // 
            // lbl_Consultant
            // 
            this.lbl_Consultant.AutoSize = true;
            this.lbl_Consultant.Location = new System.Drawing.Point(40, 63);
            this.lbl_Consultant.Name = "lbl_Consultant";
            this.lbl_Consultant.Size = new System.Drawing.Size(60, 13);
            this.lbl_Consultant.TabIndex = 6;
            this.lbl_Consultant.Text = "Consultant:";
            // 
            // lbl_Url
            // 
            this.lbl_Url.AutoSize = true;
            this.lbl_Url.Location = new System.Drawing.Point(67, 306);
            this.lbl_Url.Name = "lbl_Url";
            this.lbl_Url.Size = new System.Drawing.Size(32, 13);
            this.lbl_Url.TabIndex = 5;
            this.lbl_Url.Text = "URL:";
            // 
            // lbl_CustAddress
            // 
            this.lbl_CustAddress.AutoSize = true;
            this.lbl_CustAddress.Location = new System.Drawing.Point(3, 254);
            this.lbl_CustAddress.Name = "lbl_CustAddress";
            this.lbl_CustAddress.Size = new System.Drawing.Size(96, 13);
            this.lbl_CustAddress.TabIndex = 4;
            this.lbl_CustAddress.Text = "Appointment Type:";
            // 
            // lbl_ApptDescription
            // 
            this.lbl_ApptDescription.AutoSize = true;
            this.lbl_ApptDescription.Location = new System.Drawing.Point(37, 332);
            this.lbl_ApptDescription.Name = "lbl_ApptDescription";
            this.lbl_ApptDescription.Size = new System.Drawing.Size(63, 13);
            this.lbl_ApptDescription.TabIndex = 3;
            this.lbl_ApptDescription.Text = "Description:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancel.Location = new System.Drawing.Point(283, 497);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(113, 36);
            this.btn_Cancel.TabIndex = 14;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Save.Location = new System.Drawing.Point(163, 497);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(114, 36);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // apptPanel
            // 
            this.apptPanel.Controls.Add(this.mbox_ApptContact);
            this.apptPanel.Controls.Add(this.lbl_ApptContact);
            this.apptPanel.Controls.Add(this.lbl_EndTime);
            this.apptPanel.Controls.Add(this.lbl_StartTime);
            this.apptPanel.Controls.Add(this.dtp_EndTime);
            this.apptPanel.Controls.Add(this.dtp_StartTime);
            this.apptPanel.Controls.Add(this.tbox_ApptDescription);
            this.apptPanel.Controls.Add(this.lbl_ApptEnd);
            this.apptPanel.Controls.Add(this.lbl_ApptStart);
            this.apptPanel.Controls.Add(this.dtp_EndDate);
            this.apptPanel.Controls.Add(this.dtp_StartDate);
            this.apptPanel.Controls.Add(this.mbox_ApptLocation);
            this.apptPanel.Controls.Add(this.lbl_ApptLocation);
            this.apptPanel.Controls.Add(this.mbox_ApptTitle);
            this.apptPanel.Controls.Add(this.lbl_PanelAppt);
            this.apptPanel.Controls.Add(this.cbox_Customer);
            this.apptPanel.Controls.Add(this.lbl_Customer);
            this.apptPanel.Controls.Add(this.mbox_Url);
            this.apptPanel.Controls.Add(this.cbox_Consultant);
            this.apptPanel.Controls.Add(this.lbl_ApptTitle);
            this.apptPanel.Controls.Add(this.mbox_ApptType);
            this.apptPanel.Controls.Add(this.lbl_Consultant);
            this.apptPanel.Controls.Add(this.lbl_Url);
            this.apptPanel.Controls.Add(this.lbl_CustAddress);
            this.apptPanel.Controls.Add(this.lbl_ApptDescription);
            this.apptPanel.Location = new System.Drawing.Point(16, 47);
            this.apptPanel.Name = "apptPanel";
            this.apptPanel.Size = new System.Drawing.Size(380, 444);
            this.apptPanel.TabIndex = 14;
            // 
            // mbox_ApptContact
            // 
            this.mbox_ApptContact.Location = new System.Drawing.Point(111, 225);
            this.mbox_ApptContact.Name = "mbox_ApptContact";
            this.mbox_ApptContact.Size = new System.Drawing.Size(249, 20);
            this.mbox_ApptContact.TabIndex = 8;
            this.mbox_ApptContact.Tag = "Contact";
            // 
            // lbl_ApptContact
            // 
            this.lbl_ApptContact.AutoSize = true;
            this.lbl_ApptContact.Location = new System.Drawing.Point(52, 228);
            this.lbl_ApptContact.Name = "lbl_ApptContact";
            this.lbl_ApptContact.Size = new System.Drawing.Size(47, 13);
            this.lbl_ApptContact.TabIndex = 22;
            this.lbl_ApptContact.Text = "Contact:";
            // 
            // lbl_EndTime
            // 
            this.lbl_EndTime.AutoSize = true;
            this.lbl_EndTime.Location = new System.Drawing.Point(41, 198);
            this.lbl_EndTime.Name = "lbl_EndTime";
            this.lbl_EndTime.Size = new System.Drawing.Size(55, 13);
            this.lbl_EndTime.TabIndex = 21;
            this.lbl_EndTime.Text = "End Time:";
            // 
            // lbl_StartTime
            // 
            this.lbl_StartTime.AutoSize = true;
            this.lbl_StartTime.Location = new System.Drawing.Point(42, 144);
            this.lbl_StartTime.Name = "lbl_StartTime";
            this.lbl_StartTime.Size = new System.Drawing.Size(58, 13);
            this.lbl_StartTime.TabIndex = 20;
            this.lbl_StartTime.Text = "Start Time:";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_EndTime.Location = new System.Drawing.Point(111, 196);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.ShowUpDown = true;
            this.dtp_EndTime.Size = new System.Drawing.Size(249, 20);
            this.dtp_EndTime.TabIndex = 7;
            this.dtp_EndTime.Tag = "End Time";
            // 
            // dtp_StartTime
            // 
            this.dtp_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_StartTime.Location = new System.Drawing.Point(111, 140);
            this.dtp_StartTime.Name = "dtp_StartTime";
            this.dtp_StartTime.ShowUpDown = true;
            this.dtp_StartTime.Size = new System.Drawing.Size(249, 20);
            this.dtp_StartTime.TabIndex = 5;
            this.dtp_StartTime.Tag = "Start Time";
            // 
            // tbox_ApptDescription
            // 
            this.tbox_ApptDescription.Location = new System.Drawing.Point(111, 329);
            this.tbox_ApptDescription.Multiline = true;
            this.tbox_ApptDescription.Name = "tbox_ApptDescription";
            this.tbox_ApptDescription.Size = new System.Drawing.Size(249, 99);
            this.tbox_ApptDescription.TabIndex = 12;
            this.tbox_ApptDescription.Tag = "Description";
            // 
            // lbl_ApptEnd
            // 
            this.lbl_ApptEnd.AutoSize = true;
            this.lbl_ApptEnd.Location = new System.Drawing.Point(45, 169);
            this.lbl_ApptEnd.Name = "lbl_ApptEnd";
            this.lbl_ApptEnd.Size = new System.Drawing.Size(55, 13);
            this.lbl_ApptEnd.TabIndex = 19;
            this.lbl_ApptEnd.Text = "End Date:";
            // 
            // lbl_ApptStart
            // 
            this.lbl_ApptStart.AutoSize = true;
            this.lbl_ApptStart.Location = new System.Drawing.Point(42, 120);
            this.lbl_ApptStart.Name = "lbl_ApptStart";
            this.lbl_ApptStart.Size = new System.Drawing.Size(58, 13);
            this.lbl_ApptStart.TabIndex = 18;
            this.lbl_ApptStart.Text = "Start Date:";
            // 
            // dtp_EndDate
            // 
            this.dtp_EndDate.Location = new System.Drawing.Point(111, 169);
            this.dtp_EndDate.Name = "dtp_EndDate";
            this.dtp_EndDate.Size = new System.Drawing.Size(249, 20);
            this.dtp_EndDate.TabIndex = 6;
            this.dtp_EndDate.Tag = "End Date";
            this.dtp_EndDate.ValueChanged += new System.EventHandler(this.dtp_EndDate_ValueChanged);
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtp_StartDate.Location = new System.Drawing.Point(111, 114);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(249, 20);
            this.dtp_StartDate.TabIndex = 4;
            this.dtp_StartDate.Tag = "Start Date";
            this.dtp_StartDate.ValueChanged += new System.EventHandler(this.dtp_StartDate_ValueChanged);
            // 
            // mbox_ApptLocation
            // 
            this.mbox_ApptLocation.Location = new System.Drawing.Point(111, 277);
            this.mbox_ApptLocation.Name = "mbox_ApptLocation";
            this.mbox_ApptLocation.Size = new System.Drawing.Size(249, 20);
            this.mbox_ApptLocation.TabIndex = 10;
            this.mbox_ApptLocation.Tag = "Location";
            // 
            // lbl_ApptLocation
            // 
            this.lbl_ApptLocation.AutoSize = true;
            this.lbl_ApptLocation.Location = new System.Drawing.Point(49, 280);
            this.lbl_ApptLocation.Name = "lbl_ApptLocation";
            this.lbl_ApptLocation.Size = new System.Drawing.Size(51, 13);
            this.lbl_ApptLocation.TabIndex = 14;
            this.lbl_ApptLocation.Text = "Location:";
            // 
            // lbl_NewAppointment
            // 
            this.lbl_NewAppointment.AutoSize = true;
            this.lbl_NewAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewAppointment.Location = new System.Drawing.Point(12, 9);
            this.lbl_NewAppointment.Name = "lbl_NewAppointment";
            this.lbl_NewAppointment.Size = new System.Drawing.Size(168, 21);
            this.lbl_NewAppointment.TabIndex = 13;
            this.lbl_NewAppointment.Text = "NEW APPOINTMENT";
            // 
            // NewAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 544);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.apptPanel);
            this.Controls.Add(this.lbl_NewAppointment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SCHEDULE BOSS - New Appointment";
            this.apptPanel.ResumeLayout(false);
            this.apptPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox mbox_ApptTitle;
        private System.Windows.Forms.Label lbl_PanelAppt;
        private System.Windows.Forms.ComboBox cbox_Customer;
        private System.Windows.Forms.Label lbl_Customer;
        private System.Windows.Forms.MaskedTextBox mbox_Url;
        private System.Windows.Forms.ComboBox cbox_Consultant;
        private System.Windows.Forms.Label lbl_ApptTitle;
        private System.Windows.Forms.MaskedTextBox mbox_ApptType;
        private System.Windows.Forms.Label lbl_Consultant;
        private System.Windows.Forms.Label lbl_Url;
        private System.Windows.Forms.Label lbl_CustAddress;
        private System.Windows.Forms.Label lbl_ApptDescription;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Panel apptPanel;
        private System.Windows.Forms.Label lbl_NewAppointment;
        private System.Windows.Forms.Label lbl_ApptEnd;
        private System.Windows.Forms.Label lbl_ApptStart;
        private System.Windows.Forms.DateTimePicker dtp_EndDate;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.MaskedTextBox mbox_ApptLocation;
        private System.Windows.Forms.Label lbl_ApptLocation;
        private System.Windows.Forms.TextBox tbox_ApptDescription;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_StartTime;
        private System.Windows.Forms.Label lbl_EndTime;
        private System.Windows.Forms.Label lbl_StartTime;
        private System.Windows.Forms.MaskedTextBox mbox_ApptContact;
        private System.Windows.Forms.Label lbl_ApptContact;
    }
}