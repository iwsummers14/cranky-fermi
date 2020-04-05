namespace MasterOfParts.Forms
{
    partial class fProductAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fProductAdd));
            this.ProductId = new System.Windows.Forms.TextBox();
            this.ProductName = new System.Windows.Forms.TextBox();
            this.ProductInventory = new System.Windows.Forms.TextBox();
            this.ProductCost = new System.Windows.Forms.TextBox();
            this.ProductMax = new System.Windows.Forms.TextBox();
            this.ProductMin = new System.Windows.Forms.TextBox();
            this.labelPartId = new System.Windows.Forms.Label();
            this.labelPartName = new System.Windows.Forms.Label();
            this.labelPartInventory = new System.Windows.Forms.Label();
            this.labelPartCost = new System.Windows.Forms.Label();
            this.labelPartMax = new System.Windows.Forms.Label();
            this.labelPartMin = new System.Windows.Forms.Label();
            this.labelAddProduct = new System.Windows.Forms.Label();
            this.labelPartGridView = new System.Windows.Forms.Label();
            this.labelAssociatedGridView = new System.Windows.Forms.Label();
            this.GridViewAllParts = new System.Windows.Forms.DataGridView();
            this.GridViewAssociatedParts = new System.Windows.Forms.DataGridView();
            this.SaveProduct = new System.Windows.Forms.Button();
            this.DeletePart = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.AddPart = new System.Windows.Forms.Button();
            this.SearchPart = new System.Windows.Forms.Button();
            this.SearchPartInput = new System.Windows.Forms.TextBox();
            this.errorProviderName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderInventory = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderCost = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderMax = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderMin = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAllParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAssociatedParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMin)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductId
            // 
            this.ProductId.Enabled = false;
            this.ProductId.Location = new System.Drawing.Point(106, 202);
            this.ProductId.Name = "ProductId";
            this.ProductId.Size = new System.Drawing.Size(153, 20);
            this.ProductId.TabIndex = 0;
            // 
            // ProductName
            // 
            this.ProductName.Location = new System.Drawing.Point(106, 245);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(153, 20);
            this.ProductName.TabIndex = 1;
            this.ProductName.Validating += new System.ComponentModel.CancelEventHandler(this.ProductName_Validating);
            // 
            // ProductInventory
            // 
            this.ProductInventory.Location = new System.Drawing.Point(106, 284);
            this.ProductInventory.Name = "ProductInventory";
            this.ProductInventory.Size = new System.Drawing.Size(153, 20);
            this.ProductInventory.TabIndex = 2;
            this.ProductInventory.Validating += new System.ComponentModel.CancelEventHandler(this.ProductInventory_Validating);
            // 
            // ProductCost
            // 
            this.ProductCost.Location = new System.Drawing.Point(106, 326);
            this.ProductCost.Name = "ProductCost";
            this.ProductCost.Size = new System.Drawing.Size(153, 20);
            this.ProductCost.TabIndex = 3;
            this.ProductCost.Validating += new System.ComponentModel.CancelEventHandler(this.ProductCost_Validating);
            // 
            // ProductMax
            // 
            this.ProductMax.Location = new System.Drawing.Point(97, 367);
            this.ProductMax.Name = "ProductMax";
            this.ProductMax.Size = new System.Drawing.Size(76, 20);
            this.ProductMax.TabIndex = 4;
            this.ProductMax.Validating += new System.ComponentModel.CancelEventHandler(this.ProductMax_Validating);
            // 
            // ProductMin
            // 
            this.ProductMin.Location = new System.Drawing.Point(236, 367);
            this.ProductMin.Name = "ProductMin";
            this.ProductMin.Size = new System.Drawing.Size(76, 20);
            this.ProductMin.TabIndex = 5;
            this.ProductMin.Validating += new System.ComponentModel.CancelEventHandler(this.ProductMin_Validating);
            // 
            // labelPartId
            // 
            this.labelPartId.AutoSize = true;
            this.labelPartId.Location = new System.Drawing.Point(73, 205);
            this.labelPartId.Name = "labelPartId";
            this.labelPartId.Size = new System.Drawing.Size(18, 13);
            this.labelPartId.TabIndex = 6;
            this.labelPartId.Text = "ID";
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Location = new System.Drawing.Point(56, 248);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(35, 13);
            this.labelPartName.TabIndex = 7;
            this.labelPartName.Text = "Name";
            // 
            // labelPartInventory
            // 
            this.labelPartInventory.AutoSize = true;
            this.labelPartInventory.Location = new System.Drawing.Point(40, 287);
            this.labelPartInventory.Name = "labelPartInventory";
            this.labelPartInventory.Size = new System.Drawing.Size(51, 13);
            this.labelPartInventory.TabIndex = 8;
            this.labelPartInventory.Text = "Inventory";
            // 
            // labelPartCost
            // 
            this.labelPartCost.AutoSize = true;
            this.labelPartCost.Location = new System.Drawing.Point(60, 329);
            this.labelPartCost.Name = "labelPartCost";
            this.labelPartCost.Size = new System.Drawing.Size(31, 13);
            this.labelPartCost.TabIndex = 9;
            this.labelPartCost.Text = "Price";
            // 
            // labelPartMax
            // 
            this.labelPartMax.AutoSize = true;
            this.labelPartMax.Location = new System.Drawing.Point(64, 370);
            this.labelPartMax.Name = "labelPartMax";
            this.labelPartMax.Size = new System.Drawing.Size(27, 13);
            this.labelPartMax.TabIndex = 10;
            this.labelPartMax.Text = "Max";
            // 
            // labelPartMin
            // 
            this.labelPartMin.AutoSize = true;
            this.labelPartMin.Location = new System.Drawing.Point(206, 370);
            this.labelPartMin.Name = "labelPartMin";
            this.labelPartMin.Size = new System.Drawing.Size(24, 13);
            this.labelPartMin.TabIndex = 11;
            this.labelPartMin.Text = "Min";
            // 
            // labelAddProduct
            // 
            this.labelAddProduct.AutoSize = true;
            this.labelAddProduct.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddProduct.Location = new System.Drawing.Point(44, 34);
            this.labelAddProduct.Name = "labelAddProduct";
            this.labelAddProduct.Size = new System.Drawing.Size(129, 30);
            this.labelAddProduct.TabIndex = 12;
            this.labelAddProduct.Text = "Add Product";
            // 
            // labelPartGridView
            // 
            this.labelPartGridView.AutoSize = true;
            this.labelPartGridView.Location = new System.Drawing.Point(377, 70);
            this.labelPartGridView.Name = "labelPartGridView";
            this.labelPartGridView.Size = new System.Drawing.Size(96, 13);
            this.labelPartGridView.TabIndex = 13;
            this.labelPartGridView.Text = "All Candidate Parts";
            // 
            // labelAssociatedGridView
            // 
            this.labelAssociatedGridView.AutoSize = true;
            this.labelAssociatedGridView.Location = new System.Drawing.Point(377, 349);
            this.labelAssociatedGridView.Name = "labelAssociatedGridView";
            this.labelAssociatedGridView.Size = new System.Drawing.Size(174, 13);
            this.labelAssociatedGridView.TabIndex = 14;
            this.labelAssociatedGridView.Text = "Parts Associated With This Product";
            // 
            // GridViewAllParts
            // 
            this.GridViewAllParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewAllParts.Location = new System.Drawing.Point(375, 96);
            this.GridViewAllParts.Name = "GridViewAllParts";
            this.GridViewAllParts.Size = new System.Drawing.Size(497, 208);
            this.GridViewAllParts.TabIndex = 15;
            // 
            // GridViewAssociatedParts
            // 
            this.GridViewAssociatedParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewAssociatedParts.Location = new System.Drawing.Point(375, 382);
            this.GridViewAssociatedParts.Name = "GridViewAssociatedParts";
            this.GridViewAssociatedParts.Size = new System.Drawing.Size(497, 182);
            this.GridViewAssociatedParts.TabIndex = 16;
            // 
            // SaveProduct
            // 
            this.SaveProduct.Location = new System.Drawing.Point(746, 627);
            this.SaveProduct.Name = "SaveProduct";
            this.SaveProduct.Size = new System.Drawing.Size(60, 40);
            this.SaveProduct.TabIndex = 17;
            this.SaveProduct.Text = "Save";
            this.SaveProduct.UseVisualStyleBackColor = true;
            this.SaveProduct.Click += new System.EventHandler(this.SaveProduct_Click);
            // 
            // DeletePart
            // 
            this.DeletePart.Location = new System.Drawing.Point(812, 581);
            this.DeletePart.Name = "DeletePart";
            this.DeletePart.Size = new System.Drawing.Size(60, 40);
            this.DeletePart.TabIndex = 18;
            this.DeletePart.Text = "Delete";
            this.DeletePart.UseVisualStyleBackColor = true;
            this.DeletePart.Click += new System.EventHandler(this.DeletePart_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(812, 627);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(60, 40);
            this.Cancel.TabIndex = 19;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // AddPart
            // 
            this.AddPart.Location = new System.Drawing.Point(812, 322);
            this.AddPart.Name = "AddPart";
            this.AddPart.Size = new System.Drawing.Size(60, 40);
            this.AddPart.TabIndex = 20;
            this.AddPart.Text = "Add";
            this.AddPart.UseVisualStyleBackColor = true;
            this.AddPart.Click += new System.EventHandler(this.AddPart_Click);
            // 
            // SearchPart
            // 
            this.SearchPart.Location = new System.Drawing.Point(570, 41);
            this.SearchPart.Name = "SearchPart";
            this.SearchPart.Size = new System.Drawing.Size(73, 22);
            this.SearchPart.TabIndex = 21;
            this.SearchPart.Text = "Search";
            this.SearchPart.UseVisualStyleBackColor = true;
            this.SearchPart.Click += new System.EventHandler(this.SearchPart_Click);
            // 
            // SearchPartInput
            // 
            this.SearchPartInput.Location = new System.Drawing.Point(649, 41);
            this.SearchPartInput.Name = "SearchPartInput";
            this.SearchPartInput.Size = new System.Drawing.Size(223, 20);
            this.SearchPartInput.TabIndex = 22;
            // 
            // errorProviderName
            // 
            this.errorProviderName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderName.ContainerControl = this;
            // 
            // errorProviderInventory
            // 
            this.errorProviderInventory.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderInventory.ContainerControl = this;
            // 
            // errorProviderCost
            // 
            this.errorProviderCost.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCost.ContainerControl = this;
            // 
            // errorProviderMax
            // 
            this.errorProviderMax.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderMax.ContainerControl = this;
            // 
            // errorProviderMin
            // 
            this.errorProviderMin.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderMin.ContainerControl = this;
            // 
            // fProductAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(892, 680);
            this.Controls.Add(this.SearchPartInput);
            this.Controls.Add(this.SearchPart);
            this.Controls.Add(this.AddPart);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.DeletePart);
            this.Controls.Add(this.SaveProduct);
            this.Controls.Add(this.GridViewAssociatedParts);
            this.Controls.Add(this.GridViewAllParts);
            this.Controls.Add(this.labelAssociatedGridView);
            this.Controls.Add(this.labelPartGridView);
            this.Controls.Add(this.labelAddProduct);
            this.Controls.Add(this.labelPartMin);
            this.Controls.Add(this.labelPartMax);
            this.Controls.Add(this.labelPartCost);
            this.Controls.Add(this.labelPartInventory);
            this.Controls.Add(this.labelPartName);
            this.Controls.Add(this.labelPartId);
            this.Controls.Add(this.ProductMin);
            this.Controls.Add(this.ProductMax);
            this.Controls.Add(this.ProductCost);
            this.Controls.Add(this.ProductInventory);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.ProductId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fProductAdd";
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.fProductAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAllParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAssociatedParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProductId;
        private System.Windows.Forms.TextBox ProductName;
        private System.Windows.Forms.TextBox ProductInventory;
        private System.Windows.Forms.TextBox ProductCost;
        private System.Windows.Forms.TextBox ProductMax;
        private System.Windows.Forms.TextBox ProductMin;
        private System.Windows.Forms.Label labelPartId;
        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.Label labelPartInventory;
        private System.Windows.Forms.Label labelPartCost;
        private System.Windows.Forms.Label labelPartMax;
        private System.Windows.Forms.Label labelPartMin;
        private System.Windows.Forms.Label labelAddProduct;
        private System.Windows.Forms.Label labelPartGridView;
        private System.Windows.Forms.Label labelAssociatedGridView;
        private System.Windows.Forms.DataGridView GridViewAllParts;
        private System.Windows.Forms.DataGridView GridViewAssociatedParts;
        private System.Windows.Forms.Button SaveProduct;
        private System.Windows.Forms.Button DeletePart;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button AddPart;
        private System.Windows.Forms.Button SearchPart;
        private System.Windows.Forms.TextBox SearchPartInput;
        private System.Windows.Forms.ErrorProvider errorProviderName;
        private System.Windows.Forms.ErrorProvider errorProviderInventory;
        private System.Windows.Forms.ErrorProvider errorProviderCost;
        private System.Windows.Forms.ErrorProvider errorProviderMax;
        private System.Windows.Forms.ErrorProvider errorProviderMin;
    }
}