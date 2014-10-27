namespace StockAdvisorPro
{
	partial class fGraphConfig
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnStockThreeAllStocks = new System.Windows.Forms.Button();
			this.btnStockThreeFavorites = new System.Windows.Forms.Button();
			this.btnStockTwoAllStocks = new System.Windows.Forms.Button();
			this.btnStockTwoFavorite = new System.Windows.Forms.Button();
			this.btnStockOneAllStocks = new System.Windows.Forms.Button();
			this.btnStockOneFavorite = new System.Windows.Forms.Button();
			this.labelStockThree = new System.Windows.Forms.Label();
			this.labelStockTwo = new System.Windows.Forms.Label();
			this.labelStockOne = new System.Windows.Forms.Label();
			this.cbStockThree = new System.Windows.Forms.CheckBox();
			this.cbStockTwo = new System.Windows.Forms.CheckBox();
			this.cbStockOne = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbScoreOverTime = new System.Windows.Forms.CheckBox();
			this.cbValueOverTime = new System.Windows.Forms.CheckBox();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_CreateGraph = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnStockThreeAllStocks);
			this.groupBox1.Controls.Add(this.btnStockThreeFavorites);
			this.groupBox1.Controls.Add(this.btnStockTwoAllStocks);
			this.groupBox1.Controls.Add(this.btnStockTwoFavorite);
			this.groupBox1.Controls.Add(this.btnStockOneAllStocks);
			this.groupBox1.Controls.Add(this.btnStockOneFavorite);
			this.groupBox1.Controls.Add(this.labelStockThree);
			this.groupBox1.Controls.Add(this.labelStockTwo);
			this.groupBox1.Controls.Add(this.labelStockOne);
			this.groupBox1.Controls.Add(this.cbStockThree);
			this.groupBox1.Controls.Add(this.cbStockTwo);
			this.groupBox1.Controls.Add(this.cbStockOne);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(390, 105);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Stocks";
			// 
			// btnStockThreeAllStocks
			// 
			this.btnStockThreeAllStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStockThreeAllStocks.Enabled = false;
			this.btnStockThreeAllStocks.Location = new System.Drawing.Point(303, 68);
			this.btnStockThreeAllStocks.Name = "btnStockThreeAllStocks";
			this.btnStockThreeAllStocks.Size = new System.Drawing.Size(75, 23);
			this.btnStockThreeAllStocks.TabIndex = 11;
			this.btnStockThreeAllStocks.Text = "All Stocks...";
			this.btnStockThreeAllStocks.UseVisualStyleBackColor = true;
			this.btnStockThreeAllStocks.Click += new System.EventHandler(this.btnStockThreeAllStocks_Click);
			// 
			// btnStockThreeFavorites
			// 
			this.btnStockThreeFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStockThreeFavorites.Enabled = false;
			this.btnStockThreeFavorites.Location = new System.Drawing.Point(220, 68);
			this.btnStockThreeFavorites.Name = "btnStockThreeFavorites";
			this.btnStockThreeFavorites.Size = new System.Drawing.Size(75, 23);
			this.btnStockThreeFavorites.TabIndex = 10;
			this.btnStockThreeFavorites.Text = "Favorites...";
			this.btnStockThreeFavorites.UseVisualStyleBackColor = true;
			this.btnStockThreeFavorites.Click += new System.EventHandler(this.btnStockThreeFavorites_Click);
			// 
			// btnStockTwoAllStocks
			// 
			this.btnStockTwoAllStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStockTwoAllStocks.Enabled = false;
			this.btnStockTwoAllStocks.Location = new System.Drawing.Point(303, 43);
			this.btnStockTwoAllStocks.Name = "btnStockTwoAllStocks";
			this.btnStockTwoAllStocks.Size = new System.Drawing.Size(75, 23);
			this.btnStockTwoAllStocks.TabIndex = 9;
			this.btnStockTwoAllStocks.Text = "All stocks...";
			this.btnStockTwoAllStocks.UseVisualStyleBackColor = true;
			this.btnStockTwoAllStocks.Click += new System.EventHandler(this.btnStockTwoAllStocks_Click);
			// 
			// btnStockTwoFavorite
			// 
			this.btnStockTwoFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStockTwoFavorite.Enabled = false;
			this.btnStockTwoFavorite.Location = new System.Drawing.Point(220, 43);
			this.btnStockTwoFavorite.Name = "btnStockTwoFavorite";
			this.btnStockTwoFavorite.Size = new System.Drawing.Size(75, 23);
			this.btnStockTwoFavorite.TabIndex = 8;
			this.btnStockTwoFavorite.Text = "Favorites...";
			this.btnStockTwoFavorite.UseVisualStyleBackColor = true;
			this.btnStockTwoFavorite.Click += new System.EventHandler(this.btnStockTwoFavorite_Click);
			// 
			// btnStockOneAllStocks
			// 
			this.btnStockOneAllStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStockOneAllStocks.Location = new System.Drawing.Point(303, 18);
			this.btnStockOneAllStocks.Name = "btnStockOneAllStocks";
			this.btnStockOneAllStocks.Size = new System.Drawing.Size(75, 23);
			this.btnStockOneAllStocks.TabIndex = 7;
			this.btnStockOneAllStocks.Text = "All stocks...";
			this.btnStockOneAllStocks.UseVisualStyleBackColor = true;
			this.btnStockOneAllStocks.Click += new System.EventHandler(this.btnStockOneAllStocks_Click);
			// 
			// btnStockOneFavorite
			// 
			this.btnStockOneFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStockOneFavorite.Location = new System.Drawing.Point(220, 18);
			this.btnStockOneFavorite.Name = "btnStockOneFavorite";
			this.btnStockOneFavorite.Size = new System.Drawing.Size(75, 23);
			this.btnStockOneFavorite.TabIndex = 6;
			this.btnStockOneFavorite.Text = "Favorites...";
			this.btnStockOneFavorite.UseVisualStyleBackColor = true;
			this.btnStockOneFavorite.Click += new System.EventHandler(this.btnStockOneFavorite_Click);
			// 
			// labelStockThree
			// 
			this.labelStockThree.AutoSize = true;
			this.labelStockThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStockThree.Location = new System.Drawing.Point(70, 70);
			this.labelStockThree.Name = "labelStockThree";
			this.labelStockThree.Size = new System.Drawing.Size(144, 17);
			this.labelStockThree.TabIndex = 5;
			this.labelStockThree.Text = "Stock: None Selected";
			// 
			// labelStockTwo
			// 
			this.labelStockTwo.AutoSize = true;
			this.labelStockTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStockTwo.Location = new System.Drawing.Point(70, 44);
			this.labelStockTwo.Name = "labelStockTwo";
			this.labelStockTwo.Size = new System.Drawing.Size(144, 17);
			this.labelStockTwo.TabIndex = 4;
			this.labelStockTwo.Text = "Stock: None Selected";
			// 
			// labelStockOne
			// 
			this.labelStockOne.AutoSize = true;
			this.labelStockOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStockOne.Location = new System.Drawing.Point(70, 19);
			this.labelStockOne.Name = "labelStockOne";
			this.labelStockOne.Size = new System.Drawing.Size(144, 17);
			this.labelStockOne.TabIndex = 3;
			this.labelStockOne.Text = "Stock: None Selected";
			// 
			// cbStockThree
			// 
			this.cbStockThree.AutoSize = true;
			this.cbStockThree.Location = new System.Drawing.Point(7, 71);
			this.cbStockThree.Name = "cbStockThree";
			this.cbStockThree.Size = new System.Drawing.Size(63, 17);
			this.cbStockThree.TabIndex = 2;
			this.cbStockThree.Text = "Stock 3";
			this.cbStockThree.UseVisualStyleBackColor = true;
			this.cbStockThree.CheckedChanged += new System.EventHandler(this.cbStockThree_CheckedChanged);
			// 
			// cbStockTwo
			// 
			this.cbStockTwo.AutoSize = true;
			this.cbStockTwo.Location = new System.Drawing.Point(7, 46);
			this.cbStockTwo.Name = "cbStockTwo";
			this.cbStockTwo.Size = new System.Drawing.Size(63, 17);
			this.cbStockTwo.TabIndex = 1;
			this.cbStockTwo.Text = "Stock 2";
			this.cbStockTwo.UseVisualStyleBackColor = true;
			this.cbStockTwo.CheckedChanged += new System.EventHandler(this.cbStockTwo_CheckedChanged);
			// 
			// cbStockOne
			// 
			this.cbStockOne.AutoSize = true;
			this.cbStockOne.Checked = true;
			this.cbStockOne.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbStockOne.Location = new System.Drawing.Point(7, 20);
			this.cbStockOne.Name = "cbStockOne";
			this.cbStockOne.Size = new System.Drawing.Size(63, 17);
			this.cbStockOne.TabIndex = 0;
			this.cbStockOne.Text = "Stock 1";
			this.cbStockOne.UseVisualStyleBackColor = true;
			this.cbStockOne.CheckedChanged += new System.EventHandler(this.cbStockOne_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbScoreOverTime);
			this.groupBox2.Controls.Add(this.cbValueOverTime);
			this.groupBox2.Location = new System.Drawing.Point(12, 123);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(226, 44);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Select Graph Type";
			// 
			// cbScoreOverTime
			// 
			this.cbScoreOverTime.AutoSize = true;
			this.cbScoreOverTime.Location = new System.Drawing.Point(116, 19);
			this.cbScoreOverTime.Name = "cbScoreOverTime";
			this.cbScoreOverTime.Size = new System.Drawing.Size(104, 17);
			this.cbScoreOverTime.TabIndex = 1;
			this.cbScoreOverTime.Text = "Score over Time";
			this.cbScoreOverTime.UseVisualStyleBackColor = true;
			// 
			// cbValueOverTime
			// 
			this.cbValueOverTime.AutoSize = true;
			this.cbValueOverTime.Checked = true;
			this.cbValueOverTime.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbValueOverTime.Location = new System.Drawing.Point(7, 20);
			this.cbValueOverTime.Name = "cbValueOverTime";
			this.cbValueOverTime.Size = new System.Drawing.Size(103, 17);
			this.cbValueOverTime.TabIndex = 0;
			this.cbValueOverTime.Text = "Value over Time";
			this.cbValueOverTime.UseVisualStyleBackColor = true;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(12, 171);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 2;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			// 
			// btn_CreateGraph
			// 
			this.btn_CreateGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_CreateGraph.Location = new System.Drawing.Point(326, 171);
			this.btn_CreateGraph.Name = "btn_CreateGraph";
			this.btn_CreateGraph.Size = new System.Drawing.Size(75, 23);
			this.btn_CreateGraph.TabIndex = 3;
			this.btn_CreateGraph.Text = "Generate...";
			this.btn_CreateGraph.UseVisualStyleBackColor = true;
			this.btn_CreateGraph.Click += new System.EventHandler(this.btn_CreateGraph_Click);
			// 
			// fGraphConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(414, 206);
			this.Controls.Add(this.btn_CreateGraph);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "fGraphConfig";
			this.Text = "fGraphConfig";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnStockThreeAllStocks;
		private System.Windows.Forms.Button btnStockThreeFavorites;
		private System.Windows.Forms.Button btnStockTwoAllStocks;
		private System.Windows.Forms.Button btnStockTwoFavorite;
		private System.Windows.Forms.Button btnStockOneAllStocks;
		private System.Windows.Forms.Button btnStockOneFavorite;
		private System.Windows.Forms.Label labelStockThree;
		private System.Windows.Forms.Label labelStockTwo;
		private System.Windows.Forms.Label labelStockOne;
		private System.Windows.Forms.CheckBox cbStockThree;
		private System.Windows.Forms.CheckBox cbStockTwo;
		private System.Windows.Forms.CheckBox cbStockOne;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox cbScoreOverTime;
		private System.Windows.Forms.CheckBox cbValueOverTime;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_CreateGraph;
	}
}