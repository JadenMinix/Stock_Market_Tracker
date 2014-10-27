using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAdvisorPro
{
    class cDatabaseManager
    {
        /// <summary>
        /// Creates an instance of cDatabaseManager to handle all database
        /// manipulation. Since transitioned to LINQ, nothing is performed here.
        /// </summary>
        public cDatabaseManager()
        { }

        /// <summary>
        /// This function will register a new user for use with the system. User data is 
        /// stored in the database. Parameters do not require sanitizing.
        /// </summary>
        /// <param name="usern">This is the username for the new account</param>
        /// <param name="pass">This is the hashed password for the new account</param>
        /// <returns>Returns true if account insertion is successful</returns>
        public bool registerUser(string usern, string pass)
        {
            bool success = false;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
            {
                //create user_info object w/params
                var newUser = new USER_INFO()
                {
                    Username = usern,
                    Password = pass
                };
                db.USER_INFOs.InsertOnSubmit(newUser);

                try
                {
                    db.SubmitChanges(); //execute insert
                    //verify that was successfully inserted
                    var added = db.USER_INFOs.SingleOrDefault(a => a.Username == usern && a.Password == pass);
                    if (added != null)
                        success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception caught during account creation/insert:\n");
                    Console.WriteLine(e.Message);
                }
            }

            return success;
        }

        /// <summary>
        /// This function accepts a username and a hashed password & checks them against
        /// the database for a valid account. If the credentials input are valid, the function
        /// returns true.
        /// </summary>
        /// <param name="usern">This is a string containing the Username to be checked</param>
        /// <param name="pass">This is a string containing the md5 hash of the password associated
        /// with the above username.</param>
        /// <returns>Returns User's ID if they are valid, otherwise a -1.</returns>
        public int validateUser(string usern, string pass)
        {
            int valid = -1;  //denotes invalid user

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
            {
                var user_details = db.USER_INFOs.Where(p => p.Username.Equals(usern) && p.Password.Equals(pass));

                if (user_details.Count() == 1)
                {
                    var user = user_details.Single();
                    valid = user.id;
                }
            }
            return valid;
        }

        /// <summary>
        /// This function adds a word to the currently active User's dictionary.
        /// accepts the word, weight, & user id to attach word to correct user.
        /// </summary>
        /// <param name="word">Word to be added to the dictionary.</param>
        /// <param name="value">Weight of the word being added to the dictionary</param>
        /// <param name="user_id">ID of the current user to add to correct dictionary</param>
        /// <returns>Returns true if word was successfully added</returns>
        public bool addwordDictionary(string word, int value, int user_id)
        {
            bool success = false;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
            {
				DICTIONARY search = (from p in db.DICTIONARies
									  where p.User_id == user_id && p.Word == word
									  select p).FirstOrDefault();

				if (search == null) //record doesn't exist
				{
					//create user_info object w/params
					var newEntry = new DICTIONARY()
					{
						User_id = user_id,
						Word = word,
						Weight = value
					};

					db.DICTIONARies.InsertOnSubmit(newEntry);

					try
					{
						db.SubmitChanges(); //execute insert
						//verify that was successfully inserted
						var added = db.DICTIONARies.SingleOrDefault(a => a.Word == word && a.User_id == user_id);
						if (added != null)
							success = true;
					}
					catch (Exception e)
					{
						Console.WriteLine("Exception caught during word creation/insert:\n");
						Console.WriteLine(e.Message);
					}
				}
				else    //record exists already
				{
					success = false;
				}
            }
            return success;
        }

        /// <summary>
        /// This function removes a word from the currently active User's dictionary.
        /// accepts the word & user id to remove word from the correct user.
        /// </summary>
        /// <param name="wordToDelete">Word to be added to the dictionary.</param>
        /// <param name="user_id">ID of the current user to remove word from correct dictionary</param>
        /// <returns>Returns true if word was successfully removed</returns>
        public bool deleteWordDictionary(string wordToDelete, int user_id)
        {
            bool deleted = false;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
            {
                //find word to delete
                DICTIONARY delWord = (from p in db.DICTIONARies
                                      where p.User_id == user_id && p.Word == wordToDelete
                                      select p).FirstOrDefault();
                if (delWord != null)
                {
                    db.DICTIONARies.DeleteOnSubmit(delWord);
                    db.SubmitChanges();
                    deleted = true;
                }
            }
            return deleted;
        }

		/// <summary>
		/// This function modifies a word entry in the database, changing the old word's
		/// string to the new word.
		/// </summary>
		/// <param name="oldWord">This is the word to be changed in the dictionary</param>
		/// <param name="newWord">This is the new word for the dictionary entry</param>
		/// <param name="user_id">This is the id of the user who's dictionary is being edited</param>
		/// <param name="value">This is the weight of the word being edited</param>
		/// <returns>true if word modification was successful</returns>
        public bool modifyWordDictionary(string oldWord, string newWord, int user_id, int value)
        {
            bool modified = false;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				DICTIONARY search = (from p in db.DICTIONARies
									 where p.User_id == user_id && p.Word == oldWord
									 select p).FirstOrDefault();

				if (search != null) //record does exist
				{
					//create user_info object w/params
					var newEntry = new DICTIONARY()
					{
						User_id = user_id,
						Word = newWord,
						Weight = value
					};

					db.DICTIONARies.DeleteOnSubmit(search);	//delete old word
					db.DICTIONARies.InsertOnSubmit(newEntry);	

					try
					{
						db.SubmitChanges(); //execute insert
						//verify that was successfully inserted
						var added = db.DICTIONARies.SingleOrDefault(a => a.Word == newWord && a.User_id == user_id);
						if (added != null)
							modified = true;
					}
					catch (Exception e)
					{
						Console.WriteLine("Exception caught during word update:\n");
						Console.WriteLine(e.Message);
					}
				}
			}
            return modified;
        }

		/// <summary>
		/// This function modifies a word entry in the database, changing the old word's
		/// weight value to the input weight.
		/// </summary>
		/// <param name="word">This is the word to be edited in the dictionary</param>
		/// <param name="newWeight">This is the new weight of the word being edited</param>
		/// <param name="user_id">This is the id of the user who's dictionary is being edited</param>
		/// <returns>true if weight modification was successful</returns>
        public bool modifyWeightDictionary(string word, int newWeight, int user_id)
        {
			bool modified = false;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				DICTIONARY search = (from p in db.DICTIONARies
									 where p.User_id == user_id && p.Word == word
									 select p).FirstOrDefault();

				if (search != null) //record does exist
				{
					//create user_info object w/params
					var newEntry = new DICTIONARY()
					{
						User_id = user_id,
						Word = word,
						Weight = newWeight
					};

					db.DICTIONARies.DeleteOnSubmit(search);	//delete old word
					db.DICTIONARies.InsertOnSubmit(newEntry);

					try
					{
						db.SubmitChanges(); //execute insert
						//verify that was successfully inserted
						var added = db.DICTIONARies.SingleOrDefault(a => a.Word == word && a.Weight == newWeight && a.User_id == user_id);
						if (added != null)
							modified = true;
					}
					catch (Exception e)
					{
						Console.WriteLine("Exception caught during word update:\n");
						Console.WriteLine(e.Message);
					}
				}
			}
			return modified;
        }

        /// <summary>
        /// This method accepts a string of a stock symbol and adds it to the
        /// database's stock table. It is typically only called when the program
        /// first collects stock data or different markets (with different symbols)
        /// are queried.
        /// </summary>
        /// <param name="symbol">This is a string of the symbol to be added to the database.</param>
        /// <returns>Returns and integer containing the database ID of the stock that was added,
        /// or a -1 if the stock failed to add. If the stock already exists, the id of the stock
        /// in the database is returned.</returns>
        public int addStockSymbol(string symbol)
        {
            int success = -1;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
            {
                //create user_info object w/params
                var newEntry = new STOCK()
                {
                    Symbol = symbol
                };

                STOCK search = db.STOCKs.Where(r => r.Symbol == symbol).SingleOrDefault();
                if (search == null) //record doesn't exist yet...
                {
                    db.STOCKs.InsertOnSubmit(newEntry);
                    try
                    {
                        db.SubmitChanges(); //execute insert
                        //verify that was successfully inserted
                        var added = db.STOCKs.SingleOrDefault(a => a.Symbol == symbol);
                        if (added != null)
                            success = added.id;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception caught during stock creation/insert:\n");
                        Console.WriteLine(e.Message);
                    }
                }
                else    //record exists!
                {
                    success = search.id;
                }
            }
            return success;
        }

        /// <summary>
        /// This function gets the last row in the stock prices table (most recent entry)
        /// and returns the date & time associated with that entry.
        /// </summary>
        /// <returns>DateTime object containing date and time of last entry in stock price</returns>
        public DateTime getLastStockUpdateTime()
        {
            DateTime last_insert = new DateTime(2004, 11, 23);  //if no records are found, return arbitrarily distant date to force an update.

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
            {
                STOCK_PRICE last_stock = db.STOCK_PRICEs.OrderByDescending(a => a.id).FirstOrDefault();

                if (last_stock != null)
                {
                    last_insert = last_stock.Date;
                }
            }
            return last_insert;
        }

        /// <summary>
        /// This function adds an entry to the stock price table. It records 
        /// the stock ID (retrieved from symbol table) and the latest
        ///  sale price associated with that stock.
        /// </summary>
        /// <param name="stockID">database ID of the stock to be added</param>
        /// <param name="lastPrice">Decimal of the most recent sale price of that stock</param>
        /// <returns></returns>
        public bool addStockQuote(int stockID, decimal lastPrice)
        {
            bool quote_added = false;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
            {
                DateTime current = DateTime.Now;
                //create user_info object w/params
                var newEntry = new STOCK_PRICE()
                {
                    Stock_id = stockID,
                    Price = lastPrice,
                    Date = current
                };

                db.STOCK_PRICEs.InsertOnSubmit(newEntry);
                
                try
                {
                    db.SubmitChanges(); //execute insert
                    //verify that was successfully inserted
                    var added = db.STOCK_PRICEs.SingleOrDefault(a => a.Stock_id == stockID && a.Date == current);
                    if (added != null)
                        quote_added = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception caught during stock quote creation/insert:\n");
                    Console.WriteLine(e.Message);
                }
            }
            return quote_added;
        }

		/// <summary>
		/// This function gets the last row in the article table (most recent entry)
		/// and returns the date & time associated with that entry.
		/// </summary>
		/// <returns>DateTime object containing date and time of last entry in article.
		/// If no articles are found, returns arbitrary date of 8-31-2997</returns>
		public DateTime getLastArticleUpdateTime()
		{
			DateTime last_insert = new DateTime(1997, 8, 31);	//if no articles are found, return arbitrarily distant date to force update.

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				ARTICLE last_article = db.ARTICLEs.OrderByDescending(a => a.Article_date).FirstOrDefault();

				if (last_article != null)
				{
					last_insert = last_article.Article_date;
				}
			}
			return last_insert;
		}

		/// <summary>
		/// This function adds an article to the database in plaintext
		/// form. The article will be stored with the date associated with
		/// it.
		/// </summary>
		/// <param name="article_text">Plaintext string of article from web scraper</param>
		/// <param name="article_date">Date that article</param>
		/// <returns>returns true if successfully added article</returns>
		public bool addArticle(string article_text, DateTime article_date)
		{
			bool article_added = false;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var newEntry = new ARTICLE()
				{
					Article_text = article_text,
					Article_date = article_date
				};

				db.ARTICLEs.InsertOnSubmit(newEntry);

				try
				{
					db.SubmitChanges();
					article_added = true;
					//should add article title so easily check for proper insert
				}
				catch (Exception e)
				{
					Console.WriteLine("Exception caught during article insert:\n");
					Console.WriteLine(e.Message);
					article_added = false;
				}
			}

			return article_added;
		}

		/// <summary>
		/// This method searches the database for articles marked as 'unreviewed'
		/// i.e. containing a 0 in the Reviewed field and returns the article text.
		/// </summary>
		/// <returns>Dictionary containing strings of articles with the int ID as the key</returns>
		public Dictionary<int, string> getUnreviewedArticles()
		{
			Dictionary<int, string> articles = new Dictionary<int, string>();

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var result = (from p in db.ARTICLEs
							where p.Reviewed == false
							select p);

				articles = result.ToDictionary(d => d.id, d => d.Article_text);
			}

			return articles;
		}

		/// <summary>
		/// This method searches the database for stocks and returns a dictionary
		/// containing all stocks symbols stored in the database with the associated
		/// ID.
		/// </summary>
		/// <returns>Dictionary containing strings of stock symbols with the int ID as the key</returns>
		public Dictionary<int, string> getStockSymbols()
		{
			Dictionary<int, string> stocks = new Dictionary<int, string>();

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var result = (from p in db.STOCKs
							  select p);
				stocks = result.ToDictionary(d => d.id, d => d.Symbol);
			}

			return stocks;
		}

		/// <summary>
		/// This function checks the database and retrieves the dictionary of the
		/// User whos ID is passed in. The dictionary is actually returned to the user
		/// as a dictionary word and associated weight of the word.
		/// </summary>
		/// <param name="user_id">This is the ID of the user who's dictionary is being
		/// retrieved.</param>
		/// <returns>Returns a dictionary of the words in the user's dictionary. It has the
		/// string of the word as the key (because they are unique) and the weight as the value</returns>
		public Dictionary<string, int> getUserDictionary(int user_id)
		{
			Dictionary<string, int> dict = new Dictionary<string, int>();

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var result = (from p in db.DICTIONARies
							  where p.User_id == user_id
							  select p);
				dict = result.ToDictionary(d => d.Word, d => d.Weight);
			}

			return dict;
		}

		/// <summary>
		/// This function adds a review of an article after being analyzed. It returns
		/// true if it was successful.
		/// </summary>
		/// <param name="user_id">User id of user who analyzed the article</param>
		/// <param name="stock_id">Stock id of the stock that was associated with the article</param>
		/// <param name="article_id">Article id of the article that was reviewed</param>
		/// <param name="score">Score of the article after being rated in analysis phase</param>
		/// <returns>returns true if analysis was sucessfully added to the database</returns>
		public bool addAnalysis(int user_id, int stock_id, int article_id, int score)
		{
			bool success = false;

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				REVIEW search = (from p in db.REVIEWs
									 where p.Article_id == article_id 
									 && p.User_id == user_id
									 && p.Stock_id == stock_id
									 select p).FirstOrDefault();

				if (search == null) //record doesn't exist
				{
					//create user_info object w/params
					var newEntry = new REVIEW()
					{
						User_id = user_id,
						Stock_id = stock_id,
						Article_id = article_id,
						Score = score
					};

					db.REVIEWs.InsertOnSubmit(newEntry);

					try
					{
						db.SubmitChanges(); //execute insert
						//verify that was successfully inserted
						var added = db.REVIEWs.SingleOrDefault(a => a.Stock_id == stock_id && a.User_id == user_id && a.Article_id == article_id);
						if (added != null)
							success = true;
					}
					catch (Exception e)
					{
						Console.WriteLine("Exception caught during review insert:\n");
						Console.WriteLine(e.Message);
					}
				}
				else    //record exists already
				{
					success = false;
				}
			}
			return success;
		}

		/// <summary>
		/// This function sets the specified article's "Reviewed" value in the database
		/// to 1 to indicate it has been analyzed.
		/// </summary>
		/// <param name="article_id">ID of the article to set Reviewed column</param>
		public void setArticlesAnalyzed(int article_id)
		{
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var search = (from p in db.ARTICLEs
							 where p.id == article_id
							select p).FirstOrDefault();

				search.Reviewed = true;
				db.SubmitChanges();
			}
		}

		/// <summary>
		/// This function sets all articles as unanalyzed ("Reviewed" column set to 0).
		/// </summary>
		public void setArticlesNotAnalyzed()
		{
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				db.ExecuteCommand("update ARTICLE set Reviewed = 0");
			}
		}

		/// <summary>
		/// This function takes the user's id and drops all reviews associated with that id
		/// (usually) in preparation for re-analyzing all articles.
 		/// </summary>
		/// <param name="user_id">ID of the User whos reviews will be dropped</param>
		public void dropCurrentArticleReviews(int user_id)
		{
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				db.ExecuteCommand("delete from REVIEW where User_id = {0}", user_id);
			}
		}

		/// <summary>
		/// This function saves all the stocks in the list into the saved
		/// stocks table in the database so the user who's id is attached to
		/// the stock can easily retrieve it later.
		/// </summary>
		/// <param name="stock_ids">List of all the stock ID's to save to the User's id</param>
		/// <param name="user_id">ID of the user to saved the stocks to</param>
		public void saveStocksForUser(List<int> stock_ids, int user_id)
		{
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				foreach (int id in stock_ids) 
				{
					//create entry for each stock saved
					var entry = new SAVED_STOCK()
					{
						Stock_id = id,
						User_id = user_id
					};

					db.SAVED_STOCKs.InsertOnSubmit(entry);

					try
					{
						db.SubmitChanges();
					}
					catch (Exception e)
					{
						Console.WriteLine("Exception caught during saved_stock insert:\n");
						Console.WriteLine(e.Message);
					}
				}
			}
		}

		/// <summary>
		/// This function deletes all saved stocks from the database for the User
		/// who's ID is passed in. Is called when new stocks are to be saved, the
		/// old are simply removed before the new are added.
		/// </summary>
		/// <param name="user_id">ID of user who's saved stocks should be deleted</param>
		public void deleteStocksForUser(int user_id)
		{
            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var saved_stocks = db.SAVED_STOCKs.Where(s => s.User_id == user_id);

				db.SAVED_STOCKs.DeleteAllOnSubmit(saved_stocks);
				db.SubmitChanges();
			}
		}

		/// <summary>
		/// Gets all stock scores for a specific stock's id.
		/// Returns list of pairs containing stock's x and y values for
		/// plotting the score over time.
		/// </summary>
		/// <param name="stock_id">ID of stock who's scores are being gotten</param>
		/// <returns>List of pairs containing all stock's scores and times recorded
		/// with the scores.</returns>
		public List<KeyValuePair<double, double>> getStockRatings(int user_id, int stock_id)
		{
			List<KeyValuePair<double, double>> date_ratings = new List<KeyValuePair<double, double>>();

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				var stock_reviews = from p in db.REVIEWs
									where p.User_id == user_id && p.Stock_id == stock_id
									select p;

				foreach (REVIEW rv in stock_reviews)
				{
					var article_date = from d in db.ARTICLEs
									   where d.id == rv.Article_id
									   select d.Article_date;
					DateTime art_date = article_date.FirstOrDefault();

					KeyValuePair<double, double> temp = new KeyValuePair<double,double>(art_date.Date.ToOADate(), rv.Score);
					date_ratings.Add(temp);
				}
				date_ratings.Sort(CompareKVP);	//sort list so all points appear in sequence
			}

			return date_ratings;
		}

		/// <summary>
		/// Gets all stock prices for a specific stock's id.
		/// Returns list of pairs containing stock's x and y values for
		/// plotting the price over time.
		/// </summary>
		/// <param name="stock_id">ID of stock who's prices are being gotten</param>
		/// <returns>List of pairs containing all stock's prices and times recorded
		/// with the prices.</returns>
		public List<KeyValuePair<double, double>> getStockPrices(int stock_id)
		{
			List<KeyValuePair<double, double>> date_prices = new List<KeyValuePair<double, double>>();

            using (var db = new stock_advisorDataContext(Program.ConnectionString))
			{
				//only select prices from table whos id matches passed in id
				var stock_prices = from d in db.STOCK_PRICEs
								   where d.Stock_id == stock_id
								   select d;

				foreach (STOCK_PRICE sp in stock_prices)
				{
					DateTime prc_date = sp.Date.Date;
					KeyValuePair<double, double> temp = new KeyValuePair<double, double>(prc_date.ToOADate(), (double)sp.Price);
					date_prices.Add(temp);
				}
				date_prices.Sort(CompareKVP);
			}

			return date_prices;
		}

        /// <summary>
        /// This function gets the number of entries inside the 'STOCK'
        /// table of the database.
        /// </summary>
        /// <returns>Number of entries in STOCK table. Default 0.</returns>
        public int getNumStockEntries()
        {
            int num_stocks = 0;

            string stmt = "SELECT COUNT(*) FROM dbo.STOCK";
            
            using (SqlConnection thisConnection = new SqlConnection(Program.ConnectionString))
            using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
            {
                thisConnection.Open();
                num_stocks = (int)cmdCount.ExecuteScalar();
                thisConnection.Close();
            }
            
            return num_stocks;
        }

		/// <summary>
		/// Compare function for keyvalue pairs. returns integer when key of a calls
		/// compareTo on the key in b.
		/// </summary>
		/// <param name="a">first pair whose key is to be checked</param>
		/// <param name="b">second pair whose key will be compared to</param>
		/// <returns>+1 if a.key > b.key, 0 if a.key = b.key, -1 a.key lessthan b.key </returns>
		static int CompareKVP(KeyValuePair<double, double> a, KeyValuePair<double, double> b)
		{
			return a.Key.CompareTo(b.Key);
		}
	}
}
