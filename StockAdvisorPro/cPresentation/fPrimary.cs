using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAdvisorPro
{
    public partial class fPrimary : Form
    {
		//default to false so analysis is default. if all articles have been analyzed, it will
		//ask to reanalyze all articles and this will be set to true.
		private bool re_analyze = false;

        public fPrimary()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function handles the logout button when clicked from the main screen.
        /// It should close the User's session, including syncing profile changes with
        /// the database and sync dictionary changes with the database. After the session
        /// closes, the login screen reappears.
        /// </summary>
        /// <param name="sender">Default parameter passed by c# win forms</param>
        /// <param name="e">Default parameter passed by win forms</param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

		/// <summary>
		/// This button opens the dictionary window form. Button click handler "Dictionary"
		/// </summary>
		/// <param name="sender">default arg</param>
		/// <param name="e">default arg</param>
        private void btnDictionary_Click(object sender, EventArgs e)
        {
			fDictionary win = new fDictionary();
			win.Show();
        }

        /// <summary>
        /// This functions handles the Update Stock Prices button when clicked from
        /// the main screen. It will attempt to query all current stock prices from
        /// the NASDAQ and record them in the local database. 
        /// </summary>
        /// <param name="sender">Default parameter passed by c# win forms</param>
        /// <param name="e">Default parameter passed by win forms</param>
        private void btnUpdateStocks_Click(object sender, EventArgs e)
        {
            btnUpdateStocks.Enabled = false;
			btnCheckNewArticles.Enabled = false;
			btn_analyzeArticles.Enabled = false;
            toolStripStatusLabel.Text = "Updating stock quotes...";

            BackgroundWorker workerStockUpdate = new BackgroundWorker();
            workerStockUpdate.DoWork += new DoWorkEventHandler(workerStockUpdate_DoWork);
            workerStockUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerStockUpdate_RunWorkerCompleted);
            workerStockUpdate.WorkerReportsProgress = true;
            workerStockUpdate.ProgressChanged += new ProgressChangedEventHandler(workerStockUpdate_ProgressChanged);
            workerStockUpdate.RunWorkerAsync();
        }

        /// <summary>
        /// Background thread function for stock price update. Gets called when 
        /// background thread worker gets run asynchronously.
        /// </summary>
        /// <param name="sender">object that sent the function</param>
        /// <param name="e">arguments (parameters & results etc.)</param>
        private void workerStockUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            cStockScanner scanner = new cStockScanner();
            BackgroundWorker bw = sender as BackgroundWorker;
            e.Result = scanner.getCurrentQuotes(bw);
        }

        /// <summary>
        /// Background thread function for stock price update. Is a call back for
        /// when the thread completes. On completion, the correct message box will
        /// show depending on the results of cStockScanner.getCurrentQuotes(). If no
        /// errors are encountered, no messagebox will show.
        /// </summary>
        /// <param name="sender">object that calls the function</param>
        /// <param name="e">worker compelted arguments (including result from dowork)</param>
        private void workerStockUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                int success = (int)e.Result;
                if (success == -1)
                {
                    MessageBox.Show("Stock quote update failed", "Error");
                }
                else if (success == -2)
                {
                    MessageBox.Show("Stocks already updated within past 12 hours", "Error");
                }
                else if (success == -3)
                {
                    MessageBox.Show("One or more stocks failed to insert price into database");
                }
            }
			//reenable buttons 
            btnUpdateStocks.Enabled = true;
			btnCheckNewArticles.Enabled = true;
			btn_analyzeArticles.Enabled = true;
            toolStripStatusLabel.Text = "Stock Advisor Pro: ";
            toolStripProgressBar.Value = 0;
        }

        /// <summary>
        /// This function is a callback function for the stock price update background
        /// worker. It is called everytime the EventChanged function is called from the
        /// do_work thread. It updates the progress bar.
        /// </summary>
        /// <param name="sender">Object that calls function</param>
        /// <param name="e"> Progress changed arguments (progress percent)</param>
        private void workerStockUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

		/// <summary>
		/// This functions handles the Check New Articles button when clicked from
		/// the main screen. It will attempt to query the most recent articles on
		/// investopedia.com and record those articles if they are more recent than
		/// the last recorded article insertion.
		/// </summary>
		/// <param name="sender">Default parameter passed by c# win forms</param>
		/// <param name="e">Default parameter passed by win forms</param>
		private void btnCheckNewArticles_Click(object sender, EventArgs e)
		{
			btnCheckNewArticles.Enabled = false;
			btnUpdateStocks.Enabled = false;
			btn_analyzeArticles.Enabled = false;

			BackgroundWorker workerArticleUpdate = new BackgroundWorker();
			workerArticleUpdate.DoWork += new DoWorkEventHandler(workerArticleUpdate_DoWork);
			workerArticleUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerArticleUpdate_RunWorkerCompleted);
			workerArticleUpdate.WorkerReportsProgress = true;
			workerArticleUpdate.ProgressChanged += new ProgressChangedEventHandler(workerArticleUpdate_ProgressChanged);

			//before kicking off the background worker, check that there are articles to be scraped first
			cArticleScanner scanner = new cArticleScanner();
			int new_articles = scanner.checkForNewArticles();

			//if new articles exist, then begin the background worker
			if (new_articles == 1)
			{
				MessageBox.Show("New articles found!");
				toolStripStatusLabel.Text = "Updating articles...";
				workerArticleUpdate.RunWorkerAsync(scanner);
			}
			else if (new_articles == 0) //no new articles? re-enable all buttons
			{
				MessageBox.Show("No new articles!");
				btnCheckNewArticles.Enabled = true;
				btnUpdateStocks.Enabled = true;
				btn_analyzeArticles.Enabled = true;
			}
			else if (new_articles == -1)	//no articles found in database at all?
			{
				//warn user not to select articles dated too far in the past
				MessageBox.Show("No articles were found in database. Please input date you would like to scrape articles to (it is NOT recommended to scan articles from as far back as possible[2004] for performance reasons. Please select a date around when you began tracking stock prices, otherwise pick a date no more than 5 days in the past)");

				//set oldest date for picker box to 2004 & latest date to yesterday
				var picker = new DateTimePicker();
				picker.MinDate = new DateTime(2004, 1, 1);
				picker.MaxDate = DateTime.Now.AddDays(-1);	//yesterday
				picker.Left = 11;	//center the date thing
				picker.Top = 6;

				fDatePicker f = new fDatePicker();	//create date picker form (basically empty)
				f.Controls.Add(picker); //add control to form

				var result = f.ShowDialog();
				if (result == DialogResult.OK)
				{
					//get selected date & set it as last article update (so scanner will grab articles until that date is reached)
					DateTime selected_date = picker.Value;
					Console.WriteLine(selected_date.ToString());
					scanner.setLastArticleDate(selected_date);
					toolStripStatusLabel.Text = "Updating articles...";
					workerArticleUpdate.RunWorkerAsync(scanner);	//pop off background worker with new date to scan until
				}
			}
		}

		/// <summary>
		/// Background thread function for stock article update. Gets called when 
		/// background thread worker gets run asynchronously.
		/// </summary>
		/// <param name="sender">object that sent the function</param>
		/// <param name="e">arguments (parameters & results etc.)</param>
		private void workerArticleUpdate_DoWork(object sender, DoWorkEventArgs e)
		{
			cArticleScanner scanner = (cArticleScanner)e.Argument;
			BackgroundWorker bw = sender as BackgroundWorker;
			e.Result = scanner.getLatestArticles(bw);
		}

		/// <summary>
		/// Background thread function for stock article update. Is a call back for
		/// when the thread completes. On completion, a message box is shown if an error
		/// is encountered. Otherwise, a message box showing the results of the
		/// article update.
		/// </summary>
		/// <param name="sender">object that calls the function</param>
		/// <param name="e">worker compelted arguments (including result from dowork)</param>
		private void workerArticleUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar.Value = 0;

			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else
			{
				bool success = (bool)e.Result;
				if (!success)
				{
					MessageBox.Show("Article update failed!", "Error");
				}
				else
				{
					MessageBox.Show("Article update complete!", "Success");
				}
			}
			btnCheckNewArticles.Enabled = true;
			btnUpdateStocks.Enabled = true;
			btn_analyzeArticles.Enabled = true;
			toolStripStatusLabel.Text = "Stock Advisor Pro: ";
		}

		/// <summary>
		/// This function is a callback function for the stock article update background
		/// worker. It is called everytime the EventChanged function is called from the
		/// do_work thread. It updates the progress bar.
		/// </summary>
		/// <param name="sender">Object that calls function</param>
		/// <param name="e"> Progress changed arguments (progress percent)</param>
		private void workerArticleUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			toolStripProgressBar.Value = e.ProgressPercentage;
			if (e.UserState != null)
			{
				string status = (string)e.UserState;
				toolStripStatusLabel.Text = "Updating articles..." + status;
			}
		}

		/// <summary>
		/// This is the button handler for the analyze articles button. It spawns a 
		/// thread that analyzes all articles stored in database marked as unreviewed.
		/// Reviews are stored in database.
		/// </summary>
		/// <param name="sender">default arg</param>
		/// <param name="e">default arg</param>
		private void btn_analyzeArticles_Click(object sender, EventArgs e)
		{
			btnUpdateStocks.Enabled = false;
			btnCheckNewArticles.Enabled = false;
			btn_analyzeArticles.Enabled = false;

			toolStripStatusLabel.Text = "Analyzing articles...";

			BackgroundWorker workerAnalyzeArticles = new BackgroundWorker();
			workerAnalyzeArticles.DoWork += new DoWorkEventHandler(workerAnalyzeArticles_DoWork);
			workerAnalyzeArticles.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerAnalyzeArticles_RunWorkerCompleted);
			workerAnalyzeArticles.WorkerReportsProgress = true;
			workerAnalyzeArticles.ProgressChanged += new ProgressChangedEventHandler(workerAnalyzeArticles_ProgressChanged);
			workerAnalyzeArticles.RunWorkerAsync();
		}

		/// <summary>
		/// Background thread function for stock article analysis. Gets called when 
		/// background thread worker gets run asynchronously.
		/// </summary>
		/// <param name="sender">object that sent the function</param>
		/// <param name="e">arguments (parameters & results etc.)</param>
		private void workerAnalyzeArticles_DoWork(object sender, DoWorkEventArgs e)
		{
			cDataAnalysis analyzer = new cDataAnalysis();
			BackgroundWorker bw = sender as BackgroundWorker;

			if (!re_analyze) // if not already analyzed all articles
				e.Result = analyzer.analyzeArticles(bw);
			else	//if all articles analyzed, and user wants to reanalyze
			{
				re_analyze = false;	//set flag back 
				e.Result = analyzer.reAnalyzeAllArticles(bw);	//drop reviews and reanalyze
			}
		}

		/// <summary>
		/// Background thread function for stock article analysis. Is a call back for
		/// when the thread completes. 
		/// </summary>
		/// <param name="sender">object that calls the function</param>
		/// <param name="e">worker compelted arguments (including result from dowork)</param>
		private void workerAnalyzeArticles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			int result = (int)e.Result;	//get results from article scan
			if (result == 0)			//no articles to analyze, ask user to reanalyze
			{
				var res = MessageBox.Show("All articles have already analyzed. Would you like to Re-analyze them?", "Already Scanned", MessageBoxButtons.YesNo);
				if (res == DialogResult.Yes)
				{
					re_analyze = true;
					btn_analyzeArticles.PerformClick();
				}
			}
			else if (result == -1)	//error during analysis
			{
				MessageBox.Show("Error inserting record during analysis", "Error");
			} 
			
			//reenable buttons
			btnUpdateStocks.Enabled = true;
			btnCheckNewArticles.Enabled = true;
			btn_analyzeArticles.Enabled = true;
			toolStripStatusLabel.Text = "Stock Advisor Pro: ";
			toolStripProgressBar.Value = 0;
		}

		/// <summary>
		/// This function is a callback function for the stock article analysis background
		/// worker. It is called everytime the EventChanged function is called from the
		/// do_work thread. It updates the progress bar.
		/// </summary>
		/// <param name="sender">Object that calls function</param>
		/// <param name="e"> Progress changed arguments (progress percent)</param>
		private void workerAnalyzeArticles_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			toolStripProgressBar.Value = e.ProgressPercentage;
		}

		/// <summary>
		/// This is the button handler for the "Favorites" button on the primary screen. It opens
		/// the favorites form and allows the user to view/add/remove stocks from favorites list.
		/// </summary>
		/// <param name="sender">Default parameter.</param>
		/// <param name="e">Default parameter.</param>
		private void btnFavorites_Click(object sender, EventArgs e)
		{
			fSavedStocks win = new fSavedStocks();
			win.ShowDialog();
		}

		/// <summary>
		/// This is called when the Graph button is pressed on the main screen. It opens
		/// the graph configuration screen so the user can generate a graph to view.
		/// </summary>
		/// <param name="sender">Default parameter.</param>
		/// <param name="e">Default parameter.</param>
		private void btnGraph_Click(object sender, EventArgs e)
		{
            cDatabaseManager dbm = new cDatabaseManager();

            if (dbm.getNumStockEntries() > 3)
            {
                fGraphConfig config = new fGraphConfig();
                config.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("There are no stocks found to graph! Please run stock price update first!",
                    "Warning!",
                    MessageBoxButtons.OK);
            }
		}

    }
}
