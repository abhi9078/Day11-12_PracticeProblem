
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;



namespace InventoryProblem1
{
    public class InventoryImp
    {
        private static string filepath = @"D:\.Net\Assignment\Day11&12\InventoryProblem1\InventoryProblem1\Items.json";

        public void Add()
        {
            string jfile = File.ReadAllText(filepath);
            Inventory iv;
            iv = (Inventory)JsonConvert.DeserializeObject<Inventory>(jfile);
            if (iv == null)
            {
                iv = new Inventory();
            }
            int sum = 0;
            if (iv != null)
            {
                sum = iv.Sum;
            }
            Items item = new Items();
            Console.WriteLine("Enter what item you want to add ");
            Console.WriteLine("1. Rice");
            Console.WriteLine("2. Pulses");
            Console.WriteLine("3. Wheats");

            int read = int.Parse(Console.ReadLine());

            Console.Write("Enter the Brand of the Product: ");
            item.brand = Console.ReadLine();
            Console.Write("Enter the Price per Kg: ");
            item.PricePerKg = int.Parse(Console.ReadLine());
            Console.Write("Enter the Weight: ");
            item.Weight = int.Parse(Console.ReadLine());
            item.TotalPrice = item.PricePerKg * item.Weight;
            if (iv != null)
            {
                sum += item.TotalPrice;
            }
            else
            {
                sum = item.TotalPrice;
            }

            switch (read)
            {
                case 1:
                    if (iv.Rice == null)
                    {
                        iv.Rice = new List<Items>();
                    }

                    iv.Rice.Add(item);
                    break;
                case 2:
                    if (iv.Pulses == null)
                    {
                        iv.Pulses = new List<Items>();
                    }

                    iv.Pulses.Add(item);
                    break;
                case 3:
                    if (iv.Wheats == null)
                    {
                        iv.Wheats = new List<Items>();
                    }

                    iv.Wheats.Add(item);
                    break;
                default:
                    Console.WriteLine("Invalid Entry try Again...");
                    break;
            }

            iv.Sum = sum;

            using (StreamWriter writer = File.CreateText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, iv);
                Console.WriteLine("new Product Added to the Inventory");
            }
        }


        public void Display()
        {
            string jfile = File.ReadAllText(filepath);

            if (jfile.Length < 1)
            {
                Console.WriteLine("Inventory is Empty ");
                return;
            }

            Inventory iv = JsonConvert.DeserializeObject<Inventory>(jfile);
            Console.WriteLine("\nPlease Select anyone operation");
            Console.WriteLine("1. show the total Inventory Cost");
            Console.WriteLine("2. Display json string");
            int read = int.Parse(Console.ReadLine());

            switch (read)
            {
                case 1:
                    Console.WriteLine("the total inventory cost is : " + iv.Sum);
                    break;
                case 2:
                    Console.WriteLine(jfile);
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }

        }
    }
}