namespace MasterOfParts.Forms
{
    partial class fPartModify
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPartModify));
            this.ModifyPartTitle = new System.Windows.Forms.Label();
            this.ModifyPartCancel = new System.Windows.Forms.Button();
            this.ModifyPartSave = new System.Windows.Forms.Button();
            this.PartTypeLabel = new System.Windows.Forms.Label();
            this.PartMaxLabel = new System.Windows.Forms.Label();
            this.PartMinLabel = new System.Windows.Forms.Label();
            this.PartCostLabel = new System.Windows.Forms.Label();
            this.PartInventoryLabel = new System.Windows.Forms.Label();
            this.PartNameLabel = new System.Windows.Forms.Label();
            this.PartIDLabel = new System.Windows.Forms.Label();
            this.PartMin = new System.Windows.Forms.TextBox();
            this.PartSupplement = new System.Windows.Forms.TextBox();
            this.PartInventory = new System.Windows.Forms.TextBox();
            this.PartCost = new System.Windows.Forms.TextBox();
            this.PartMax = new System.Windows.Forms.TextBox();
            this.PartName = new System.Windows.Forms.TextBox();
            this.PartId = new System.Windows.Forms.TextBox();
            this.isOutsourcedRadio = new System.Windows.Forms.RadioButton();
            this.isInHouseRadio = new System.Windows.Forms.RadioButton();
            this.errorProviderName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderInventory = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderCost = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderMax = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderMin = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderSupplement = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSupplement)).BeginInit();
            this.SuspendLayout();
            // 
            // ModifyPartTitle
            // 
            this.ModifyPartTitle.AutoSize = true;
            this.ModifyPartTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyPartTitle.Location = new System.Drawing.Point(12, 9);
            this.ModifyPartTitle.Name = "ModifyPartTitle";
            this.ModifyPartTitle.Size = new System.Drawing.Size(109, 25);
            this.ModifyPartTitle.TabIndex = 37;
            this.ModifyPartTitle.Text = "Modify Part";
            // 
            // ModifyPartCancel
            // 
            this.ModifyPartCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyPartCancel.Location = new System.Drawing.Point(264, 326);
            this.ModifyPartCancel.Name = "ModifyPartCancel";
            this.ModifyPartCancel.Size = new System.Drawing.Size(75, 23);
            this.ModifyPartCancel.TabIndex = 10;
            this.ModifyPartCancel.Text = "Cancel";
            this.ModifyPartCancel.UseVisualStyleBackColor = true;
            this.ModifyPartCancel.Click += new System.EventHandler(this.ModifyPartCancel_Click);
            // 
            // ModifyPartSave
            // 
            this.ModifyPartSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyPartSave.Location = new System.Drawing.Point(182, 326);
            this.ModifyPartSave.Name = "ModifyPartSave";
            this.ModifyPartSave.Size = new System.Drawing.Size(75, 23);
            this.ModifyPartSave.TabIndex = 9;
            this.ModifyPartSave.Text = "Save";
            this.ModifyPartSave.UseVisualStyleBackColor = true;
            this.ModifyPartSave.Click += new System.EventHandler(this.ModifyPartSave_Click);
            // 
            // PartTypeLabel
            // 
            this.PartTypeLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartTypeLabel.Location = new System.Drawing.Point(40, 281);
            this.PartTypeLabel.Name = "PartTypeLabel";
            this.PartTypeLabel.Size = new System.Drawing.Size(101, 13);
            this.PartTypeLabel.TabIndex = 34;
            this.PartTypeLabel.Text = "MachineId";
            this.PartTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // PartMin
            // 
            this.PartMin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartMin.Location = new System.Drawing.Point(264, 235);
            this.PartMin.Name = "PartMin";
            this.PartMin.Size = new System.Drawing.Size(60, 22);
            this.PartMin.TabIndex = 7;
            this.PartMin.Validating += new System.ComponentModel.CancelEventHandler(this.PartMin_Validating);
            // 
            // PartSupplement
            // 
            this.PartSupplement.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartSupplement.Location = new System.Drawing.Point(143, 278);
            this.PartSupplement.Name = "PartSupplement";
            this.PartSupplement.Size = new System.Drawing.Size(86, 22);
            this.PartSupplement.TabIndex = 8;
            this.PartSupplement.Validating += new System.ComponentModel.CancelEventHandler(this.PartSupplement_Validating);
            // 
            // PartInventory
            // 
            this.PartInventory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartInventory.Location = new System.Drawing.Point(143, 156);
            this.PartInventory.Name = "PartInventory";
            this.PartInventory.Size = new System.Drawing.Size(130, 22);
            this.PartInventory.TabIndex = 4;
            this.PartInventory.Validating += new System.ComponentModel.CancelEventHandler(this.PartInventory_Validating);
            // 
            // PartCost
            // 
            this.PartCost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartCost.Location = new System.Drawing.Point(143, 194);
            this.PartCost.Name = "PartCost";
            this.PartCost.Size = new System.Drawing.Size(130, 22);
            this.PartCost.TabIndex = 5;
            this.PartCost.Validating += new System.ComponentModel.CancelEventHandler(this.PartCost_Validating);
            // 
            // PartMax
            // 
            this.PartMax.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartMax.Location = new System.Drawing.Point(143, 235);
            this.PartMax.Name = "PartMax";
            this.PartMax.Size = new System.Drawing.Size(59, 22);
            this.PartMax.TabIndex = 6;
            this.PartMax.Validating += new System.ComponentModel.CancelEventHandler(this.PartMax_Validating);
            // 
            // PartName
            // 
            this.PartName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartName.Location = new System.Drawing.Point(143, 122);
            this.PartName.Name = "PartName";
            this.PartName.Size = new System.Drawing.Size(130, 22);
            this.PartName.TabIndex = 3;
            this.PartName.Validating += new System.ComponentModel.CancelEventHandler(this.PartName_Validating);
            // 
            // PartId
            // 
            this.PartId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartId.Location = new System.Drawing.Point(143, 91);
            this.PartId.Name = "PartId";
            this.PartId.ReadOnly = true;
            this.PartId.Size = new System.Drawing.Size(130, 22);
            this.PartId.TabIndex = 21;
            // 
            // isOutsourcedRadio
            // 
            this.isOutsourcedRadio.AutoSize = true;
            this.isOutsourcedRadio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isOutsourcedRadio.Location = new System.Drawing.Point(193, 50);
            this.isOutsourcedRadio.Name = "isOutsourcedRadio";
            this.isOutsourcedRadio.Size = new System.Drawing.Size(86, 17);
            this.isOutsourcedRadio.TabIndex = 2;
            this.isOutsourcedRadio.TabStop = true;
            this.isOutsourcedRadio.Text = "Outsourced";
            this.isOutsourcedRadio.UseVisualStyleBackColor = true;
            this.isOutsourcedRadio.CheckedChanged += new System.EventHandler(this.isOutsourcedRadio_CheckedChanged);
            // 
            // isInHouseRadio
            // 
            this.isInHouseRadio.AutoSize = true;
            this.isInHouseRadio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isInHouseRadio.Location = new System.Drawing.Point(116, 50);
            this.isInHouseRadio.Name = "isInHouseRadio";
            this.isInHouseRadio.Size = new System.Drawing.Size(72, 17);
            this.isInHouseRadio.TabIndex = 1;
            this.isInHouseRadio.TabStop = true;
            this.isInHouseRadio.Text = "In-House";
            this.isInHouseRadio.UseVisualStyleBackColor = true;
            this.isInHouseRadio.CheckedChanged += new System.EventHandler(this.isInHouseRadio_CheckedChanged);
            // 
            // errorProviderName
            // 
            this.errorProviderName.ContainerControl = this;
            // 
            // errorProviderInventory
            // 
            this.errorProviderInventory.ContainerControl = this;
            // 
            // errorProviderCost
            // 
            this.errorProviderCost.ContainerControl = this;
            // 
            // errorProviderMax
            // 
            this.errorProviderMax.ContainerControl = this;
            // 
            // errorProviderMin
            // 
            this.errorProviderMin.ContainerControl = this;
            // 
            // errorProviderSupplement
            // 
            this.errorProviderSupplement.ContainerControl = this;
            // 
            // fPartModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.ModifyPartTitle);
            this.Controls.Add(this.ModifyPartCancel);
            this.Controls.Add(this.ModifyPartSave);
            this.Controls.Add(this.PartTypeLabel);
            this.Controls.Add(this.PartMaxLabel);
            this.Controls.Add(this.PartMinLabel);
            this.Controls.Add(this.PartCostLabel);
            this.Controls.Add(this.PartInventoryLabel);
            this.Controls.Add(this.PartNameLabel);
            this.Controls.Add(this.PartIDLabel);
            this.Controls.Add(this.PartMin);
            this.Controls.Add(this.PartSupplement);
            this.Controls.Add(this.PartInventory);
            this.Controls.Add(this.PartCost);
            this.Controls.Add(this.PartMax);
            this.Controls.Add(this.PartName);
            this.Controls.Add(this.PartId);
            this.Controls.Add(this.isOutsourcedRadio);
            this.Controls.Add(this.isInHouseRadio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fPartModify";
            this.Text = "fPartModify";
            this.Load += new System.EventHandler(this.fPartModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSupplement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ModifyPartTitle;
        private System.Windows.Forms.Button ModifyPartCancel;
        private System.Windows.Forms.Button ModifyPartSave;
        private System.Windows.Forms.Label PartTypeLabel;
        private System.Windows.Forms.Label PartMaxLabel;
        private System.Windows.Forms.Label PartMinLabel;
        private System.Windows.Forms.Label PartCostLabel;
        private System.Windows.Forms.Label PartInventoryLabel;
        private System.Windows.Forms.Label PartNameLabel;
        private System.Windows.Forms.Label PartIDLabel;
        private System.Windows.Forms.TextBox PartMin;
        private System.Windows.Forms.TextBox PartSupplement;
        private System.Windows.Forms.TextBox PartInventory;
        private System.Windows.Forms.TextBox PartCost;
        private System.Windows.Forms.TextBox PartMax;
        private System.Windows.Forms.TextBox PartName;
        private System.Windows.Forms.TextBox PartId;
        private System.Windows.Forms.RadioButton isOutsourcedRadio;
        private System.Windows.Forms.RadioButton isInHouseRadio;
        private System.Windows.Forms.ErrorProvider errorProviderName;
        private System.Windows.Forms.ErrorProvider errorProviderInventory;
        private System.Windows.Forms.ErrorProvider errorProviderCost;
        private System.Windows.Forms.ErrorProvider errorProviderMax;
        private System.Windows.Forms.ErrorProvider errorProviderMin;
        private System.Windows.Forms.ErrorProvider errorProviderSupplement;
    }
}