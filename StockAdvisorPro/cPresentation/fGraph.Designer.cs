namespace StockAdvisorPro
{
	partial class fGraph
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
            this.zedGraphMain = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraphMain
            // 
            this.zedGraphMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphMain.AutoSize = true;
            this.zedGraphMain.Location = new System.Drawing.Point(18, 18);
            this.zedGraphMain.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.zedGraphMain.Name = "zedGraphMain";
            this.zedGraphMain.PanButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zedGraphMain.PanButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zedGraphMain.ScrollGrace = 0D;
            this.zedGraphMain.ScrollMaxX = 0D;
            this.zedGraphMain.ScrollMaxY = 0D;
            this.zedGraphMain.ScrollMaxY2 = 0D;
            this.zedGraphMain.ScrollMinX = 0D;
            this.zedGraphMain.ScrollMinY = 0D;
            this.zedGraphMain.ScrollMinY2 = 0D;
            this.zedGraphMain.Size = new System.Drawing.Size(1142, 731);
            this.zedGraphMain.TabIndex = 0;
            // 
            // fGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.zedGraphMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fGraph";
            this.Text = "fGraph";
            this.Load += new System.EventHandler(this.fGraph_Load);
            this.Resize += new System.EventHandler(this.fGraph_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ZedGraph.ZedGraphControl zedGraphMain;

	}
}