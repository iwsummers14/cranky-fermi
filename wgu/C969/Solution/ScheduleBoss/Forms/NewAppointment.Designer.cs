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
            this.lbl_NewAppointment = new System.Windows.Forms.Label();
            this.mbox_ApptLocation = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ApptLocation = new System.Windows.Forms.Label();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.lbl_ApptStart = new System.Windows.Forms.Label();
            this.lbl_ApptEnd = new System.Windows.Forms.Label();
            this.tbox_ApptDescription = new System.Windows.Forms.TextBox();
            this.apptPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mbox_ApptTitle
            // 
            this.mbox_ApptTitle.Location = new System.Drawing.Point(118, 55);
            this.mbox_ApptTitle.Name = "mbox_ApptTitle";
            this.mbox_ApptTitle.Size = new System.Drawing.Size(190, 20);
            this.mbox_ApptTitle.TabIndex = 2;
            this.mbox_ApptTitle.Tag = "";
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
            this.cbox_Customer.Location = new System.Drawing.Point(118, 146);
            this.cbox_Customer.Name = "cbox_Customer";
            this.cbox_Customer.Size = new System.Drawing.Size(190, 21);
            this.cbox_Customer.TabIndex = 4;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.Location = new System.Drawing.Point(55, 149);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(54, 13);
            this.lbl_Customer.TabIndex = 13;
            this.lbl_Customer.Text = "Customer:";
            // 
            // mbox_Url
            // 
            this.mbox_Url.Location = new System.Drawing.Point(118, 220);
            this.mbox_Url.Name = "mbox_Url";
            this.mbox_Url.Size = new System.Drawing.Size(190, 20);
            this.mbox_Url.TabIndex = 8;
            this.mbox_Url.Tag = "";
            // 
            // cbox_Consultant
            // 
            this.cbox_Consultant.FormattingEnabled = true;
            this.cbox_Consultant.Location = new System.Drawing.Point(118, 119);
            this.cbox_Consultant.Name = "cbox_Consultant";
            this.cbox_Consultant.Size = new System.Drawing.Size(190, 21);
            this.cbox_Consultant.TabIndex = 3;
            // 
            // lbl_ApptTitle
            // 
            this.lbl_ApptTitle.AutoSize = true;
            this.lbl_ApptTitle.Location = new System.Drawing.Point(21, 58);
            this.lbl_ApptTitle.Name = "lbl_ApptTitle";
            this.lbl_ApptTitle.Size = new System.Drawing.Size(92, 13);
            this.lbl_ApptTitle.TabIndex = 1;
            this.lbl_ApptTitle.Text = "Appointment Title:";
            // 
            // mbox_ApptType
            // 
            this.mbox_ApptType.Location = new System.Drawing.Point(118, 84);
            this.mbox_ApptType.Name = "mbox_ApptType";
            this.mbox_ApptType.Size = new System.Drawing.Size(190, 20);
            this.mbox_ApptType.TabIndex = 2;
            this.mbox_ApptType.Tag = "Customer Address";
            // 
            // lbl_Consultant
            // 
            this.lbl_Consultant.AutoSize = true;
            this.lbl_Consultant.Location = new System.Drawing.Point(49, 122);
            this.lbl_Consultant.Name = "lbl_Consultant";
            this.lbl_Consultant.Size = new System.Drawing.Size(60, 13);
            this.lbl_Consultant.TabIndex = 6;
            this.lbl_Consultant.Text = "Consultant:";
            // 
            // lbl_Url
            // 
            this.lbl_Url.AutoSize = true;
            this.lbl_Url.Location = new System.Drawing.Point(80, 223);
            this.lbl_Url.Name = "lbl_Url";
            this.lbl_Url.Size = new System.Drawing.Size(32, 13);
            this.lbl_Url.TabIndex = 5;
            this.lbl_Url.Text = "URL:";
            // 
            // lbl_CustAddress
            // 
            this.lbl_CustAddress.AutoSize = true;
            this.lbl_CustAddress.Location = new System.Drawing.Point(17, 87);
            this.lbl_CustAddress.Name = "lbl_CustAddress";
            this.lbl_CustAddress.Size = new System.Drawing.Size(96, 13);
            this.lbl_CustAddress.TabIndex = 4;
            this.lbl_CustAddress.Text = "Appointment Type:";
            // 
            // lbl_ApptDescription
            // 
            this.lbl_ApptDescription.AutoSize = true;
            this.lbl_ApptDescription.Location = new System.Drawing.Point(323, 196);
            this.lbl_ApptDescription.Name = "lbl_ApptDescription";
            this.lbl_ApptDescription.Size = new System.Drawing.Size(63, 13);
            this.lbl_ApptDescription.TabIndex = 3;
            this.lbl_ApptDescription.Text = "Description:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancel.Location = new System.Drawing.Point(511, 364);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(113, 36);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Save.Location = new System.Drawing.Point(391, 364);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(114, 36);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // apptPanel
            // 
            this.apptPanel.Controls.Add(this.tbox_ApptDescription);
            this.apptPanel.Controls.Add(this.lbl_ApptEnd);
            this.apptPanel.Controls.Add(this.lbl_ApptStart);
            this.apptPanel.Controls.Add(this.dtp_End);
            this.apptPanel.Controls.Add(this.dtp_Start);
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
            this.apptPanel.Size = new System.Drawing.Size(608, 311);
            this.apptPanel.TabIndex = 14;
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
            // mbox_ApptLocation
            // 
            this.mbox_ApptLocation.Location = new System.Drawing.Point(118, 193);
            this.mbox_ApptLocation.Name = "mbox_ApptLocation";
            this.mbox_ApptLocation.Size = new System.Drawing.Size(190, 20);
            this.mbox_ApptLocation.TabIndex = 7;
            this.mbox_ApptLocation.Tag = "";
            // 
            // lbl_ApptLocation
            // 
            this.lbl_ApptLocation.AutoSize = true;
            this.lbl_ApptLocation.Location = new System.Drawing.Point(61, 196);
            this.lbl_ApptLocation.Name = "lbl_ApptLocation";
            this.lbl_ApptLocation.Size = new System.Drawing.Size(51, 13);
            this.lbl_ApptLocation.TabIndex = 14;
            this.lbl_ApptLocation.Text = "Location:";
            // 
            // dtp_Start
            // 
            this.dtp_Start.Location = new System.Drawing.Point(392, 55);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(200, 20);
            this.dtp_Start.TabIndex = 5;
            // 
            // dtp_End
            // 
            this.dtp_End.Location = new System.Drawing.Point(392, 81);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(200, 20);
            this.dtp_End.TabIndex = 6;
            // 
            // lbl_ApptStart
            // 
            this.lbl_ApptStart.AutoSize = true;
            this.lbl_ApptStart.Location = new System.Drawing.Point(354, 58);
            this.lbl_ApptStart.Name = "lbl_ApptStart";
            this.lbl_ApptStart.Size = new System.Drawing.Size(32, 13);
            this.lbl_ApptStart.TabIndex = 18;
            this.lbl_ApptStart.Text = "Start:";
            // 
            // lbl_ApptEnd
            // 
            this.lbl_ApptEnd.AutoSize = true;
            this.lbl_ApptEnd.Location = new System.Drawing.Point(357, 84);
            this.lbl_ApptEnd.Name = "lbl_ApptEnd";
            this.lbl_ApptEnd.Size = new System.Drawing.Size(29, 13);
            this.lbl_ApptEnd.TabIndex = 19;
            this.lbl_ApptEnd.Text = "End:";
            // 
            // tbox_ApptDescription
            // 
            this.tbox_ApptDescription.Location = new System.Drawing.Point(392, 193);
            this.tbox_ApptDescription.Multiline = true;
            this.tbox_ApptDescription.Name = "tbox_ApptDescription";
            this.tbox_ApptDescription.Size = new System.Drawing.Size(200, 99);
            this.tbox_ApptDescription.TabIndex = 9;
            // 
            // NewAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 413);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.apptPanel);
            this.Controls.Add(this.lbl_NewAppointment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewAppointment";
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
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.MaskedTextBox mbox_ApptLocation;
        private System.Windows.Forms.Label lbl_ApptLocation;
        private System.Windows.Forms.TextBox tbox_ApptDescription;
    }
}