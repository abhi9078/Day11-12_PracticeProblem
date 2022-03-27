using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace StockManagementProblem
{
    public class StockManager
    {
        public static string path = @"D:\.Net\Assignment\Day11&12\StockManagementProblem\StockManagementProblem\Stock.json";
        public void AddStock()
        {
            string jfile = File.ReadAllText(path);
            StockPortfolio st;
            if (jfile.Length < 1)
            {
                st = new StockPortfolio();
                st.StockList = new List<Stock>();
                st.grandTotal = 0;
            }
            else
            {
                st = JsonConvert.DeserializeObject<StockPortfolio>(jfile);
            }

            Stock s = new Stock();
            Console.Write("Enter the new Stock Name:");
            s.name = Console.ReadLine();
            Console.Write("Enter the share Price For stock: ");
            s.SharePrice = int.Parse(Console.ReadLine());
            Console.Write("Enter the Number Of Shares: ");
            s.NumberOfShares = int.Parse(Console.ReadLine());
            s.StockPrice = s.SharePrice * s.NumberOfShares;
            st.grandTotal += s.StockPrice;

            st.StockList.Add(s);

            using (StreamWriter stream = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(stream, st);
            }

            Console.WriteLine("Added Successfully");
        }

        public void ValueOfStacks()
        {
            string jfile = File.ReadAllText(path);
            StockPortfolio st;
            if (jfile.Length < 1)
            {
                Console.WriteLine("there are no stocks");
                return;
            }
            else
            {
                st = JsonConvert.DeserializeObject<StockPortfolio>(jfile);
            }

            Console.WriteLine("\nEnter 1 to Display Total Share value ");
            Console.WriteLine("Enter 2 to display total sharePrice of particular stock");
            int entered = int.Parse(Console.ReadLine());

            switch (entered)
            {
                case 1:
                    Console.WriteLine("total price of all stocks are: " + st.grandTotal);
                    break;
                case 2:
                    Console.WriteLine("Name suggestions:");
                    foreach (Stock s in st.StockList)
                    {
                        Console.Write("\"" + s.name + "\" ");
                    }
                    Console.Write("\nEnter the name: ");
                    string name = Console.ReadLine();
                    foreach (Stock s in st.StockList)
                    {
                        if (s.name.Equals(name))
                        {
                            Console.WriteLine("the Total Stock value of " + name + " is : " + s.StockPrice);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }



        }
    }
}
