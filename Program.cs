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
            InventoryImp imp = new InventoryImp();
            while (true)
            {
                Console.WriteLine("1. Add Items");
                Console.WriteLine("2. Display Inventory");
                int read = int.Parse(Console.ReadLine());
                switch (read)
                {
                    case 1:
                        imp.Add();
                        break;
                    case 2:
                        imp.Display();
                        break;
                    default:
                        Console.WriteLine("Enter a valid character");
                        break;
                }
                Console.WriteLine("enter yes to continue \nno to exit");
                string inp=Console.ReadLine();
                if (inp != "yes")
                {
                    break;
                }
            }
        }
    }

}
