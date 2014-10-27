namespace StockAdvisorPro
{
    partial class fPrimary
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
            this.btnFavorites = new System.Windows.Forms.Button();
            this.btnDictionary = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUpdateStocks = new System.Windows.Forms.Button();
            this.statusStripPrimary = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.btnCheckNewArticles = new System.Windows.Forms.Button();
            this.btn_analyzeArticles = new System.Windows.Forms.Button();
            this.statusStripPrimary.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFavorites
            // 
            this.btnFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFavorites.Location = new System.Drawing.Point(20, 112);
            this.btnFavorites.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFavorites.Name = "btnFavorites";
            this.btnFavorites.Size = new System.Drawing.Size(112, 35);
            this.btnFavorites.TabIndex = 0;
            this.btnFavorites.Text = "Favorites";
            this.btnFavorites.UseVisualStyleBackColor = true;
            this.btnFavorites.Click += new System.EventHandler(this.btnFavorites_Click);
            // 
            // btnDictionary
            // 
            this.btnDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDictionary.Location = new System.Drawing.Point(142, 112);
            this.btnDictionary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDictionary.Name = "btnDictionary";
            this.btnDictionary.Size = new System.Drawing.Size(170, 35);
            this.btnDictionary.TabIndex = 1;
            this.btnDictionary.Text = "View/Edit Dictionary";
            this.btnDictionary.UseVisualStyleBackColor = true;
            this.btnDictionary.Click += new System.EventHandler(this.btnDictionary_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraph.Location = new System.Drawing.Point(315, 112);
            this.btnGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(112, 35);
            this.btnGraph.TabIndex = 2;
            this.btnGraph.Text = "Graph...";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(315, 18);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(112, 35);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUpdateStocks
            // 
            this.btnUpdateStocks.Location = new System.Drawing.Point(20, 20);
            this.btnUpdateStocks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdateStocks.Name = "btnUpdateStocks";
            this.btnUpdateStocks.Size = new System.Drawing.Size(177, 35);
            this.btnUpdateStocks.TabIndex = 4;
            this.btnUpdateStocks.Text = "Update Stock Prices";
            this.btnUpdateStocks.UseVisualStyleBackColor = true;
            this.btnUpdateStocks.Click += new System.EventHandler(this.btnUpdateStocks_Click);
            // 
            // statusStripPrimary
            // 
            this.statusStripPrimary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStripPrimary.Location = new System.Drawing.Point(0, 171);
            this.statusStripPrimary.Name = "statusStripPrimary";
            this.statusStripPrimary.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStripPrimary.Size = new System.Drawing.Size(444, 31);
            this.statusStripPrimary.SizingGrip = false;
            this.statusStripPrimary.TabIndex = 5;
            this.statusStripPrimary.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(163, 26);
            this.toolStripStatusLabel.Text = "Stock Advisor Pro: ";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 25);
            // 
            // btnCheckNewArticles
            // 
            this.btnCheckNewArticles.Location = new System.Drawing.Point(20, 66);
            this.btnCheckNewArticles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheckNewArticles.Name = "btnCheckNewArticles";
            this.btnCheckNewArticles.Size = new System.Drawing.Size(177, 35);
            this.btnCheckNewArticles.TabIndex = 6;
            this.btnCheckNewArticles.Text = "Check New Articles";
            this.btnCheckNewArticles.UseVisualStyleBackColor = true;
            this.btnCheckNewArticles.Click += new System.EventHandler(this.btnCheckNewArticles_Click);
            // 
            // btn_analyzeArticles
            // 
            this.btn_analyzeArticles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_analyzeArticles.Location = new System.Drawing.Point(278, 66);
            this.btn_analyzeArticles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_analyzeArticles.Name = "btn_analyzeArticles";
            this.btn_analyzeArticles.Size = new System.Drawing.Size(150, 35);
            this.btn_analyzeArticles.TabIndex = 7;
            this.btn_analyzeArticles.Text = "Analyze Articles";
            this.btn_analyzeArticles.UseVisualStyleBackColor = true;
            this.btn_analyzeArticles.Click += new System.EventHandler(this.btn_analyzeArticles_Click);
            // 
            // fPrimary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 202);
            this.Controls.Add(this.btn_analyzeArticles);
            this.Controls.Add(this.btnCheckNewArticles);
            this.Controls.Add(this.statusStripPrimary);
            this.Controls.Add(this.btnUpdateStocks);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.btnDictionary);
            this.Controls.Add(this.btnFavorites);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "fPrimary";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Stock Advisor Pro";
            this.statusStripPrimary.ResumeLayout(false);
            this.statusStripPrimary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFavorites;
        private System.Windows.Forms.Button btnDictionary;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnUpdateStocks;
        private System.Windows.Forms.StatusStrip statusStripPrimary;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.Button btnCheckNewArticles;
		private System.Windows.Forms.Button btn_analyzeArticles;
    }
}

