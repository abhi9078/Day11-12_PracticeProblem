using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryProblem1
{
    public class Inventory
    {
        public int Sum { get; set; }
        public List<Items> Rice;
        public List<Items> Pulses;
        public List<Items> Wheats;
    }
    public class Items
    {
        public string brand;
        public int PricePerKg;
        public int Weight;
        public int TotalPrice;

    }

    public class InventoryManagement
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Inventory Program");
            Inventory_Management_Problem2 imp = new Inventory_Management_Problem2();
            while (true)
            {
                Console.WriteLine("1. Add Items");
                Console.WriteLine("2. Display Inventory");
                Console.WriteLine("3. Delete Item");
                int read = int.Parse(Console.ReadLine());
                switch (read)
                {
                    case 1:
                        imp.Add();
                        break;
                    case 2:
                        imp.Display();
                        break;
                    case 3:
                        imp.Delete();
                        break;
                    default:
                        Console.WriteLine("Enter a valid character");
                        break;
                }
                Console.WriteLine("enter yes to continue \nno to exit");
                string inp = Console.ReadLine();
                //to continue the loop
                if (inp != "yes")
                {
                    break;
                }
            }
        }
    }

}