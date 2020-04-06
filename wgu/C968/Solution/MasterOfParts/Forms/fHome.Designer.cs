namespace MasterOfParts
{
    partial class fHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHome));
            this.HomeTitle = new System.Windows.Forms.Label();
            this.SearchPartInput = new System.Windows.Forms.TextBox();
            this.SearchPart = new System.Windows.Forms.Button();
            this.PartsLabel = new System.Windows.Forms.Label();
            this.AddPart = new System.Windows.Forms.Button();
            this.ModifyPart = new System.Windows.Forms.Button();
            this.DeletePart = new System.Windows.Forms.Button();
            this.AddProduct = new System.Windows.Forms.Button();
            this.ProductsLabel = new System.Windows.Forms.Label();
            this.SearchProduct = new System.Windows.Forms.Button();
            this.ModifyProduct = new System.Windows.Forms.Button();
            this.DeleteProduct = new System.Windows.Forms.Button();
            this.SearchProductInput = new System.Windows.Forms.TextBox();
            this.ExitApp = new System.Windows.Forms.Button();
            this.GridViewProduct = new System.Windows.Forms.DataGridView();
            this.GridViewPart = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPart)).BeginInit();
            this.SuspendLayout();
            // 
            // HomeTitle
            // 
            this.HomeTitle.AutoSize = true;
            this.HomeTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeTitle.Location = new System.Drawing.Point(26, 22);
            this.HomeTitle.Name = "HomeTitle";
            this.HomeTitle.Size = new System.Drawing.Size(349, 32);
            this.HomeTitle.TabIndex = 0;
            this.HomeTitle.Text = "Inventory Management System";
            // 
            // SearchPartInput
            // 
            this.SearchPartInput.Location = new System.Drawing.Point(228, 91);
            this.SearchPartInput.Name = "SearchPartInput";
            this.SearchPartInput.Size = new System.Drawing.Size(259, 20);
            this.SearchPartInput.TabIndex = 1;
            // 
            // SearchPart
            // 
            this.SearchPart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchPart.Location = new System.Drawing.Point(147, 89);
            this.SearchPart.Name = "SearchPart";
            this.SearchPart.Size = new System.Drawing.Size(75, 22);
            this.SearchPart.TabIndex = 2;
            this.SearchPart.Text = "Search";
            this.SearchPart.UseVisualStyleBackColor = true;
            this.SearchPart.Click += new System.EventHandler(this.SearchPart_Click);
            // 
            // PartsLabel
            // 
            this.PartsLabel.AutoSize = true;
            this.PartsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartsLabel.Location = new System.Drawing.Point(34, 116);
            this.PartsLabel.Name = "PartsLabel";
            this.PartsLabel.Size = new System.Drawing.Size(53, 25);
            this.PartsLabel.TabIndex = 3;
            this.PartsLabel.Text = "Parts";
            // 
            // AddPart
            // 
            this.AddPart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPart.Location = new System.Drawing.Point(250, 419);
            this.AddPart.Name = "AddPart";
            this.AddPart.Size = new System.Drawing.Size(75, 23);
            this.AddPart.TabIndex = 4;
            this.AddPart.Text = "Add";
            this.AddPart.UseVisualStyleBackColor = true;
            this.AddPart.Click += new System.EventHandler(this.AddPart_Click);
            // 
            // ModifyPart
            // 
            this.ModifyPart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyPart.Location = new System.Drawing.Point(331, 419);
            this.ModifyPart.Name = "ModifyPart";
            this.ModifyPart.Size = new System.Drawing.Size(75, 23);
            this.ModifyPart.TabIndex = 5;
            this.ModifyPart.Text = "Modify";
            this.ModifyPart.UseVisualStyleBackColor = true;
            this.ModifyPart.Click += new System.EventHandler(this.ModifyPart_Click);
            // 
            // DeletePart
            // 
            this.DeletePart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePart.Location = new System.Drawing.Point(412, 419);
            this.DeletePart.Name = "DeletePart";
            this.DeletePart.Size = new System.Drawing.Size(75, 23);
            this.DeletePart.TabIndex = 6;
            this.DeletePart.Text = "Delete";
            this.DeletePart.UseVisualStyleBackColor = true;
            this.DeletePart.Click += new System.EventHandler(this.DeletePart_Click);
            // 
            // AddProduct
            // 
            this.AddProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProduct.Location = new System.Drawing.Point(790, 419);
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(75, 23);
            this.AddProduct.TabIndex = 7;
            this.AddProduct.Text = "Add";
            this.AddProduct.UseVisualStyleBackColor = true;
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // ProductsLabel
            // 
            this.ProductsLabel.AutoSize = true;
            this.ProductsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsLabel.Location = new System.Drawing.Point(567, 116);
            this.ProductsLabel.Name = "ProductsLabel";
            this.ProductsLabel.Size = new System.Drawing.Size(86, 25);
            this.ProductsLabel.TabIndex = 8;
            this.ProductsLabel.Text = "Products";
            // 
            // SearchProduct
            // 
            this.SearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchProduct.Location = new System.Drawing.Point(689, 89);
            this.SearchProduct.Name = "SearchProduct";
            this.SearchProduct.Size = new System.Drawing.Size(75, 22);
            this.SearchProduct.TabIndex = 9;
            this.SearchProduct.Text = "Search";
            this.SearchProduct.UseVisualStyleBackColor = true;
            this.SearchProduct.Click += new System.EventHandler(this.SearchProduct_Click);
            // 
            // ModifyProduct
            // 
            this.ModifyProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyProduct.Location = new System.Drawing.Point(872, 419);
            this.ModifyProduct.Name = "ModifyProduct";
            this.ModifyProduct.Size = new System.Drawing.Size(75, 23);
            this.ModifyProduct.TabIndex = 10;
            this.ModifyProduct.Text = "Modify";
            this.ModifyProduct.UseVisualStyleBackColor = true;
            this.ModifyProduct.Click += new System.EventHandler(this.ModifyProduct_Click);
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteProduct.Location = new System.Drawing.Point(954, 419);
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Size = new System.Drawing.Size(75, 23);
            this.DeleteProduct.TabIndex = 11;
            this.DeleteProduct.Text = "Delete";
            this.DeleteProduct.UseVisualStyleBackColor = true;
            this.DeleteProduct.Click += new System.EventHandler(this.DeleteProduct_Click);
            // 
            // SearchProductInput
            // 
            this.SearchProductInput.Location = new System.Drawing.Point(770, 91);
            this.SearchProductInput.Name = "SearchProductInput";
            this.SearchProductInput.Size = new System.Drawing.Size(259, 20);
            this.SearchProductInput.TabIndex = 12;
            // 
            // ExitApp
            // 
            this.ExitApp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitApp.Location = new System.Drawing.Point(955, 457);
            this.ExitApp.Name = "ExitApp";
            this.ExitApp.Size = new System.Drawing.Size(74, 37);
            this.ExitApp.TabIndex = 15;
            this.ExitApp.Text = "Exit";
            this.ExitApp.UseVisualStyleBackColor = true;
            this.ExitApp.Click += new System.EventHandler(this.ExitApp_Click);
            // 
            // GridViewProduct
            // 
            this.GridViewProduct.AllowUserToAddRows = false;
            this.GridViewProduct.AllowUserToDeleteRows = false;
            this.GridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewProduct.Location = new System.Drawing.Point(572, 144);
            this.GridViewProduct.Name = "GridViewProduct";
            this.GridViewProduct.ReadOnly = true;
            this.GridViewProduct.Size = new System.Drawing.Size(457, 255);
            this.GridViewProduct.TabIndex = 14;
            // 
            // GridViewPart
            // 
            this.GridViewPart.AllowUserToAddRows = false;
            this.GridViewPart.AllowUserToDeleteRows = false;
            this.GridViewPart.AllowUserToOrderColumns = true;
            this.GridViewPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewPart.Location = new System.Drawing.Point(40, 144);
            this.GridViewPart.Name = "GridViewPart";
            this.GridViewPart.ReadOnly = true;
            this.GridViewPart.Size = new System.Drawing.Size(447, 256);
            this.GridViewPart.TabIndex = 13;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 520);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // fHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 520);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ExitApp);
            this.Controls.Add(this.GridViewProduct);
            this.Controls.Add(this.GridViewPart);
            this.Controls.Add(this.SearchProductInput);
            this.Controls.Add(this.DeleteProduct);
            this.Controls.Add(this.ModifyProduct);
            this.Controls.Add(this.SearchProduct);
            this.Controls.Add(this.ProductsLabel);
            this.Controls.Add(this.AddProduct);
            this.Controls.Add(this.DeletePart);
            this.Controls.Add(this.ModifyPart);
            this.Controls.Add(this.AddPart);
            this.Controls.Add(this.PartsLabel);
            this.Controls.Add(this.SearchPart);
            this.Controls.Add(this.SearchPartInput);
            this.Controls.Add(this.HomeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fHome";
            this.Text = "MASTER OF PARTS - Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HomeTitle;
        private System.Windows.Forms.TextBox SearchPartInput;
        private System.Windows.Forms.Button SearchPart;
        private System.Windows.Forms.Label PartsLabel;
        private System.Windows.Forms.Button AddPart;
        private System.Windows.Forms.Button ModifyPart;
        private System.Windows.Forms.Button DeletePart;
        private System.Windows.Forms.Button AddProduct;
        private System.Windows.Forms.Label ProductsLabel;
        private System.Windows.Forms.Button SearchProduct;
        private System.Windows.Forms.Button ModifyProduct;
        private System.Windows.Forms.Button DeleteProduct;
        private System.Windows.Forms.TextBox SearchProductInput;
        private System.Windows.Forms.Button ExitApp;
        private System.Windows.Forms.DataGridView GridViewProduct;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView GridViewPart;
    }
}

