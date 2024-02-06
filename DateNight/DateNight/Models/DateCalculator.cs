using System;
namespace DateNight.Models
{
	public class DateCalculator
	{
        //create properties
		public string CoffeeCost { get; set; }
        public string DinnerCost { get; set; }
        public string MovieCost { get; set; }

        //create method to get cost
        public string GetTotalCost()
        {
            //declare variables
            decimal decCoffee, decDinner, decMovie;

            //if coffee entry fails throw exception 
            if (!Decimal.TryParse(CoffeeCost, out decCoffee))
            {
                //if they typed something that is not null nor empty
                if (!string.IsNullOrEmpty(CoffeeCost))
                {
                    throw new Exception("Invalid Coffee Cost");
                }
            }

            if (!Decimal.TryParse(DinnerCost, out decDinner))
            {
                if (!string.IsNullOrEmpty(DinnerCost))
                {
                    throw new Exception("Invalid Dinner Cost");
                }
            }

            if (!Decimal.TryParse(MovieCost, out decMovie))
            {
                if (!string.IsNullOrEmpty(MovieCost))
                {
                    throw new Exception("Invalid Movie Cost");
                }
            }

            //return total cost
            return (decCoffee + decDinner + decMovie).ToString("c");
        }
    }
}

