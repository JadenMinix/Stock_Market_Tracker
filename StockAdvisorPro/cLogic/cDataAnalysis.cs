using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockAdvisorPro
{
	class cDataAnalysis
	{
		public cDataAnalysis()
		{ }

		/// <summary>
		/// This function analyzes all articles stored in the database that
		/// are marked as unreviewed. The algorithm is performed and all stocks
		/// associated with the article reviewed are saved with the score from
		/// that specifc article.
		/// </summary>
		/// <param name="bw">BackgroundWorker to report progress of function
		/// to main thread in case of slow review;</param>
		/// <returns></returns>
		public int analyzeArticles(BackgroundWorker bw)
		{
			int success = 1;	//1 for successful analysis
			cDatabaseManager db = new cDatabaseManager();

			Dictionary<int, string> articles = db.getUnreviewedArticles();
			Dictionary<int, string> stocks = db.getStockSymbols();
			Dictionary<string, int> dict = db.getUserDictionary(cUser.UserID);

			float percent = 0.0f;
			int count = 0;

			if (articles.Count == 0) //no unreviewed articles
				success = 0;		 //0 for all articles already scanned

			foreach (var a in articles)
			{
				List<KeyValuePair<int, string>> listed_stocks = new List<KeyValuePair<int, string>>();
				int article_score = 0;

				//find all stocks mentioned in the article
				foreach (var s in stocks)
				{
					string expr = "\\W" + s.Value + "\\W";

					Regex r = new Regex(expr);	//use regex on stock symbol to only find symbols with non-characters near it
					Match m = r.Match(a.Value);

					if (m.Success)
					{
						listed_stocks.Add(s);
					}
				}

				//find occurences of words contained in the dictionary
				foreach (var e in dict)
				{
					int currentIndex = 0;
					while ((currentIndex = a.Value.IndexOf(e.Key, currentIndex, StringComparison.OrdinalIgnoreCase)) != -1)
					{
						currentIndex++;

						//add word score to article total score
						if (e.Value > 0)
							++article_score;
						else
							--article_score;

						//article_score += e.Value;
					}
				}

				//save article score for each entry
				foreach (var entry in listed_stocks)
				{
					if (!db.addAnalysis(cUser.UserID, entry.Key, a.Key, article_score))
						success = -1;	//failure during database insert
				}

				db.setArticlesAnalyzed(a.Key); //set article as analyzed
				percent = ((float)count / (float)articles.Count) * 100f;
				bw.ReportProgress((int)percent);
				++count;
			}

			return success;
		}

		/// <summary>
		/// This function prepares then initiates the re-analysis of all articles
		/// currently stored in the database. It drops all article reviews for current
		/// user and sets all article in Database to not-analyzed.
		/// </summary>
		/// <param name="bw">BackgroundWorker to send to analyzeArticles function.</param>
		/// <returns></returns>
		public int reAnalyzeAllArticles(BackgroundWorker bw)
		{
			cDatabaseManager db = new cDatabaseManager();
			db.dropCurrentArticleReviews(cUser.UserID);
			db.setArticlesNotAnalyzed();
			return analyzeArticles(bw);
		}
	}
}
