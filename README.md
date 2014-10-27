Stock_Market_Tracker
Author: Jaden Minix
====================

***THIS APPLICATION REQUIRES AN INSTANCE OF SQL SERVER TO BE INSTALLED ON YOUR PC***

This stock market tracking application records various pieces of data related to the stock market. It can record the current prices of all stocks on the NASDAQ market in a local database. It also allows the user to scrape articles related to the stock market from http://www.investopedia.com/markets/stock-analysis/ storing each article as plaintext in the local database. The application then performs data mining on each of the stored articles to determine the stocks mentioned in the article and rates each article based on how positive or negative the article is. The article rating system is based on a word frequency count of positive and negative words, that are defined by the user and stored in the local database. Article ratings are also stored in the database to allow for graph generation of article ratings over time and stock prices over time to visualize the data and allow the user to look for trends. 
