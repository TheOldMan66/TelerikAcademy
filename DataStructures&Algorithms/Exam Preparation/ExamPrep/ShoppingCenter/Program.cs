using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    class Product : IComparable<Product>
    {
        public string name;
        public string producer;
        public decimal price;

        public Product(string product)
        {
            string[] result = product.Split(new char[] { ';' }).ToArray();
            this.name = result[0];
            this.producer = result[2];
            price = decimal.Parse(result[1]);
        }

        public int CompareTo(Product other)
        {
            int resultOfCompare = name.CompareTo(other.name);
            if (resultOfCompare == 0)
            {
                resultOfCompare = producer.CompareTo(other.producer);
            }
            if (resultOfCompare == 0)
            {
                resultOfCompare = price.CompareTo(other.price);
            }
            return resultOfCompare;
        }
        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.name, this.producer, this.price);
        }
    }

    public static class ShoppingCenter
    {
        static MultiDictionary<string, Product> byName = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> byProducer = new MultiDictionary<string, Product>(true);
        static OrderedMultiDictionary<decimal, Product> byPrice = new OrderedMultiDictionary<decimal, Product>(true);

        public static string AddProduct(string product)
        {
            Product productToAdd = new Product(product);
            byName.Add(productToAdd.name, productToAdd);
            byProducer.Add(productToAdd.producer, productToAdd);
            byPrice.Add(productToAdd.price, productToAdd);
            return "Product added";
        }

        public static string DeleteProducts(string command)
        {
            string[] parameters = command.Split(';');
            Product[] items;
            if (parameters.Length == 1)
            {
                items = byProducer[parameters[0]].ToArray();
            }
            else
            {
                items = byName[parameters[0]].Intersect(byProducer[parameters[1]]).ToArray();
            }

            foreach (var item in items)
            {
                byName.Remove(item.name, item);
                byPrice.Remove(item.price, item);
                byProducer.Remove(item.producer, item);
            }

            if (items.Length == 0)
            {
                return "No products found";
            }
            return items.Length + " products deleted";
        }

        public static string FindProductsByName(string name)
        {
            OrderedBag<string> result = new OrderedBag<string>();
            var items = byName[name];
            int count = 0;
            foreach (var item in items)
            {
                result.Add(item.ToString());
                count++;
            }

            if (count == 0)
            {
                return "No products found";
            }
            return string.Join("\n", result);
        }

        public static string FindProductsByProducer(string name)
        {
            OrderedBag<string> result = new OrderedBag<string>();
            var items = byProducer[name];
            int count = 0;
            foreach (var item in items)
            {
                    result.Add(item.ToString());
                    count++;
            }

            if (count == 0)
            {
                return "No products found";
            }
            return string.Join("\n", result);
        }

        public static string FindProductsByPriceRange(string name)
        {
            OrderedBag<string> result = new OrderedBag<string>();

            string[] priceRange = name.Split(';');
            decimal lowerRange = decimal.Parse(priceRange[0]);
            decimal upperRange = decimal.Parse(priceRange[1]);

            var items = byPrice.Range(lowerRange, true, upperRange, true);
            int count = 0;
            foreach (var item in items.Values)
            {
                    result.Add(item.ToString());
                    count++;
            }

            if (count == 0)
            {
                return "No products found";
            }
            return string.Join("\n", result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            StringBuilder result = new StringBuilder();
            int numOfRows = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfRows; i++)
            {
                string command = Console.ReadLine();
                int indexOfFirstSpace = command.IndexOf(' ');
                string parameter = command.Substring(indexOfFirstSpace + 1);
                command = command.Substring(0, indexOfFirstSpace);

                switch (command)
                {
                    case "AddProduct":
                        result.AppendLine(ShoppingCenter.AddProduct(parameter));
                        break;
                    case "DeleteProducts":
                        result.AppendLine(ShoppingCenter.DeleteProducts(parameter));
                        break;
                    case "FindProductsByName":
                        result.AppendLine(ShoppingCenter.FindProductsByName(parameter));
                        break;
                    case "FindProductsByProducer":
                        result.AppendLine(ShoppingCenter.FindProductsByProducer(parameter));
                        break;
                    case "FindProductsByPriceRange":
                        result.AppendLine(ShoppingCenter.FindProductsByPriceRange(parameter));
                        break;
                }
            }
            Console.Write(result.ToString());
        }
    }
}
