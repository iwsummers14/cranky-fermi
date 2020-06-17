namespace ScheduleBoss.Forms
{
    partial class LogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewer));
            this.lbl_LogViewer = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tbox_LogData = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_LogViewer
            // 
            this.lbl_LogViewer.AutoSize = true;
            this.lbl_LogViewer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LogViewer.Location = new System.Drawing.Point(12, 9);
            this.lbl_LogViewer.Name = "lbl_LogViewer";
            this.lbl_LogViewer.Size = new System.Drawing.Size(115, 21);
            this.lbl_LogViewer.TabIndex = 2;
            this.lbl_LogViewer.Text = "ACTIVITY LOG";
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
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // tbox_LogData
            // 
            this.tbox_LogData.Location = new System.Drawing.Point(23, 38);
            this.tbox_LogData.Multiline = true;
            this.tbox_LogData.Name = "tbox_LogData";
            this.tbox_LogData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbox_LogData.Size = new System.Drawing.Size(763, 353);
            this.tbox_LogData.TabIndex = 6;
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbox_LogData);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_LogViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogViewer";
            this.Text = "SCHEDULE BOSS - Log Viewer";
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_LogViewer;
        private System.Windows.Forms.Button btn_Close;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox tbox_LogData;
    }
}