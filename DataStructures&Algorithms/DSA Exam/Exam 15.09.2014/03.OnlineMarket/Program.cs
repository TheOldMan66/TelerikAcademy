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
        public string type;
        public decimal price;

        public Product(string product)
        {
            string[] result = product.Split(new char[] { ' ' }).ToArray();
            this.name = result[0];
            this.type = result[2];
            price = decimal.Parse(result[1]);
        }

        public int CompareTo(Product other)
        {
            int resultOfCompare = price.CompareTo(other.price);
            if (resultOfCompare == 0)
            {
                resultOfCompare = name.CompareTo(other.name);
            }
            if (resultOfCompare == 0)
            {
                resultOfCompare = type.CompareTo(other.type);
            }
            return resultOfCompare;
        }
        public override string ToString()
        {
            return string.Format("{0}({1:0.####################})", this.name, this.price); //{1:0.00}
        }
    }

    public static class ShoppingCenter
    {
        // name as hashset?
        static MultiDictionary<string, Product> byName = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> byType = new MultiDictionary<string, Product>(true);
        static OrderedMultiDictionary<decimal, Product> byPrice = new OrderedMultiDictionary<decimal, Product>(true);

        public static string AddProduct(string product)
        {
            Product productToAdd = new Product(product);
            if (byName.ContainsKey(productToAdd.name))
            {
                return string.Format("Error: Product {0} already exists", productToAdd.name);
            }
            byName.Add(productToAdd.name, productToAdd);
            byType.Add(productToAdd.type, productToAdd);
            byPrice.Add(productToAdd.price, productToAdd);
            return string.Format("Ok: Product {0} added successfully", productToAdd.name);
        }

        //public static string FindProductsByName(string name)
        //{
        //    OrderedBag<string> result = new OrderedBag<string>();
        //    var items = byName[name];
        //    int count = 0;
        //    foreach (var item in items)
        //    {
        //        result.Add(item.ToString());
        //        count++;
        //    }

        //    if (count == 0)
        //    {
        //        return "No products found";
        //    }
        //    return string.Join("\n", result);
        //}

        public static string FindProductsByType(string name)
        {
            OrderedBag<Product> result = new OrderedBag<Product>();
            var items = byType[name];
            int count = 0;
            foreach (var item in items)
            {
                result.Add(item);
                count++;
            }

            if (count == 0)
            {
                return string.Format("Error: Type {0} does not exists",name);
            }
            var result1 = result.Take(10);
            return "Ok: " + string.Join(", ", result1);
        }

        public static string FindProductsByPriceRange(string name)
        {
            OrderedBag<Product> result = new OrderedBag<Product>();

            string[] priceRange = name.Split(' ');
            decimal lowerRange = decimal.Parse(priceRange[0]);
            decimal upperRange = decimal.Parse(priceRange[2]);

            var items = byPrice.Range(lowerRange, true, upperRange, true);
            int count = 0;
            foreach (var item in items.Values)
            {
                result.Add(item);
                count++;
            }

            //if (count == 0)
            //{
            //    return "No products found";
            //}
            var result1 = result.Take(10);
            return "Ok: " + string.Join(", ", result1);
        }

        public static string FindProductsByPriceRangeFrom(string name)
        {
            OrderedBag<Product> result = new OrderedBag<Product>();
            decimal lowerRange = decimal.Parse(name);

            var items = byPrice.RangeFrom(lowerRange, true);
            int count = 0;
            foreach (var item in items.Values)
            {
                result.Add(item);
                count++;
            }

            //if (count == 0)
            //{
            //    return "No products found";
            //}
            var result1 = result.Take(10);
            return "Ok: " + string.Join(", ", result1);
        }

        public static string FindProductsByPriceRangeTo(string name)
        {
            OrderedBag<Product> result = new OrderedBag<Product>();
            decimal lowerRange = decimal.Parse(name);

            var items = byPrice.RangeTo(lowerRange, true);
            int count = 0;
            foreach (var item in items.Values)
            {
                result.Add(item);
                count++;
            }

            //if (count == 0)
            //{
            //    return "No products found";
            //}
            return "Ok: " + string.Join(", ", result);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            StringBuilder result = new StringBuilder();
            while (true)
            {
                string command = Console.ReadLine();
                if (command.StartsWith("end"))
                {
                    break;
                }
                else if (command.StartsWith("add"))
                {
                    result.AppendLine(ShoppingCenter.AddProduct(command.Substring(4)));
                }
                else if (command.StartsWith("filter by type"))
                {
                    result.AppendLine(ShoppingCenter.FindProductsByType(command.Substring(15)));
                }
                else
                {
                    string[] param = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (param.Length == 7)
                    {
                        result.AppendLine(ShoppingCenter.FindProductsByPriceRange(command.Substring(21)));
                    }
                    else if (param[3] == "from")
                    {
                        result.AppendLine(ShoppingCenter.FindProductsByPriceRangeFrom(command.Substring(21)));
                    }
                    else
                    {
                        result.AppendLine(ShoppingCenter.FindProductsByPriceRangeTo(command.Substring(19)));
                    }
                }

                //    int indexOfFirstSpace = command.IndexOf(' ');
                //    string parameter = command.Substring(indexOfFirstSpace + 1);
                //    command = command.Substring(0, indexOfFirstSpace);

                //    switch (command)
                //    {
                //        case "AddProduct":
                //            result.AppendLine(ShoppingCenter.AddProduct(parameter));
                //            break;
                //        case "DeleteProducts":
                //            result.AppendLine(ShoppingCenter.DeleteProducts(parameter));
                //            break;
                //        case "FindProductsByName":
                //            result.AppendLine(ShoppingCenter.FindProductsByName(parameter));
                //            break;
                //        case "FindProductsByType":
                //            result.AppendLine(ShoppingCenter.FindProductsByType(parameter));
                //            break;
                //        case "FindProductsByPriceRange":
                //            result.AppendLine(ShoppingCenter.FindProductsByPriceRange(parameter));
                //            break;
                //    }
            }
            Console.Write(result.ToString());
        }
    }
}
