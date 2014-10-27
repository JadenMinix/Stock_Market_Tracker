using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FileHelpers;

namespace StockAdvisorPro
{
    //awesome class. used for FileHelpers to denote columns of the .csv file
	//used to update the stock prices. Only includes relevant columns.
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    class cStock
    {
        [FieldQuoted('"')]
        public string _symbol;

        //private hides field from User as it is (currently) unnecessary
        [FieldQuoted('"')]
        private string _name;

        [FieldQuoted('"')]
        public string _lastSalePrice;

        //catches remaining columns & renders them invisible to the User
        [FieldIgnored()]
        private string[] dummyField;
    }
}
