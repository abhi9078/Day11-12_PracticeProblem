using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagementProblem
{
    public class Stock
    {
        public String name { get; set; }
        public int NumberOfShares { get; set; }
        public int SharePrice { get; set; }
        public int StockPrice { get; set; }

        public override string ToString()
        {
            return String.Format("Name: {0}\nPrice: {1}\nNumber of Shares: {2}", name, SharePrice, NumberOfShares);
        }
    }

    public class StockPortfolio
    {
        public int grandTotal { get; set; }
        public List<Stock> StockList;

        public static void Main()
        {
            while (true)
            {

                Console.WriteLine("\nWelcome to Stock Management Program \n" +
                    "Enter 1 to Add new Stock\n" +
                    "Enter 2 for the Total Value of Stock\n");
                int entered = int.Parse(Console.ReadLine());
                StockManager sm = new StockManager();

                switch (entered)
                {
                    case 1:
                        sm.AddStock();
                        break;
                    case 2:
                        sm.ValueOfStacks();
                        break;
            
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
            }
        }
    }

}
