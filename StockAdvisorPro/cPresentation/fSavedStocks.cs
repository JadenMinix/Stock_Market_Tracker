using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAdvisorPro
{
	public partial class fSavedStocks : Form
	{
		public fSavedStocks()
		{
			InitializeComponent();
		}

		/// <summary>
		/// On form load this fills the datagridview with saved stocks.
		/// </summary>
		private void fSavedStocks_Load(object sender, EventArgs e)
		{
			updateSavedStocksGrid();
		}

		/// <summary>
		/// Updates the saved stocks grid to reflect the databases record of
		/// User's saved stocks. Called when stocks are added or removed from the
		/// user's saved stock list.
		/// </summary>
		private void updateSavedStocksGrid()
		{
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				int uid = cUser.UserID;

				//get saved stocks from only this current user
				var stock_list = from d in db.SAVED_STOCKs
								where d.User_id == uid
								join p in db.STOCKs on d.Stock_id equals p.id
								orderby p.id ascending
								select p;

				savedStocksBind.DataSource = stock_list;
				gridView_SavedStocks.DataSource = savedStocksBind;

				DataGridViewCheckBoxCell chk;
				//set all rows to have a checked box
				foreach (DataGridViewRow r in gridView_SavedStocks.Rows)
				{
					chk = r.Cells[0] as DataGridViewCheckBoxCell;
					r.Cells[0].Value = chk.TrueValue; //check the box
				}
			}
		}

		/// <summary>
		/// Called whenever the accept button is pressed. Finds all rows
		/// in the user's saved stocks screen and saves all stocks with
		/// a checkmark under the user's favorite stocks in the database.
		/// It deletes any stocks on the list with a checkmark removed.
		/// </summary>
		/// <param name="sender">default parameter.</param>
		/// <param name="e">default paramter.</param>
		private void btn_Accept_Click(object sender, EventArgs e)
		{
			//save all stock id's in list
			List<int> checked_stock_ids = new List<int>();
			//will be true if 

			foreach (DataGridViewRow r in gridView_SavedStocks.Rows)
			{
				//find all checked stocks to add to db if not already exist
				//if (
				DataGridViewCheckBoxCell cell = r.Cells[0] as DataGridViewCheckBoxCell;

				//Compare to the true value because Value isn't boolean
				if (cell.Value == cell.TrueValue)
				{
					checked_stock_ids.Add((int)r.Cells[1].Value);	//store all checked IDs
					if (checked_stock_ids.Count > 20)	//can't save more than 20 stocks
					{
						MessageBox.Show("Cannot save more than 20 stocks, please uncheck some", "Error");
						return;	//might change this to return
					}
				}
			}

			cAccess acc = new cAccess();
			acc.saveNewStocks(checked_stock_ids); //drop old stocks and save new list.
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Called when the add stock button is pressed. If the user has
		/// less than 20 stocks already saved, the add stock window appears
		/// and the user can select a new stock to add to their favorites list.
		/// </summary>
		/// <param name="sender">Default param.</param>
		/// <param name="e">Default param.</param>
		private void btn_AddStock_Click(object sender, EventArgs e)
		{
			if (gridView_SavedStocks.Rows.Count < 20)	//if user has less than 20 stocks saved
			{
				fAddStock add = new fAddStock();

				if (add.ShowDialog() == DialogResult.OK) //open new stock window, check for close OK (no cancel)
				{
					cDatabaseManager db = new cDatabaseManager();

					List<int> save_stocks = new List<int>();
					save_stocks.Add(add.sID); //get selected stock id from add stock window
					db.saveStocksForUser(save_stocks, cUser.UserID); //save it to db
					updateSavedStocksGrid(); // update stock grid to reflect changes
				}
			}
			else
			{
				//more than 20 stocks saved
				MessageBox.Show("Cannot save more than 20 stocks", "Stop");
			}
		}
	}
}
