namespace ScheduleBoss.Forms
{
    partial class ReportViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewer));
            this.lbl_ReportViewer = new System.Windows.Forms.Label();
            this.cbox_ReportType = new System.Windows.Forms.ComboBox();
            this.lbl_ReportType = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbox_ReportData = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ReportViewer
            // 
            this.lbl_ReportViewer.AutoSize = true;
            this.lbl_ReportViewer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReportViewer.Location = new System.Drawing.Point(12, 9);
            this.lbl_ReportViewer.Name = "lbl_ReportViewer";
            this.lbl_ReportViewer.Size = new System.Drawing.Size(138, 21);
            this.lbl_ReportViewer.TabIndex = 2;
            this.lbl_ReportViewer.Text = " REPORT VIEWER";
            // 
            // cbox_ReportType
            // 
            this.cbox_ReportType.FormattingEnabled = true;
            this.cbox_ReportType.Location = new System.Drawing.Point(490, 13);
            this.cbox_ReportType.Name = "cbox_ReportType";
            this.cbox_ReportType.Size = new System.Drawing.Size(183, 21);
            this.cbox_ReportType.TabIndex = 3;
            // 
            // lbl_ReportType
            // 
            this.lbl_ReportType.AutoSize = true;
            this.lbl_ReportType.Location = new System.Drawing.Point(415, 16);
            this.lbl_ReportType.Name = "lbl_ReportType";
            this.lbl_ReportType.Size = new System.Drawing.Size(69, 13);
            this.lbl_ReportType.TabIndex = 4;
            this.lbl_ReportType.Text = "Report Type:";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(673, 775);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(113, 43);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(689, 11);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(97, 22);
            this.btn_Run.TabIndex = 6;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbox_ReportData);
            this.panel1.Location = new System.Drawing.Point(16, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 704);
            this.panel1.TabIndex = 7;
            // 
            // tbox_ReportData
            // 
            this.tbox_ReportData.Location = new System.Drawing.Point(0, 3);
            this.tbox_ReportData.Multiline = true;
            this.tbox_ReportData.Name = "tbox_ReportData";
            this.tbox_ReportData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbox_ReportData.Size = new System.Drawing.Size(763, 698);
            this.tbox_ReportData.TabIndex = 0;
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 830);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_ReportType);
            this.Controls.Add(this.cbox_ReportType);
            this.Controls.Add(this.lbl_ReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCHEDULE BOSS - Report Viewer";
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ReportViewer;
        private System.Windows.Forms.ComboBox cbox_ReportType;
        private System.Windows.Forms.Label lbl_ReportType;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbox_ReportData;
    }
}