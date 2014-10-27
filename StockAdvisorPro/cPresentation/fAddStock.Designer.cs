namespace StockAdvisorPro
{
	partial class fAddStock
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
			this.gridView_StocksList = new System.Windows.Forms.DataGridView();
			this.bindingSource_Stocks = new System.Windows.Forms.BindingSource(this.components);
			this.btn_Add = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridView_StocksList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource_Stocks)).BeginInit();
			this.SuspendLayout();
			// 
			// gridView_StocksList
			// 
			this.gridView_StocksList.AllowUserToAddRows = false;
			this.gridView_StocksList.AllowUserToDeleteRows = false;
			this.gridView_StocksList.AllowUserToOrderColumns = true;
			this.gridView_StocksList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridView_StocksList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridView_StocksList.Location = new System.Drawing.Point(12, 12);
			this.gridView_StocksList.MultiSelect = false;
			this.gridView_StocksList.Name = "gridView_StocksList";
			this.gridView_StocksList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridView_StocksList.Size = new System.Drawing.Size(260, 208);
			this.gridView_StocksList.TabIndex = 0;
			// 
			// btn_Add
			// 
			this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Add.Location = new System.Drawing.Point(197, 226);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(75, 23);
			this.btn_Add.TabIndex = 1;
			this.btn_Add.Text = "Add";
			this.btn_Add.UseVisualStyleBackColor = true;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(13, 226);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 2;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			// 
			// fAddStock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Add);
			this.Controls.Add(this.gridView_StocksList);
			this.Name = "fAddStock";
			this.Text = "fAddStock";
			this.Load += new System.EventHandler(this.fAddStock_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridView_StocksList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource_Stocks)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridView_StocksList;
		private System.Windows.Forms.BindingSource bindingSource_Stocks;
		private System.Windows.Forms.Button btn_Add;
		private System.Windows.Forms.Button btn_Cancel;

	}
}