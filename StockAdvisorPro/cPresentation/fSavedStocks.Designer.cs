namespace StockAdvisorPro
{
	partial class fSavedStocks
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
			this.gridView_SavedStocks = new System.Windows.Forms.DataGridView();
			this.checkBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.savedStocksBind = new System.Windows.Forms.BindingSource(this.components);
			this.btn_Accept = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_AddStock = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridView_SavedStocks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.savedStocksBind)).BeginInit();
			this.SuspendLayout();
			// 
			// gridView_SavedStocks
			// 
			this.gridView_SavedStocks.AllowUserToAddRows = false;
			this.gridView_SavedStocks.AllowUserToDeleteRows = false;
			this.gridView_SavedStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridView_SavedStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridView_SavedStocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkBox});
			this.gridView_SavedStocks.Location = new System.Drawing.Point(12, 12);
			this.gridView_SavedStocks.Name = "gridView_SavedStocks";
			this.gridView_SavedStocks.Size = new System.Drawing.Size(256, 186);
			this.gridView_SavedStocks.TabIndex = 0;
			// 
			// checkBox
			// 
			this.checkBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.checkBox.FalseValue = "0";
			this.checkBox.HeaderText = "Saved";
			this.checkBox.Name = "checkBox";
			this.checkBox.TrueValue = "1";
			this.checkBox.Width = 44;
			// 
			// btn_Accept
			// 
			this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Accept.Location = new System.Drawing.Point(193, 226);
			this.btn_Accept.Name = "btn_Accept";
			this.btn_Accept.Size = new System.Drawing.Size(75, 23);
			this.btn_Accept.TabIndex = 1;
			this.btn_Accept.Text = "Accept";
			this.btn_Accept.UseVisualStyleBackColor = true;
			this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(12, 226);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 2;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			// 
			// btn_AddStock
			// 
			this.btn_AddStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_AddStock.Location = new System.Drawing.Point(95, 226);
			this.btn_AddStock.Name = "btn_AddStock";
			this.btn_AddStock.Size = new System.Drawing.Size(90, 23);
			this.btn_AddStock.TabIndex = 3;
			this.btn_AddStock.Text = "Add Stock...";
			this.btn_AddStock.UseVisualStyleBackColor = true;
			this.btn_AddStock.Click += new System.EventHandler(this.btn_AddStock_Click);
			// 
			// fSavedStocks
			// 
			this.AcceptButton = this.btn_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(280, 261);
			this.Controls.Add(this.btn_AddStock);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Accept);
			this.Controls.Add(this.gridView_SavedStocks);
			this.Name = "fSavedStocks";
			this.Text = "fSavedStocks";
			this.Load += new System.EventHandler(this.fSavedStocks_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridView_SavedStocks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.savedStocksBind)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridView_SavedStocks;
		private System.Windows.Forms.BindingSource savedStocksBind;
		private System.Windows.Forms.Button btn_Accept;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_AddStock;
		private System.Windows.Forms.DataGridViewCheckBoxColumn checkBox;
	}
}