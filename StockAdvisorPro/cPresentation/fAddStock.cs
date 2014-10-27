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
	public partial class fAddStock : Form
	{
		private int selected_stock_id;
		public int sID
		{
			get { return selected_stock_id; }
			private set { selected_stock_id = value; }
		}

		private string selected_stock_symbol;
		public string sSymbol
		{
			get { return selected_stock_symbol; }
			private set { selected_stock_symbol = value; }
		}

		private bool favoriteList = false;

		/// <summary>
		/// Display list of all stocks wherein User can select only one.
		/// </summary>
		public fAddStock()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Alternate constructor used to only display current User's favorites
		/// stocks list. 
		/// </summary>
		/// <param name="favorites">True if only display favorites.</param>
		public fAddStock(bool favorites)
		{
			InitializeComponent();
			favoriteList = favorites;
		}

		/// <summary>
		/// called upon loading of the form. populates the datagrid with the
		/// stock symbols from database.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void fAddStock_Load(object sender, EventArgs e)
		{
			updateStocksGrid();
		}

		/// <summary>
		/// Updates the grid displayed to the user containing all stock symbol entries.
		/// Called only on load because this gridview's contents are not modified.
		/// </summary>
		private void updateStocksGrid()
		{
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				if (!favoriteList)
				{
					//get all stocks & bind
					var stocks = from d in db.STOCKs
								 orderby d.id ascending
								 select d;
					bindingSource_Stocks.DataSource = stocks;
				}
				else
				{
					int uid = cUser.UserID;

					//only get user's saved stocks & bind
					var stocks = from d in db.SAVED_STOCKs
								 where d.User_id == uid
								 join p in db.STOCKs on d.Stock_id equals p.id
								 orderby p.id ascending
								 select p;
					bindingSource_Stocks.DataSource = stocks;
				}
				gridView_StocksList.DataSource = bindingSource_Stocks;
			}
		}

		/// <summary>
		/// Called when the add button is clicked. Saves the stock id and symbol
		/// to the private variables in the class so they can be retrieved by whichever
		/// calling form. Then sets the result to OK and closes the form.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void btn_Add_Click(object sender, EventArgs e)
		{
            if (gridView_StocksList.SelectedRows.Count < 1)
            {
                MessageBox.Show("Must select at least one word");
            }
            else
            {
                var id = (int)gridView_StocksList.SelectedRows[0].Cells[0].Value; //stock ID

                //save selected stock info before closing window
                selected_stock_id = id; //stock id
                selected_stock_symbol = (string)gridView_StocksList.SelectedRows[0].Cells[1].Value; //stock symbol

                //set result to OK and close
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
		}
	}
}
