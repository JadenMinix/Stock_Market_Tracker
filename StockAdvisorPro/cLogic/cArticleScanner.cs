using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace StockAdvisorPro
{
    class cArticleScanner
    {
		private Uri baseUrl;
		private cDatabaseManager _db;
		private DateTime _lastArticleUpdate;
		private bool _articlesStored = true;

        public cArticleScanner()
        {
			baseUrl = new Uri("http://www.investopedia.com/markets/stock-analysis/");
			_db = new cDatabaseManager();
			_lastArticleUpdate = _db.getLastArticleUpdateTime();
			if (_lastArticleUpdate.Year == 1997)
				_articlesStored = false;
		}

		/// <summary>
		/// This function sets the last article update time to the parameter passed in.
		/// It is used when the User attempts to check for articles and there are no records
		/// in the database for the date of last update. The user can then select how far back
		/// the application can set the previous article update so it will update articles until
		/// that date.
		/// </summary>
		/// <param name="article_date">Date to go back to scan the latest articles</param>
		public void setLastArticleDate(DateTime article_date)
		{
			_lastArticleUpdate = article_date;
		}

		/// <summary>
		/// This function will check investopedia for the date of the latest article and compare it
		/// with the date of the most recent entry in the ARTICLE table. If the latest article is 
		/// a day newer than the most recent entry in the database, the function returns 1. If it is
		/// not newer, it returns 0, and if the database lacks articles it returns -1.
		/// </summary>
		/// <returns>Returns integer describing case. 1 if new articles, 0 if not, -1 if there
		/// are no articles currently stored.</returns>
        public int checkForNewArticles()
        {
            int return_val = 0;

			if (_articlesStored == false)
				return_val = -1;
			else	//articles exist in db, consequently should check for NEW articles
			{
				var htmlFromWeb = new HtmlWeb();
				//DON'T FORGET TO DISABLE PEERBLOCK FIRST!!
				var document = htmlFromWeb.Load(baseUrl.AbsoluteUri);

				if (document.DocumentNode != null)
				{
                    //HtmlNode bodyNode = document.DocumentNode.SelectSingleNode("//div[@class=\"box s8 small group related-pic-box\"]");
					HtmlNode mainList = document.DocumentNode.SelectSingleNode("//ol[@class='list']");
					var nodes = mainList.SelectNodes(".//li");

					if (nodes != null)
					{
						string article_date = nodes[0].SelectSingleNode(".//div[@class='item-date']").InnerText; //grab date from first article
						DateTime latest_article_date = DateTime.Parse(article_date);

						//latest article is more recent than last inserted article by atleast a day
						if ((latest_article_date - _lastArticleUpdate).TotalDays > 0)
						{
							//should also probably compare latest article names to prevent false positives for articles added later the same day
							return_val = 1;
						}
					}
				}
			}
            return return_val;
        }

		/// <summary>
		/// This function will attempt to query investopedia for the latest articles on
		/// stock trends & process each new article by storing it in the database. It will
		/// scan each page calling getNewaRticlesOnPage & continue querying through the following
		/// pages if the articles still haven't caught up to the last inserted article date.
		/// </summary>
		/// <param name="bw">BackgroundWorker to report progress to main thread</param>
		/// <returns>Returns true if article update was successful</returns>
		public bool getLatestArticles(BackgroundWorker bw)
		{
			bool success = true;

			var htmlFromWeb = new HtmlWeb();
			var document = htmlFromWeb.Load(baseUrl.AbsoluteUri);
            document = htmlFromWeb.Load(baseUrl.AbsoluteUri); //load again to skip awful "please wait 5 seconds or click here to continue" page

			bw.ReportProgress(1, "Page 1");
			if (document.DocumentNode != null)
			{
				//grab article nodes out of page
                HtmlNode bodyNode = document.DocumentNode.SelectSingleNode("//div[@class='box big-image']");
				HtmlNode mainList = bodyNode.SelectSingleNode(".//ol[@class='list']");
				var nodes = mainList.SelectNodes(".//li");

				if (nodes != null)	//articles on page
				{
					int page_count = 1; //used for reporting progress on main thread
					while (getNewArticlesOnPage(nodes, bw))	//pull all new articles from page and stores them. returns true if more (new) articles on next page.
					{
						++page_count;
						bw.ReportProgress(1, "Page " + page_count);
						//get link to next page of articles
						HtmlNode next_page_node = document.DocumentNode.SelectSingleNode("//li[@class='next']");

						if (next_page_node != null)
						{
							HtmlNode link = next_page_node.SelectSingleNode(".//a[@href]");
							HtmlAttribute link_attr = link.Attributes["href"];
							string href = link_attr.Value;
							Uri next_page_url = new Uri(baseUrl, href);	//pulls link to next page of articles

							document = htmlFromWeb.Load(next_page_url.AbsoluteUri);
							if (document != null)
							{
                                mainList = document.DocumentNode.SelectSingleNode("//ol[@class='list']");
								nodes = mainList.SelectNodes(".//li"); //re-set nodes to next page's articles list
							}
							else
							{
								success = false;
								break;	//next page couldn't be loaded, assume failure & break loop
							}
						}
						else //last page (probably) hit. end loop.
							break;
					}
				}
				else //couldn't find children
					success = false;
			}
			else //document couldn't be loaded
				success = false;

			return success;
		}

		/// <summary>
		/// This function will go through all articles on a page on investopedia.com and
		/// process each article until the most recently added article is met.
		/// </summary>
		/// <param name="nodes">HtmlNode list of all articles on a particular webpage</param>
		/// <param name="bw">BackgroundWorker to report progress to main thread</param>
		/// <returns>Returns true if all articles on the page were new. False if the previously 
		/// last scanned article is found.</returns>
		private bool getNewArticlesOnPage(HtmlNodeCollection nodes, BackgroundWorker bw)
		{
			bool new_article = true;

			DateTime article_date = new DateTime();

			float percent = 0.0f;	//used to calculate progress bar
			int count = 1;
			foreach (HtmlNode item in nodes)
			{
				article_date = DateTime.Parse(item.SelectSingleNode(".//div[@class='item-date']").InnerText);
				if ((article_date - _lastArticleUpdate).TotalDays >= 0)
				{
					processArticle(item, article_date);

					percent = ((float)count / (float)nodes.Count) * 100f;

					bw.ReportProgress((int)percent);
					count++;
				}
				else
				{
					for (int i = 100 - (int)percent; i < 100; ++i)
						bw.ReportProgress(i);
					new_article = false;
					break;	//caught up to last inserted article, end loop
				}
			}

			return new_article;
		}

		/// <summary>
		/// This function will take the article node from the list of articles on
		/// investopdia.com and pull the article text & store it in the database.
		/// </summary>
		/// <param name="article_node">HtmlNode of article from list</param>
		/// <param name="article_date">Date associated with the article</param>
		/// <returns>Returns true if the artile is successfully added to the
		/// database.</returns>
		private bool processArticle(HtmlNode article_node, DateTime article_date)
		{
			bool success = false;

			HtmlNode link = article_node.SelectSingleNode(".//a[@href]");
			HtmlAttribute link_attr = link.Attributes["href"];
			string href = link_attr.Value;
			Uri Article_url = new Uri(baseUrl, href);

			var htmlFromWeb = new HtmlWeb();
			//DON'T FORGET TO DISABLE PEERBLOCK FIRST!!
			var document = htmlFromWeb.Load(Article_url.AbsoluteUri);

			if (document.DocumentNode != null)
			{
                HtmlNode contentNode = document.DocumentNode.SelectSingleNode(".//div[@class='content-box']");

				//remove HTML related to ads
				HtmlNode adNode = contentNode.SelectSingleNode(".//div[@class='ad-textlink']");
				if (adNode != null)
					adNode.Remove();

				StringBuilder sb = new StringBuilder();
				foreach (HtmlNode node in contentNode.SelectNodes(".//text()"))	//select all text from tags within contentNode
				{
					sb.AppendLine(node.InnerText);
				}

				sb.Replace("&amp;", "&");	//replace garbage for readability
				sb.Replace("--&gt;", "");
				sb.Replace("#-ad_banner-#", "");

				string stripped_article = sb.ToString().Trim();
				
				//dump article text to console (debugging purposes)
				//Console.WriteLine(stripped_article);

				//check for success in article submission
				if (_db.addArticle(stripped_article, article_date))
					success = true;
			}

			return success;
		}
    }
}
