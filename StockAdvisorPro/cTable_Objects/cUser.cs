using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAdvisorPro
{
	/// <summary>
	/// holds relevant user details. so far only requires User ID as the rest of
	/// the user details are inconsequential to rest of application.
	/// </summary>
	class cUser
	{
		private static int _userID;
		public static int UserID
		{
			get{ return _userID; }
			set { _userID = value; }
		}
	}
}
