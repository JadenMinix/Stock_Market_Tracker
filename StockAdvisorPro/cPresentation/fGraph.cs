using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace StockAdvisorPro
{
	public partial class fGraph : Form
	{
		private ZedGraphControl zg;
		private GraphPane price_pane;
		private GraphPane score_pane;
		private MasterPane master;

		/// <summary>
		/// Constructor for graph form. Sets form up to be used for graphing, including
		/// adding two graphs to the main graph control and setting all properties to 
		/// be used.
		/// </summary>
		public fGraph()
		{
			InitializeComponent();
			zg = zedGraphMain;	//get graph component
			master = zedGraphMain.MasterPane;	//pull master from component
			
			master.PaneList.Clear();			//clear existing graph data

			price_pane = new GraphPane();		//create two graphs, one for score/time and one for price/time
			score_pane = new GraphPane();

			price_pane.XAxis.Type = AxisType.Date;	//set both graphs x-axis to type of date
			score_pane.XAxis.Type = AxisType.Date;

			//set panels y-axis spacing so the graphs appear congruent
			price_pane.YAxis.MinSpace = 80;
			score_pane.YAxis.MinSpace = 80;
			price_pane.Y2Axis.MinSpace = 20;
			score_pane.Y2Axis.MinSpace = 20;

			//set y-axis labels so user knows what they are
			price_pane.YAxis.Title.Text = "Cost in USD";
			score_pane.YAxis.Title.Text = "Arbitrary Score Units";

            price_pane.YAxis.Title.FontSpec.Size = 5.0f * (this.Size.Width / 100);
            score_pane.YAxis.Title.FontSpec.Size = 4.0f * (this.Size.Width / 100);
             
			//add both graphs to master pane
			master.Add(price_pane);
			master.Add(score_pane);

			//set scale factor to common so they zoom together and the x-axis moves together
			master.IsCommonScaleFactor = true;

			//set master graph options
			master.Title.IsVisible = true;
			master.Title.Text = "Stock Data Over Time";
			master.Margin.All = 10;
			master.InnerPaneGap = 5;
			

			//set graphs to be on top of one-another
			using (Graphics g = this.CreateGraphics())
			{
				master.SetLayout(g, PaneLayout.SingleColumn);
				master.AxisChange(g);
			}

			//set x-axis to be syncrhonized
			zedGraphMain.IsSynchronizeXAxes = true;
			
			//set graph scrolling properties
			zedGraphMain.IsShowHScrollBar = true;
			zedGraphMain.IsShowVScrollBar = true;
			zedGraphMain.IsAutoScrollRange = true;
		}

		/// <summary>
		/// called when the form is loaded. sets the graph size appropiately.
		/// </summary>
		/// <param name="sender">default param.</param>
		/// <param name="e">default param.</param>
		private void fGraph_Load(object sender, EventArgs e)
		{
			setGraphSize();
		}

		/// <summary>
		/// Changes the size of the graphs in the zedgraph componenet on this form.
		/// Called when the form is resized.
		/// </summary>
		private void setGraphSize()
		{
            zedGraphMain.Location = new Point(10, 10);

            zedGraphMain.Size = new Size(ClientRectangle.Width - 20,
                                ClientRectangle.Height - 20);
		}

		/// <summary>
		/// This function adds a curve to one of the graphs in the zedgraph component in 
		/// this form. It takes a list of the values to add as well as a string of the
		/// stock represented and a bool represent which graph to add the curve to.
		/// </summary>
		/// <param name="values">List of x/y values for the graph.</param>
		/// <param name="symbol">String of the stock symbol associated with the curve.</param>
		/// <param name="value_over_time">True if value over time, false if score over time</param>
		/// <param name="col">Color of the line to add.</param>
		public void addCurve(List<KeyValuePair<double, double>> values, string symbol, bool value_over_time, Color col)
		{
			GraphPane pane;
			SymbolType sym;

			if (value_over_time)
			{
				pane = price_pane;
				sym = SymbolType.Circle;	//value/time gets circles on graph
				//pane.YAxis.
			}
			else
			{
				pane = score_pane;
				sym = SymbolType.Diamond; //score/time gets diamonds
			}

			PointPairList plist = new PointPairList();

			foreach (KeyValuePair<double, double> kv in values)
			{
				PointPair pair = new PointPair(kv.Key, kv.Value);

				if (!plist.Contains(pair)) //prevent duplicate points
				{
					plist.Add(pair);		//add to list
				}
			}

			LineItem newCurve = pane.AddCurve(symbol,
				plist, col, sym);

			//reconfigure graph to change
			zg.AxisChange();
		}

		/// <summary>
		/// Called when the form is resized. Calls the setGraphSize function
		/// to change the size of the graphs in the graph component so they
		/// don't appear skewed or spew data offscreen.
		/// </summary>
		/// <param name="sender">default param.</param>
		/// <param name="e">default param.</param>
		private void fGraph_Resize(object sender, EventArgs e)
		{
			setGraphSize();
		}
	}
}
