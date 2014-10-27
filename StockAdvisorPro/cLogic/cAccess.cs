using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAdvisorPro
{
    class cAccess
    {
        public cAccess()
        { }

        /// <summary>
        /// This function calls the database manager class to register a new user
        /// with the credentials provided in the parameters.
        /// </summary>
        /// <param name="username">string of username for new account to be added.
        /// must be unique.</param>
        /// <param name="password">string of password encrypted using md5 hash for the
        /// account that is being created.</param>
        /// <returns>Returns true if account is successfully created.</returns>
        public bool registerUser(string username, string password)
        {
            bool success = false;
            cDatabaseManager db = new cDatabaseManager();
            success = db.registerUser(username, password);

            return success;
        }

        /// <summary>
        /// This function calls the database manager class to validate a user's account
        /// that is attempting to log in to the program.
        /// </summary>
        /// <param name="username">username to be checked in the database for records.</param>
        /// <param name="password">encrypted password (md5 hash) associated with input
        /// username.</param>
        /// <returns>Returns true if the account is found.</returns>
        public int validateUser(string username, string password)
        {
            int success = 0;
            cDatabaseManager db = new cDatabaseManager();
            success = db.validateUser(username, password);
			cUser.UserID = success;

            return success;
        }

		/// <summary>
		/// This function accepts a word and communicates with the database
		/// manager to remove the word from the currently logged in user's 
		/// dictionary
		/// </summary>
		/// <param name="wordToDelete">string of word to remove from dictionary</param>
		/// <returns>true if successful</returns>
		public bool deleteWordFromDictionary(string wordToDelete)
		{
			bool deleted = false;

			cDatabaseManager db = new cDatabaseManager();
			deleted = db.deleteWordDictionary(wordToDelete, cUser.UserID);

			return deleted;
		}

		/// <summary>
		/// This function accepts a word and communicates with the database
		/// manager to add the word to the currently logged in user's 
		/// dictionary along with the weight
		/// </summary>
		/// <param name="wordToAdd">string of word to add to dictionary</param>
		/// <param name="weight">weight of word to add to dictionary</param>
		/// <returns>true if successful</returns>
		public bool addWordToDictionary(string wordToAdd, int weight)
		{
			bool added = false;

			cDatabaseManager db = new cDatabaseManager();
			added = db.addwordDictionary(wordToAdd, weight, cUser.UserID);

			return added;
		}

		/// <summary>
		/// This function searches for an old word in the dictionary and replaces
		/// the word with a new word, effectively modifying the word's entry.
		/// </summary>
		/// <param name="oldWord">string of the old word to search for</param>
		/// <param name="newWord">string of the new word to replace the old</param>
		/// <param name="weight">weight of the word being modified</param>
		/// <returns>True if successful</returns>
		public bool modifyWordInDictionary(string oldWord, string newWord, int weight)
		{
			bool modified = false;

			cDatabaseManager db = new cDatabaseManager();
			modified = db.modifyWordDictionary(oldWord, newWord, cUser.UserID, weight);

			return modified;
		}

		/// <summary>
		/// This function searches for a word in the current user's dictionary and
		/// changes the word's weight to the newly input weight
		/// </summary>
		/// <param name="word">Word who's weight is to be modified</param>
		/// <param name="newWeight">New weight of the word you are modifying</param>
		/// <returns>true if successful</returns>
		public bool modifyWeightInDictionary(string word, int newWeight)
		{
			bool modified = false;

			cDatabaseManager db = new cDatabaseManager();
			modified = db.modifyWeightDictionary(word, newWeight, cUser.UserID);

			return modified;
		}

		/// <summary>
		/// This function deletes all the user's currently saved stocks and calls the
		/// database manager to add rows in the table for each of the stocks selected to
		/// save effectively replacing old entries with new. does not add anything if the
		/// stocks list is empty, but it will still delete all currently saved stocks (if any).
		/// </summary>
		/// <param name="stocks">List of all stock ID's to add to the current User's saved
		/// stocks list. if empty, currently saved stocks are deleted and none are added.</param>
		public void saveNewStocks(List<int> stocks)
		{
			cDatabaseManager db = new cDatabaseManager();
			db.deleteStocksForUser(cUser.UserID);
			if (stocks.Count > 0)
				db.saveStocksForUser(stocks, cUser.UserID);
		}
    }
}
