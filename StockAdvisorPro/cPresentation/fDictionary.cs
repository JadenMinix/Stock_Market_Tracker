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
	public partial class fDictionary : Form
	{
		public fDictionary()
		{
			InitializeComponent();
		}

		/// <summary>
		/// called upon loading of the form. populates the datagrid with the
		/// dictionary from database.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fDictionary_Load(object sender, EventArgs e)
		{
			updateDictionaryGrid();
		}

		/// <summary>
		/// Button handler for add word button on the dictionary screen. opens
		/// the word edit dialog and accepts a word and weight and attempts
		/// to insert it in the database
		/// </summary>
		/// <param name="sender">default arg</param>
		/// <param name="e">default arg</param>
		private void btn_addWord_Click(object sender, EventArgs e)
		{
			fEditDictionaryValues add = new fEditDictionaryValues();
			add.Text = "Add word";
			add.ShowDialog();
			if (add.DialogResult == DialogResult.OK)
			{
				cAccess acc = new cAccess();

				if (acc.addWordToDictionary(add.Word, add.Weight))
				{
					updateDictionaryGrid();
					MessageBox.Show("Word: " + add.Word + " successfully added!");
				}
				else
					MessageBox.Show("Word not added to dictionary.");
			}
		}

		/// <summary>
		/// Button handler for remove word button on the dictionary screen. opens
		/// dialog confirmation and removes word from database and dictionary list
		/// if user selects accept.
		/// </summary>
		/// <param name="sender">default arg</param>
		/// <param name="e">default arg</param>
		private void btn_removeWord_Click(object sender, EventArgs e)
		{
			if (gridView_Dictionary.SelectedRows.Count > 1)
			{
				MessageBox.Show("Please select one word at a time");
			}
            else if (gridView_Dictionary.SelectedRows.Count < 1)
            {
                MessageBox.Show("Must select at least one word");
            }
			else
			{
				var id = gridView_Dictionary.SelectedRows[0].Index;	//position relative to gridview
				var word = gridView_Dictionary.SelectedRows[0].Cells[0].Value.ToString();	//word selected

				DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove word: " + word + " ?", "Confirm", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					cAccess acc = new cAccess();
					bool success = acc.deleteWordFromDictionary(word);
					if (success)
					{
						updateDictionaryGrid();
						MessageBox.Show("Word: " + word + " successfully deleted from dictionary", "Removed");
					}
					else
						MessageBox.Show("Error removing word from dictionary", "Error");
				}
			}
		}

		/// <summary>
		/// Updates the grid displayed to the user containing all dictionary entries.
		/// Should be called whenever the dictionary is modified so the changes will
		/// be displayed to the user.
		/// </summary>
		private void updateDictionaryGrid()
		{
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var user_dict = from d in db.DICTIONARies
								where d.User_id == cUser.UserID
								select new { d.Word, d.Weight, };
				dictionaryBind.DataSource = user_dict;
				gridView_Dictionary.DataSource = dictionaryBind;
			}
		}

		/// <summary>
		/// Button handler for edit word button on the dictionary screen. Opens
		/// edit dialog allowing the user to modify the word's values.
		/// </summary>
		/// <param name="sender">default arg</param>
		/// <param name="e">default arg</param>
		private void btn_editWord_Click(object sender, EventArgs e)
		{
			if (gridView_Dictionary.SelectedRows.Count > 1)
			{
				MessageBox.Show("Please select one word at a time");
			}
            else if (gridView_Dictionary.SelectedRows.Count < 1)
            {
                MessageBox.Show("Must select at least one word");
            }
			else
			{
				var word = gridView_Dictionary.SelectedRows[0].Cells[0].Value.ToString();	//word selected
				var weight = gridView_Dictionary.SelectedRows[0].Cells[1].Value.ToString();

				fEditDictionaryValues edit = new fEditDictionaryValues(word, weight);

				edit.Text = "Edit word";
				edit.ShowDialog();

				if (edit.DialogResult == DialogResult.OK)
				{
					cAccess acc = new cAccess();

					if (word != edit.Word)
					{
						acc.modifyWordInDictionary(word, edit.Word, edit.Weight);
					}
					if (weight != edit.Weight.ToString())
					{
						acc.modifyWeightInDictionary(edit.Word, edit.Weight);
					}
					updateDictionaryGrid();
				}
			}
		}
	}
}
