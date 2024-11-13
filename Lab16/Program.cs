using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Введите код товара: ");
                    int cod = int.Parse(Console.ReadLine());
                    Console.Write("Введите название товара: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите цену товара: ");
                    double price = double.Parse(Console.ReadLine());
                    products[i] = new Product() { Product_Code = cod, Name_Code = name, Price_Code = price };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products,options);
            string path = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            using (StreamWriter sw = new StreamWriter(path+ @"\Products.json"))
            {
                sw.WriteLine(jsonString);
            };
            
        }
    }
}
