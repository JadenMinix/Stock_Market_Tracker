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
	public partial class fGraphConfig : Form
	{
		//set all stocks to -1 to indicate unchosen stocks
		private int stock_one = -1;
		private int stock_two = -1;
		private int stock_three = -1;

		//strings of selected stocks for text update on screen
		private string stock_one_str = "";
		private string stock_two_str = "";
		private string stock_three_str = "";

		private bool stock_one_enabled = true; //first one starts enabled to encourage graph
		private bool stock_two_enabled = false; //rest disabled
		private bool stock_three_enabled = false;

		public fGraphConfig()
		{
			InitializeComponent();

			//populate stocks-to-graph from first 3 stocks found in stock table
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var sel = from d in db.STOCKs
						  orderby d.id ascending
						  select d;

                //if (!sel.Any()) //check for atleast one result (because if there's one, there will be 1500+
                //{
                    stock_one = sel.FirstOrDefault().id;
                    stock_one_str = sel.FirstOrDefault().Symbol;

                    stock_two = sel.Skip(1).First().id;
                    stock_two_str = sel.Skip(1).First().Symbol;

                    stock_three = sel.Skip(2).First().id;
                    stock_three_str = sel.Skip(2).First().Symbol;

                    labelStockOne.Text = "Stock: " + stock_one_str;
                    labelStockTwo.Text = "Stock: " + stock_two_str;
                    labelStockThree.Text = "Stock: " + stock_three_str;
                //}

			}
		}

		/// <summary>
		/// Stock one favorite button click handler. Called when stock one
		/// "favorites" button is selected to pick a stock from user's favorite
		/// stocks list to appear in the graph.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void btnStockOneFavorite_Click(object sender, EventArgs e)
		{
			fAddStock add_sym = new fAddStock(true);
			if (add_sym.ShowDialog() == DialogResult.OK)	//user selected ok, grab stock picked
			{
				stock_one = add_sym.sID;
				stock_one_str = add_sym.sSymbol;
				labelStockOne.Text = "Stock: " + stock_one_str;
			}
		}

		/// <summary>
		/// Stock one all stocks button click handler. Called when stock one
		/// "all stocks" button is selected to pick a stock from complete list of
		/// stock symbols to appear in the graph.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void btnStockOneAllStocks_Click(object sender, EventArgs e)
		{
			fAddStock add_sym = new fAddStock();
			if (add_sym.ShowDialog() == DialogResult.OK)
			{
				stock_one = add_sym.sID; 
				stock_one_str = add_sym.sSymbol;
				labelStockOne.Text = "Stock: " + stock_one_str;
			}
		}

		/// <summary>
		/// Stock two favorite button click handler. Called when stock two
		/// "favorites" button is selected to pick a stock from user's favorite
		/// stocks list to appear in the graph.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void btnStockTwoFavorite_Click(object sender, EventArgs e)
		{
			fAddStock add_sym = new fAddStock(true);
			if (add_sym.ShowDialog() == DialogResult.OK)
			{
				stock_two = add_sym.sID;
				stock_two_str = add_sym.sSymbol;
				labelStockTwo.Text = "Stock: " + stock_two_str;
			}
		}

		/// <summary>
		/// Stock two all stocks button click handler. Called when stock two
		/// "all stocks" button is selected to pick a stock from complete list of
		/// stock symbols to appear in the graph.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void btnStockTwoAllStocks_Click(object sender, EventArgs e)
		{
			fAddStock add_sym = new fAddStock();
			if (add_sym.ShowDialog() == DialogResult.OK)
			{
				stock_two = add_sym.sID; 
				stock_two_str = add_sym.sSymbol;
				labelStockTwo.Text = "Stock: " + stock_two_str;
			}
		}

		/// <summary>
		/// Stock three favorite button click handler. Called when stock three
		/// "favorites" button is selected to pick a stock from user's favorite
		/// stocks list to appear in the graph.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void btnStockThreeFavorites_Click(object sender, EventArgs e)
		{
			fAddStock add_sym = new fAddStock(true);
			if (add_sym.ShowDialog() == DialogResult.OK)
			{
				stock_three = add_sym.sID;
				stock_three_str = add_sym.sSymbol;
				labelStockThree.Text = "Stock: " + stock_three_str;
			}
		}

		/// <summary>
		/// Stock three all stocks button click handler. Called when stock three
		/// "all stocks" button is selected to pick a stock from complete list of
		/// stock symbols to appear in the graph.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void btnStockThreeAllStocks_Click(object sender, EventArgs e)
		{
			fAddStock add_sym = new fAddStock();
			if (add_sym.ShowDialog() == DialogResult.OK)
			{
				stock_three = add_sym.sID;
				stock_three_str = add_sym.sSymbol;
				labelStockThree.Text = "Stock: " + stock_three_str;
			}
		}

		/// <summary>
		/// Event handler for stock one checkbox toggle. When changed, the state
		/// of stock one toggles enabled or disabled. Disables or enables relevant 
		/// buttons.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void cbStockOne_CheckedChanged(object sender, EventArgs e)
		{	
			stock_one_enabled = !stock_one_enabled;

			btnStockOneFavorite.Enabled = stock_one_enabled;
			btnStockOneAllStocks.Enabled = stock_one_enabled;
		}

		/// <summary>
		/// Event handler for stock two checkbox toggle. When changed, the state
		/// of stock two toggles enabled or disabled. Disables or enables relevant 
		/// buttons.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void cbStockTwo_CheckedChanged(object sender, EventArgs e)
		{
			stock_two_enabled = !stock_two_enabled;

			btnStockTwoFavorite.Enabled = stock_two_enabled;
			btnStockTwoAllStocks.Enabled = stock_two_enabled;
		}

		/// <summary>
		/// Event handler for stock three checkbox toggle. When changed, the state
		/// of stock three toggles enabled or disabled. Disables or enables relevant 
		/// buttons.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void cbStockThree_CheckedChanged(object sender, EventArgs e)
		{
			stock_three_enabled = !stock_three_enabled;

			btnStockThreeFavorites.Enabled = stock_three_enabled;
			btnStockThreeAllStocks.Enabled = stock_three_enabled;
		}

		/// <summary>
		/// Handler for generate graph button. Creates new form to display
		/// graph for the User based on parameters made on this form.
		/// </summary>
		/// <param name="sender">Default parameter</param>
		/// <param name="e">Default parameter</param>
		private void btn_CreateGraph_Click(object sender, EventArgs e)
		{
			//ensure atleast one stock is enabled & one graph mode is selected
			if ( (stock_one_enabled || stock_two_enabled || stock_three_enabled) 
			  && (cbValueOverTime.Checked || cbScoreOverTime.Checked) )
			{
				fGraph graph = new fGraph();
				
				cDatabaseManager db = new cDatabaseManager();

				if (cbValueOverTime.Checked)	//add selected curves to graph(s)
				{
					if (stock_one_enabled)
					{
						var list = db.getStockPrices(stock_one);
						graph.addCurve(list, stock_one_str, true, Color.Red);
					}
					if (stock_two_enabled)
					{
						var list = db.getStockPrices(stock_two);
						graph.addCurve(list, stock_two_str, true, Color.Blue);
					}
					if (stock_three_enabled)
					{
						var list = db.getStockPrices(stock_three);
						graph.addCurve(list, stock_three_str, true, Color.Green);
					}
				}

				if (cbScoreOverTime.Checked)
				{
					if (stock_one_enabled)
					{
						var list = db.getStockRatings(cUser.UserID, stock_one);
						graph.addCurve(list, stock_one_str, false, Color.Red);
					}
					if (stock_two_enabled)
					{
						var list = db.getStockRatings(cUser.UserID, stock_two);
						graph.addCurve(list, stock_two_str, false, Color.Blue);
					}
					if (stock_three_enabled)
					{
						var list = db.getStockRatings(cUser.UserID, stock_three);
						graph.addCurve(list, stock_three_str, false, Color.Green);
					}
				}
				graph.ShowDialog(); //show the graph itself
			}
			else
			{
				MessageBox.Show("Must select at least one stock to graph and at least one mode to graph it", "Error");
			}
		}
	}
}
