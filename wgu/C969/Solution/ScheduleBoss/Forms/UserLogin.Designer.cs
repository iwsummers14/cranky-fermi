namespace ScheduleBoss.Forms
{
    partial class UserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            this.Label_LoginBanner = new System.Windows.Forms.Label();
            this.Label_BannerSubtext = new System.Windows.Forms.Label();
            this.mTextBox_username = new System.Windows.Forms.MaskedTextBox();
            this.mTextBox_password = new System.Windows.Forms.MaskedTextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label_username = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_LoginBanner
            // 
            resources.ApplyResources(this.Label_LoginBanner, "Label_LoginBanner");
            this.Label_LoginBanner.Name = "Label_LoginBanner";
            // 
            // Label_BannerSubtext
            // 
            resources.ApplyResources(this.Label_BannerSubtext, "Label_BannerSubtext");
            this.Label_BannerSubtext.Name = "Label_BannerSubtext";
            // 
            // mTextBox_username
            // 
            this.mTextBox_username.Culture = new System.Globalization.CultureInfo("");
            resources.ApplyResources(this.mTextBox_username, "mTextBox_username");
            this.mTextBox_username.Name = "mTextBox_username";
            // 
            // mTextBox_password
            // 
            this.mTextBox_password.Culture = new System.Globalization.CultureInfo("");
            resources.ApplyResources(this.mTextBox_password, "mTextBox_password");
            this.mTextBox_password.Name = "mTextBox_password";
            this.mTextBox_password.PasswordChar = '*';
            // 
            // btn_Login
            // 
            resources.ApplyResources(this.btn_Login, "btn_Login");
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label_username
            // 
            resources.ApplyResources(this.label_username, "label_username");
            this.label_username.Name = "label_username";
            // 
            // label_password
            // 
            resources.ApplyResources(this.label_password, "label_password");
            this.label_password.Name = "label_password";
            // 
            // UserLogin
            // 
            this.AcceptButton = this.btn_Login;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.mTextBox_password);
            this.Controls.Add(this.mTextBox_username);
            this.Controls.Add(this.Label_BannerSubtext);
            this.Controls.Add(this.Label_LoginBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserLogin";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserLogin_FormClosed);
            this.Load += new System.EventHandler(this.UserLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Label_LoginBanner;
        public System.Windows.Forms.Label Label_BannerSubtext;
        public System.Windows.Forms.MaskedTextBox mTextBox_username;
        public System.Windows.Forms.MaskedTextBox mTextBox_password;
        public System.Windows.Forms.Button btn_Login;
        public System.Windows.Forms.Button btn_Cancel;
        public System.Windows.Forms.Label label_username;
        public System.Windows.Forms.Label label_password;
    }
}