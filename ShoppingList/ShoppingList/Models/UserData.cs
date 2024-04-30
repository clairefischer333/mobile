﻿using System;
namespace ShoppingList.Models
{
    public class UserDataCollection
	{
		//variable names need to be exact 
		public UserData[] UserDataItems { get; set; }
	}

    public class UserData
	{
		public string dataID { get; set; }
		public string dataValue { get; set; }
		public string userKey { get; set; }

		public UserData(string dataID, string dataValue, string userKey)
		{
			//grabbing data
			this.dataID = dataID;
			this.dataValue = dataValue;
			this.userKey = userKey;
		}
	}
	
}

