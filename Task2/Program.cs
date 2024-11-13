using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = string.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxCost = products[0];
            foreach (Product p in products)
            {
                if (p.Price_Code > maxCost.Price_Code)
                {
                    maxCost = p;
                }
            }
            Console.WriteLine($"Cамый дорогой товар:\n{maxCost.Product_Code} {maxCost.Name_Code} {maxCost.Price_Code}");
            Console.ReadKey();
        }
        
    }
}
