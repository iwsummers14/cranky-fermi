namespace MasterOfParts.Forms
{
    partial class fPartAdd
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
            this.AddPartTitle = new System.Windows.Forms.Label();
            this.AddPartCancel = new System.Windows.Forms.Button();
            this.AddPartSave = new System.Windows.Forms.Button();
            this.PartTypeLabel = new System.Windows.Forms.Label();
            this.PartMaxLabel = new System.Windows.Forms.Label();
            this.PartMinLabel = new System.Windows.Forms.Label();
            this.PartCostLabel = new System.Windows.Forms.Label();
            this.PartInventoryLabel = new System.Windows.Forms.Label();
            this.PartNameLabel = new System.Windows.Forms.Label();
            this.PartIDLabel = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.isOutsourcedRadio = new System.Windows.Forms.RadioButton();
            this.isInHouseRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // AddPartTitle
            // 
            this.AddPartTitle.AutoSize = true;
            this.AddPartTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartTitle.Location = new System.Drawing.Point(12, 9);
            this.AddPartTitle.Name = "AddPartTitle";
            this.AddPartTitle.Size = new System.Drawing.Size(84, 25);
            this.AddPartTitle.TabIndex = 37;
            this.AddPartTitle.Text = "Add Part";
            // 
            // AddPartCancel
            // 
            this.AddPartCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartCancel.Location = new System.Drawing.Point(264, 326);
            this.AddPartCancel.Name = "AddPartCancel";
            this.AddPartCancel.Size = new System.Drawing.Size(75, 23);
            this.AddPartCancel.TabIndex = 36;
            this.AddPartCancel.Text = "Cancel";
            this.AddPartCancel.UseVisualStyleBackColor = true;
            // 
            // AddPartSave
            // 
            this.AddPartSave.Enabled = false;
            this.AddPartSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartSave.Location = new System.Drawing.Point(182, 326);
            this.AddPartSave.Name = "AddPartSave";
            this.AddPartSave.Size = new System.Drawing.Size(75, 23);
            this.AddPartSave.TabIndex = 35;
            this.AddPartSave.Text = "Save";
            this.AddPartSave.UseVisualStyleBackColor = true;
            // 
            // PartTypeLabel
            // 
            this.PartTypeLabel.AutoSize = true;
            this.PartTypeLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartTypeLabel.Location = new System.Drawing.Point(80, 281);
            this.PartTypeLabel.Name = "PartTypeLabel";
            this.PartTypeLabel.Size = new System.Drawing.Size(61, 13);
            this.PartTypeLabel.TabIndex = 34;
            this.PartTypeLabel.Text = "MachineId";
            // 
            // PartMaxLabel
            // 
            this.PartMaxLabel.AutoSize = true;
            this.PartMaxLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartMaxLabel.Location = new System.Drawing.Point(234, 238);
            this.PartMaxLabel.Name = "PartMaxLabel";
            this.PartMaxLabel.Size = new System.Drawing.Size(27, 13);
            this.PartMaxLabel.TabIndex = 33;
            this.PartMaxLabel.Text = "Min";
            // 
            // PartMinLabel
            // 
            this.PartMinLabel.AutoSize = true;
            this.PartMinLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartMinLabel.Location = new System.Drawing.Point(110, 238);
            this.PartMinLabel.Name = "PartMinLabel";
            this.PartMinLabel.Size = new System.Drawing.Size(28, 13);
            this.PartMinLabel.TabIndex = 32;
            this.PartMinLabel.Text = "Max";
            // 
            // PartCostLabel
            // 
            this.PartCostLabel.AutoSize = true;
            this.PartCostLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartCostLabel.Location = new System.Drawing.Point(74, 197);
            this.PartCostLabel.Name = "PartCostLabel";
            this.PartCostLabel.Size = new System.Drawing.Size(64, 13);
            this.PartCostLabel.TabIndex = 31;
            this.PartCostLabel.Text = "Price / Cost";
            // 
            // PartInventoryLabel
            // 
            this.PartInventoryLabel.AutoSize = true;
            this.PartInventoryLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartInventoryLabel.Location = new System.Drawing.Point(86, 159);
            this.PartInventoryLabel.Name = "PartInventoryLabel";
            this.PartInventoryLabel.Size = new System.Drawing.Size(55, 13);
            this.PartInventoryLabel.TabIndex = 30;
            this.PartInventoryLabel.Text = "Inventory";
            // 
            // PartNameLabel
            // 
            this.PartNameLabel.AutoSize = true;
            this.PartNameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartNameLabel.Location = new System.Drawing.Point(102, 125);
            this.PartNameLabel.Name = "PartNameLabel";
            this.PartNameLabel.Size = new System.Drawing.Size(36, 13);
            this.PartNameLabel.TabIndex = 29;
            this.PartNameLabel.Text = "Name";
            // 
            // PartIDLabel
            // 
            this.PartIDLabel.AutoSize = true;
            this.PartIDLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartIDLabel.Location = new System.Drawing.Point(119, 94);
            this.PartIDLabel.Name = "PartIDLabel";
            this.PartIDLabel.Size = new System.Drawing.Size(18, 13);
            this.PartIDLabel.TabIndex = 28;
            this.PartIDLabel.Text = "ID";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(264, 235);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(60, 22);
            this.textBox7.TabIndex = 27;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(143, 278);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(86, 22);
            this.textBox6.TabIndex = 26;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(143, 156);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(130, 22);
            this.textBox5.TabIndex = 25;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(143, 194);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(130, 22);
            this.textBox4.TabIndex = 24;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(143, 235);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 22);
            this.textBox3.TabIndex = 23;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(143, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 22);
            this.textBox2.TabIndex = 22;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(143, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(130, 22);
            this.textBox1.TabIndex = 21;
            // 
            // isOutsourcedRadio
            // 
            this.isOutsourcedRadio.AutoSize = true;
            this.isOutsourcedRadio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isOutsourcedRadio.Location = new System.Drawing.Point(193, 50);
            this.isOutsourcedRadio.Name = "isOutsourcedRadio";
            this.isOutsourcedRadio.Size = new System.Drawing.Size(86, 17);
            this.isOutsourcedRadio.TabIndex = 20;
            this.isOutsourcedRadio.TabStop = true;
            this.isOutsourcedRadio.Text = "Outsourced";
            this.isOutsourcedRadio.UseVisualStyleBackColor = true;
            // 
            // isInHouseRadio
            // 
            this.isInHouseRadio.AutoSize = true;
            this.isInHouseRadio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isInHouseRadio.Location = new System.Drawing.Point(116, 50);
            this.isInHouseRadio.Name = "isInHouseRadio";
            this.isInHouseRadio.Size = new System.Drawing.Size(72, 17);
            this.isInHouseRadio.TabIndex = 19;
            this.isInHouseRadio.TabStop = true;
            this.isInHouseRadio.Text = "In-House";
            this.isInHouseRadio.UseVisualStyleBackColor = true;
            // 
            // fPartAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.AddPartTitle);
            this.Controls.Add(this.AddPartCancel);
            this.Controls.Add(this.AddPartSave);
            this.Controls.Add(this.PartTypeLabel);
            this.Controls.Add(this.PartMaxLabel);
            this.Controls.Add(this.PartMinLabel);
            this.Controls.Add(this.PartCostLabel);
            this.Controls.Add(this.PartInventoryLabel);
            this.Controls.Add(this.PartNameLabel);
            this.Controls.Add(this.PartIDLabel);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.isOutsourcedRadio);
            this.Controls.Add(this.isInHouseRadio);
            this.Name = "fPartAdd";
            this.Text = "MASTER OF PARTS - Add Part";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddPartTitle;
        private System.Windows.Forms.Button AddPartCancel;
        private System.Windows.Forms.Button AddPartSave;
        private System.Windows.Forms.Label PartTypeLabel;
        private System.Windows.Forms.Label PartMaxLabel;
        private System.Windows.Forms.Label PartMinLabel;
        private System.Windows.Forms.Label PartCostLabel;
        private System.Windows.Forms.Label PartInventoryLabel;
        private System.Windows.Forms.Label PartNameLabel;
        private System.Windows.Forms.Label PartIDLabel;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton isOutsourcedRadio;
        private System.Windows.Forms.RadioButton isInHouseRadio;
    }
}