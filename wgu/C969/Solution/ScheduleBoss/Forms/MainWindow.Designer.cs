namespace ScheduleBoss
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btn_AddAppointment = new System.Windows.Forms.Button();
            this.btn_ModifyAppointment = new System.Windows.Forms.Button();
            this.btn_AddCustomer = new System.Windows.Forms.Button();
            this.btn_ModifyCustomer = new System.Windows.Forms.Button();
            this.tabControlAppts = new System.Windows.Forms.TabControl();
            this.tabThisWeek = new System.Windows.Forms.TabPage();
            this.dataGridWeek = new System.Windows.Forms.DataGridView();
            this.tabThisMonth = new System.Windows.Forms.TabPage();
            this.dataGridMonth = new System.Windows.Forms.DataGridView();
            this.label_Appointments = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Contacts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSessionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Exit = new System.Windows.Forms.Label();
            this.lbl_DateRange = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_ViewLog = new System.Windows.Forms.Button();
            this.lbl_Reports = new System.Windows.Forms.Label();
            this.btn_ViewReports = new System.Windows.Forms.Button();
            this.tabControlAppts.SuspendLayout();
            this.tabThisWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWeek)).BeginInit();
            this.tabThisMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMonth)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_AddAppointment
            // 
            this.btn_AddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AddAppointment.Location = new System.Drawing.Point(3, 33);
            this.btn_AddAppointment.Name = "btn_AddAppointment";
            this.btn_AddAppointment.Size = new System.Drawing.Size(177, 44);
            this.btn_AddAppointment.TabIndex = 1;
            this.btn_AddAppointment.Text = "Add Appointment";
            this.btn_AddAppointment.UseVisualStyleBackColor = true;
            this.btn_AddAppointment.Click += new System.EventHandler(this.btn_AddAppointment_Click);
            // 
            // btn_ModifyAppointment
            // 
            this.btn_ModifyAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ModifyAppointment.Location = new System.Drawing.Point(3, 83);
            this.btn_ModifyAppointment.Name = "btn_ModifyAppointment";
            this.btn_ModifyAppointment.Size = new System.Drawing.Size(177, 48);
            this.btn_ModifyAppointment.TabIndex = 2;
            this.btn_ModifyAppointment.Text = "Modify Appointment";
            this.btn_ModifyAppointment.UseVisualStyleBackColor = true;
            this.btn_ModifyAppointment.Click += new System.EventHandler(this.btn_ModifyAppointment_Click);
            // 
            // btn_AddCustomer
            // 
            this.btn_AddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AddCustomer.Location = new System.Drawing.Point(3, 33);
            this.btn_AddCustomer.Name = "btn_AddCustomer";
            this.btn_AddCustomer.Size = new System.Drawing.Size(174, 48);
            this.btn_AddCustomer.TabIndex = 3;
            this.btn_AddCustomer.Text = "Add Customer";
            this.btn_AddCustomer.UseVisualStyleBackColor = true;
            this.btn_AddCustomer.Click += new System.EventHandler(this.btn_AddCustomer_Click);
            // 
            // btn_ModifyCustomer
            // 
            this.btn_ModifyCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ModifyCustomer.Location = new System.Drawing.Point(3, 87);
            this.btn_ModifyCustomer.Name = "btn_ModifyCustomer";
            this.btn_ModifyCustomer.Size = new System.Drawing.Size(174, 48);
            this.btn_ModifyCustomer.TabIndex = 4;
            this.btn_ModifyCustomer.Text = "Modify Customer";
            this.btn_ModifyCustomer.UseVisualStyleBackColor = true;
            this.btn_ModifyCustomer.Click += new System.EventHandler(this.btn_ModifyCustomer_Click);
            // 
            // tabControlAppts
            // 
            this.tabControlAppts.Controls.Add(this.tabThisWeek);
            this.tabControlAppts.Controls.Add(this.tabThisMonth);
            this.tabControlAppts.Location = new System.Drawing.Point(20, 81);
            this.tabControlAppts.Name = "tabControlAppts";
            this.tabControlAppts.SelectedIndex = 0;
            this.tabControlAppts.Size = new System.Drawing.Size(1121, 621);
            this.tabControlAppts.TabIndex = 5;
            this.tabControlAppts.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlAppts_Selected);
            // 
            // tabThisWeek
            // 
            this.tabThisWeek.Controls.Add(this.dataGridWeek);
            this.tabThisWeek.Location = new System.Drawing.Point(4, 22);
            this.tabThisWeek.Name = "tabThisWeek";
            this.tabThisWeek.Padding = new System.Windows.Forms.Padding(3);
            this.tabThisWeek.Size = new System.Drawing.Size(1113, 595);
            this.tabThisWeek.TabIndex = 0;
            this.tabThisWeek.Text = "This Week";
            this.tabThisWeek.UseVisualStyleBackColor = true;
            // 
            // dataGridWeek
            // 
            this.dataGridWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWeek.Location = new System.Drawing.Point(6, 6);
            this.dataGridWeek.Name = "dataGridWeek";
            this.dataGridWeek.Size = new System.Drawing.Size(1101, 583);
            this.dataGridWeek.TabIndex = 0;
            this.dataGridWeek.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridWeek_CellFormatting);
            // 
            // tabThisMonth
            // 
            this.tabThisMonth.Controls.Add(this.dataGridMonth);
            this.tabThisMonth.Location = new System.Drawing.Point(4, 22);
            this.tabThisMonth.Name = "tabThisMonth";
            this.tabThisMonth.Padding = new System.Windows.Forms.Padding(3);
            this.tabThisMonth.Size = new System.Drawing.Size(1113, 595);
            this.tabThisMonth.TabIndex = 1;
            this.tabThisMonth.Text = "This Month";
            this.tabThisMonth.UseVisualStyleBackColor = true;
            // 
            // dataGridMonth
            // 
            this.dataGridMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMonth.Location = new System.Drawing.Point(6, 6);
            this.dataGridMonth.Name = "dataGridMonth";
            this.dataGridMonth.Size = new System.Drawing.Size(1101, 583);
            this.dataGridMonth.TabIndex = 1;
            this.dataGridMonth.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridMonth_CellFormatting);
            // 
            // label_Appointments
            // 
            this.label_Appointments.AutoSize = true;
            this.label_Appointments.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Appointments.Location = new System.Drawing.Point(3, 0);
            this.label_Appointments.Name = "label_Appointments";
            this.label_Appointments.Size = new System.Drawing.Size(154, 30);
            this.label_Appointments.TabIndex = 6;
            this.label_Appointments.Text = "Appointments";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ModifyAppointment);
            this.panel1.Controls.Add(this.label_Appointments);
            this.panel1.Controls.Add(this.btn_AddAppointment);
            this.panel1.Location = new System.Drawing.Point(1150, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 141);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Contacts);
            this.panel2.Controls.Add(this.btn_AddCustomer);
            this.panel2.Controls.Add(this.btn_ModifyCustomer);
            this.panel2.Location = new System.Drawing.Point(1150, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 147);
            this.panel2.TabIndex = 8;
            // 
            // lbl_Contacts
            // 
            this.lbl_Contacts.AutoSize = true;
            this.lbl_Contacts.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Contacts.Location = new System.Drawing.Point(3, 0);
            this.lbl_Contacts.Name = "lbl_Contacts";
            this.lbl_Contacts.Size = new System.Drawing.Size(98, 30);
            this.lbl_Contacts.TabIndex = 7;
            this.lbl_Contacts.Text = "Contacts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 45);
            this.label1.TabIndex = 9;
            this.label1.Text = "SCHEDULE BOSS";
            // 
            // btn_Logout
            // 
            this.btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Logout.Location = new System.Drawing.Point(3, 33);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(176, 50);
            this.btn_Logout.TabIndex = 10;
            this.btn_Logout.Text = "Log Out";
            this.btn_Logout.UseVisualStyleBackColor = true;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSessionLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 703);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1345, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSessionLabel
            // 
            this.toolStripSessionLabel.Name = "toolStripSessionLabel";
            this.toolStripSessionLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_Exit);
            this.panel3.Controls.Add(this.btn_Logout);
            this.panel3.Location = new System.Drawing.Point(1147, 608);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 84);
            this.panel3.TabIndex = 12;
            // 
            // lbl_Exit
            // 
            this.lbl_Exit.AutoSize = true;
            this.lbl_Exit.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Exit.Location = new System.Drawing.Point(4, 0);
            this.lbl_Exit.Name = "lbl_Exit";
            this.lbl_Exit.Size = new System.Drawing.Size(50, 30);
            this.lbl_Exit.TabIndex = 8;
            this.lbl_Exit.Text = "Exit";
            // 
            // lbl_DateRange
            // 
            this.lbl_DateRange.AutoSize = true;
            this.lbl_DateRange.Location = new System.Drawing.Point(910, 86);
            this.lbl_DateRange.Name = "lbl_DateRange";
            this.lbl_DateRange.Size = new System.Drawing.Size(96, 13);
            this.lbl_DateRange.TabIndex = 13;
            this.lbl_DateRange.Text = "Displaying Dates:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_ViewLog);
            this.panel4.Controls.Add(this.lbl_Reports);
            this.panel4.Controls.Add(this.btn_ViewReports);
            this.panel4.Location = new System.Drawing.Point(1150, 402);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 151);
            this.panel4.TabIndex = 9;
            // 
            // btn_ViewLog
            // 
            this.btn_ViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ViewLog.Location = new System.Drawing.Point(3, 92);
            this.btn_ViewLog.Name = "btn_ViewLog";
            this.btn_ViewLog.Size = new System.Drawing.Size(174, 48);
            this.btn_ViewLog.TabIndex = 8;
            this.btn_ViewLog.Text = "View Activity Log";
            this.btn_ViewLog.UseVisualStyleBackColor = true;
            this.btn_ViewLog.Click += new System.EventHandler(this.btn_ViewLog_Click);
            // 
            // lbl_Reports
            // 
            this.lbl_Reports.AutoSize = true;
            this.lbl_Reports.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Reports.Location = new System.Drawing.Point(3, 0);
            this.lbl_Reports.Name = "lbl_Reports";
            this.lbl_Reports.Size = new System.Drawing.Size(89, 30);
            this.lbl_Reports.TabIndex = 7;
            this.lbl_Reports.Text = "Reports";
            // 
            // btn_ViewReports
            // 
            this.btn_ViewReports.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ViewReports.Location = new System.Drawing.Point(3, 38);
            this.btn_ViewReports.Name = "btn_ViewReports";
            this.btn_ViewReports.Size = new System.Drawing.Size(174, 48);
            this.btn_ViewReports.TabIndex = 3;
            this.btn_ViewReports.Text = "View Reports";
            this.btn_ViewReports.UseVisualStyleBackColor = true;
            this.btn_ViewReports.Click += new System.EventHandler(this.btn_ViewReports_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 725);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbl_DateRange);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlAppts);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCHEDULE BOSS - Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControlAppts.ResumeLayout(false);
            this.tabThisWeek.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWeek)).EndInit();
            this.tabThisMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMonth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AddAppointment;
        private System.Windows.Forms.Button btn_ModifyAppointment;
        private System.Windows.Forms.Button btn_AddCustomer;
        private System.Windows.Forms.Button btn_ModifyCustomer;
        private System.Windows.Forms.TabControl tabControlAppts;
        private System.Windows.Forms.TabPage tabThisWeek;
        private System.Windows.Forms.DataGridView dataGridWeek;
        private System.Windows.Forms.TabPage tabThisMonth;
        private System.Windows.Forms.Label label_Appointments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Contacts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSessionLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_Exit;
        private System.Windows.Forms.DataGridView dataGridMonth;
        private System.Windows.Forms.Label lbl_DateRange;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_ViewLog;
        private System.Windows.Forms.Label lbl_Reports;
        private System.Windows.Forms.Button btn_ViewReports;
    }
}

