namespace StockAdvisorPro
{
	partial class fEditDictionaryValues
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textWord = new System.Windows.Forms.TextBox();
			this.textWeight = new System.Windows.Forms.TextBox();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_Accept = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Word: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Weight:";
			// 
			// textWord
			// 
			this.textWord.Location = new System.Drawing.Point(65, 9);
			this.textWord.Name = "textWord";
			this.textWord.Size = new System.Drawing.Size(125, 20);
			this.textWord.TabIndex = 2;
			// 
			// textWeight
			// 
			this.textWeight.Location = new System.Drawing.Point(65, 35);
			this.textWeight.Name = "textWeight";
			this.textWeight.Size = new System.Drawing.Size(125, 20);
			this.textWeight.TabIndex = 3;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(12, 62);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 4;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_Accept
			// 
			this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Accept.Location = new System.Drawing.Point(114, 61);
			this.btn_Accept.Name = "btn_Accept";
			this.btn_Accept.Size = new System.Drawing.Size(75, 23);
			this.btn_Accept.TabIndex = 5;
			this.btn_Accept.Text = "Accept";
			this.btn_Accept.UseVisualStyleBackColor = true;
			this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
			// 
			// fEditDictionaryValues
			// 
			this.AcceptButton = this.btn_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(201, 91);
			this.Controls.Add(this.btn_Accept);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.textWeight);
			this.Controls.Add(this.textWord);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "fEditDictionaryValues";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textWord;
		private System.Windows.Forms.TextBox textWeight;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_Accept;

	}
}