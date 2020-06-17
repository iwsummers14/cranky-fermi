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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl_ReportType = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Appointment Types - By Month",
            "Appointments - By Consultant",
            "Appointments - By Customer"});
            this.comboBox1.Location = new System.Drawing.Point(490, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 21);
            this.comboBox1.TabIndex = 3;
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
            this.btn_Close.Location = new System.Drawing.Point(674, 401);
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
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_ReportType);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbl_ReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportViewer";
            this.Text = "SCHEDULE BOSS - Report Viewer";
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ReportViewer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbl_ReportType;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Run;
    }
}