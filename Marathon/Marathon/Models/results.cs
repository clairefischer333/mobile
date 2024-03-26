using System;
namespace Marathon.Models
{

    public class ResultsCollection
    {
        public result[] results { get; set; }
    }
	public class result
	{
		
		
        public string placement { get; set; }
        public string name { get; set; }
        public string time { get; set; }
      
      

        public string detail {
            get
            {
                return placement + " Place         Time: " + time;
            }
        }
    }
}

