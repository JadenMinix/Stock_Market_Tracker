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
	public partial class fEditDictionaryValues : Form
	{
		private string input_word;
		public string Word
		{
			get { return input_word; }
			private set { input_word = value; }
		}

		private int input_weight;
		public int Weight
		{
			get { return input_weight; }
			private set { input_weight = value; }
		}


		public fEditDictionaryValues()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Overloaded constructor to set the edit boxes text if upon
		/// opening the form
		/// </summary>
		/// <param name="word">Sets the word textbox in the form </param>
		/// <param name="weight">Sets the weight textbox in the form</param>
		public fEditDictionaryValues(string word, string weight)
		{
			InitializeComponent();

			textWord.Text = word;
			textWeight.Text = weight;
		}

		/// <summary>
		/// Cancel button sets dialog result and closes form
		/// </summary>
		/// <param name="sender">default arg</param>
		/// <param name="e">default arg</param>
		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Accept button attempts to parse word and weight and sets dialog
		/// result to ok. Otherwise, alerts user of invalid entries. Closes form.
		/// </summary>
		/// <param name="sender">default arg</param>
		/// <param name="e">default arg</param>
		private void btn_Accept_Click(object sender, EventArgs e)
		{
			int in_weight;
			try
			{
				int.TryParse(textWeight.Text, out in_weight);
				input_weight = in_weight;

				if (textWord.Text.Length > 0 && textWeight.Text.Length > 0)
				{
					input_word = textWord.Text;	//save word edit data in form and close
					this.DialogResult = DialogResult.OK;
				}
				else
					MessageBox.Show("Please complete all fields", "Error");
			}
			catch
			{
				MessageBox.Show("Please enter valid number in \"Weight\" box", "Error");
			}
			Close();
		}
	}
}
