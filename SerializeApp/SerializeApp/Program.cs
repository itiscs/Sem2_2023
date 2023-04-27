using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SerializeApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string fileName = "products.json";
            MyShop shop = new MyShop();

            shop.Init();


            if (shop.ProductsToJson(fileName))
                Console.WriteLine("done");

            //shop.PrintProducts();


            //var prod  = shop.Products.FirstOrDefault();

            //var options = new JsonSerializerOptions
            //{
            //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            //    WriteIndented = true
            //};

            //string json = JsonSerializer.Serialize(shop.Products, options);
            //Console.WriteLine(json);
            //Console.WriteLine("***********************");


            //var newProds = JsonSerializer.Deserialize<List<Product>>(json);
            //foreach (var p in shop.ProductsFromJson("products.json"))
              //  Console.WriteLine(p);




        }
    }
}