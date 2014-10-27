namespace StockAdvisorPro
{
	partial class fDictionary
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
			this.gridView_Dictionary = new System.Windows.Forms.DataGridView();
			this.dICTIONARYBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.stock_advisorDataSet = new StockAdvisorPro.stock_advisorDataSet();
			this.dICTIONARYTableAdapter = new StockAdvisorPro.stock_advisorDataSetTableAdapters.DICTIONARYTableAdapter();
			this.dictionaryBind = new System.Windows.Forms.BindingSource(this.components);
			this.btn_removeWord = new System.Windows.Forms.Button();
			this.btn_addWord = new System.Windows.Forms.Button();
			this.btn_editWord = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridView_Dictionary)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dICTIONARYBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stock_advisorDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dictionaryBind)).BeginInit();
			this.SuspendLayout();
			// 
			// gridView_Dictionary
			// 
			this.gridView_Dictionary.AllowUserToAddRows = false;
			this.gridView_Dictionary.AllowUserToDeleteRows = false;
			this.gridView_Dictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridView_Dictionary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridView_Dictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridView_Dictionary.Location = new System.Drawing.Point(13, 13);
			this.gridView_Dictionary.Name = "gridView_Dictionary";
			this.gridView_Dictionary.ReadOnly = true;
			this.gridView_Dictionary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridView_Dictionary.Size = new System.Drawing.Size(266, 219);
			this.gridView_Dictionary.TabIndex = 0;
			// 
			// dICTIONARYBindingSource
			// 
			this.dICTIONARYBindingSource.DataMember = "DICTIONARY";
			this.dICTIONARYBindingSource.DataSource = this.stock_advisorDataSet;
			// 
			// stock_advisorDataSet
			// 
			this.stock_advisorDataSet.DataSetName = "stock_advisorDataSet";
			this.stock_advisorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dICTIONARYTableAdapter
			// 
			this.dICTIONARYTableAdapter.ClearBeforeFill = true;
			// 
			// btn_removeWord
			// 
			this.btn_removeWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_removeWord.Location = new System.Drawing.Point(12, 243);
			this.btn_removeWord.Name = "btn_removeWord";
			this.btn_removeWord.Size = new System.Drawing.Size(92, 23);
			this.btn_removeWord.TabIndex = 1;
			this.btn_removeWord.Text = "Remove Word";
			this.btn_removeWord.UseVisualStyleBackColor = true;
			this.btn_removeWord.Click += new System.EventHandler(this.btn_removeWord_Click);
			// 
			// btn_addWord
			// 
			this.btn_addWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_addWord.Location = new System.Drawing.Point(197, 243);
			this.btn_addWord.Name = "btn_addWord";
			this.btn_addWord.Size = new System.Drawing.Size(82, 23);
			this.btn_addWord.TabIndex = 2;
			this.btn_addWord.Text = "Add Word";
			this.btn_addWord.UseVisualStyleBackColor = true;
			this.btn_addWord.Click += new System.EventHandler(this.btn_addWord_Click);
			// 
			// btn_editWord
			// 
			this.btn_editWord.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_editWord.Location = new System.Drawing.Point(112, 243);
			this.btn_editWord.Name = "btn_editWord";
			this.btn_editWord.Size = new System.Drawing.Size(75, 23);
			this.btn_editWord.TabIndex = 3;
			this.btn_editWord.Text = "Edit Word";
			this.btn_editWord.UseVisualStyleBackColor = true;
			this.btn_editWord.Click += new System.EventHandler(this.btn_editWord_Click);
			// 
			// fDictionary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(291, 278);
			this.Controls.Add(this.btn_editWord);
			this.Controls.Add(this.btn_addWord);
			this.Controls.Add(this.btn_removeWord);
			this.Controls.Add(this.gridView_Dictionary);
			this.Name = "fDictionary";
			this.Text = "fDictionary";
			this.Load += new System.EventHandler(this.fDictionary_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridView_Dictionary)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dICTIONARYBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stock_advisorDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dictionaryBind)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridView_Dictionary;
		private stock_advisorDataSet stock_advisorDataSet;
		private System.Windows.Forms.BindingSource dICTIONARYBindingSource;
		private stock_advisorDataSetTableAdapters.DICTIONARYTableAdapter dICTIONARYTableAdapter;
		private System.Windows.Forms.BindingSource dictionaryBind;
		private System.Windows.Forms.Button btn_removeWord;
		private System.Windows.Forms.Button btn_addWord;
		private System.Windows.Forms.Button btn_editWord;
	}
}