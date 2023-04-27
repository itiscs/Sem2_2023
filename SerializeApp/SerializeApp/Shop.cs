using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace SerializeApp
{
    public class MyShop
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void Init()
        {
            Products.Add(new Product()
            {
                ProductId = 1,
                Name = "Яблоки",
                Price = 80m,
                Count = 1000
            });
            Products.Add(new Product()
            {
                ProductId = 2,
                Name = "Мандарины",
                Price = 120m,
                Count = 1000
            });
            Products.Add(new Product()
            {
                ProductId = 3,
                Name = "Груши",
                Price = 180m,
                Count = 900
            });
            Products.Add(new Product()
            {
                ProductId = 4,
                Name = "Бананы",
                Price = 70m,
                Count = 800
            });
            Products.Add(new Product()
            {
                ProductId = 5,
                Name = "Виноград",
                Price = 150m,
                Count = 1200
            });
        }


        public void PrintProducts()
        {
            Console.WriteLine("Список товаров;");
            //Products.Sort();
            foreach (var prod in Products)
            {
                Console.WriteLine(prod);
            }
        }

        public bool ProductsToJson(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                JsonSerializer.Serialize(fs, Products, options);
              
                return true;
            }
            //return false;
        }

        public List<Product> ProductsFromJson(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var prods = JsonSerializer.Deserialize<List<Product>>(fs);
                return prods;
            }

        }


    }

}