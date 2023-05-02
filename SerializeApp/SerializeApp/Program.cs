using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;

namespace SerializeApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string fileName = "products.json";
            MyShop shop = new MyShop();

            shop.Init();

            // ************************ JSON **********************
            //if (shop.ProductsToJson(fileName))
            //    Console.WriteLine("done");

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



            //******************         XML       ***********************************



            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));

            // получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerializer.Serialize(fs, shop.Products);

            //    Console.WriteLine("Object has been serialized");
            //}

            //using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
            //{
            //    var prods = xmlSerializer.Deserialize(fs) as List<Product>;
            //    foreach(var p in prods)
            //        Console.WriteLine(p);
            //}



            //using (BinaryWriter writer = new BinaryWriter(File.Open("products.dat", FileMode.OpenOrCreate)))
            //{
            //    // записываем в файл значение каждого свойства объекта
            //    foreach (var prod in shop.Products)
            //    {
            //        prod.WriteToBinWriter(writer);
            //    }
            //    Console.WriteLine("File has been written");
            //}

            using (BinaryReader reader = new BinaryReader(File.Open("products.dat", FileMode.Open)))
            {
                // считываем из файла строку
                while (reader.PeekChar() > -1)
                {
                    var prod = new Product();
                    prod.ProductId = reader.ReadInt32();
                    prod.Name = reader.ReadString();
                    prod.Price = reader.ReadDecimal();
                    prod.Count = reader.ReadInt32();

                    Console.WriteLine(prod);

                }
            }



        }
    }
}