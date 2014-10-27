using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using FileHelpers;
using System.Threading;
using System.ComponentModel;

namespace StockAdvisorPro
{
    class cStockScanner
    {
        /// <summary>
        /// Sets minimum amount of hours between stock updates from last inserted quote to local time.
        /// </summary>
        private const int MIN_HOURS_BETWEEN_UPDATE = 12;

        public cStockScanner()
        { }


        /// <summary>
        /// This function gets current prices for all stock symbols on the nasdaq exchange. It then stores
        /// all symbols and their prices in the database along with the current date.
        /// </summary>
		/// <param name="bw">BackgroundWorker to report progress to main thread</param>
        /// <returns>Returns true if stocks succcessfully are queried and new entries are created in the
        /// database.</returns>
        public int getCurrentQuotes(BackgroundWorker bw)
        {
            int success = -1;   //-1 = function failed

            //pull all nasdaq stocks for price record in database
            HttpWebRequest csv_req = (HttpWebRequest)WebRequest.Create("http://www.nasdaq.com/screening/companies-by-name.aspx?letter=0&exchange=nasdaq&render=download");
            csv_req.KeepAlive = false;
            csv_req.ProtocolVersion = HttpVersion.Version10;

            bw.ReportProgress(1);
            try
            {
                HttpWebResponse csv_resp = (HttpWebResponse)csv_req.GetResponse();
                bw.ReportProgress(2);

                //build response into reader then into string for filehelper to open
                StreamReader response_reader = new StreamReader(csv_resp.GetResponseStream());
                string stock_csv = response_reader.ReadToEnd();
                response_reader.Close();
                bw.ReportProgress(3);

                FileHelperEngine engine = new FileHelperEngine(typeof(cStock));
                cStock[] res = (cStock[])engine.ReadString(stock_csv); //build results into array for easy access
                bw.ReportProgress(4);

                //more stuffs just to ensure its working. must refactor this asap.
                cDatabaseManager db = new cDatabaseManager();

                bool update_prices = false;
                //ensure prices aren't updated too frequently
                if ((DateTime.Now - db.getLastStockUpdateTime()).TotalHours >= MIN_HOURS_BETWEEN_UPDATE)
                    update_prices = true;
                else
                {
                    success = -2;   //-2 = stocks already updated with past 12 hours
                    for (int i = 5; i < 100; ++i)
                        bw.ReportProgress(i);
                }

                if (update_prices == true)
                {
                    float percent = 0.0f;
                    int count = 0;
                    success = 1;    //1 = update success
                    foreach (cStock stock in res)
                    {
                        int stock_id = db.addStockSymbol(stock._symbol);    //add symbol

                        Decimal lastSale; //used to convert string of most recent sale
                        if (Decimal.TryParse(stock._lastSalePrice, out lastSale)) //removes "n/a" entries
                        {
                            if (!db.addStockQuote(stock_id, lastSale))
                                success = -3; //-3 one or more stocks failed to insert price to db
                        }
                        percent = ((float)count / (float)res.Length) * 100f; //percent complete
                        if (percent < 5)  //acount for the 5 percent before loop begins
                            percent += 5 - percent;
                        bw.ReportProgress((int)percent);
                        ++count;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught stock quote retrieval & storage (probably can't access network):\n");
                Console.WriteLine(e.Message);
                success = -1;    //should change success to integer to determine which message box to pop (no internet, stream cannot be read etc.)
                bw.ReportProgress(100);
            }

            return success;
        }
    }
}
