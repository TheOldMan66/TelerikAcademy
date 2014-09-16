using System;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.OrderedBag
{
    public class Product : IComparable<Product>
    {
        public string barcode;
        public string vendor;
        public string title;
        public decimal price;

        public Product(string barcode, string vendor, string title, decimal price)
        {
            this.barcode = barcode;
            this.vendor = vendor;
            this.title = title;
            this.price = price;
        }


        public int CompareTo(Product other)
        {
            if (this.price > other.price)
            {
                return 1;
            }
            else if (this.price < other.price)
            {
                return -1;
            }
            return 0;
        }
    }

    class StorePriceRange
    {

        static Random rnd = new Random();
        static void Main(string[] args)
        {
            OrderedMultiDictionary<decimal, Product> store = new OrderedMultiDictionary<decimal, Product>(true);
            for (int i = 0; i < 1000000; i++)
            {
                decimal price = rnd.Next(10000000) / 100.0M;
                store.Add(price, new Product(
                    (rnd.Next(100000000) + 100000000).ToString(), // barcode
                    "V" + (rnd.Next(100000000) + 100000000),
                    "SKU" + (i + 10000000),
                    price));
                if (i % 1000 == 0)
                {
                    Console.Write("\rGenerating store. {0} percent done", i / 10000);
                }
            }
            Console.WriteLine();
            decimal lowerRange = 400.0M;
            decimal upperRange = 500.0M;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var view = store.Range(lowerRange, true, upperRange, true);
            int numOfFoundProducts = view.Count;
            sw.Stop();
            Console.WriteLine("Time to generate report: {0} milliseconds", sw.ElapsedMilliseconds);
            Console.WriteLine("Number of products in range {0} - {1}: {2}", lowerRange, upperRange, numOfFoundProducts);
            Console.WriteLine("Press a key to view products");
            Console.ReadLine();
            Console.WriteLine("Products in range {0} - {1}:", lowerRange, upperRange);
            foreach (var item in view)
            {
                foreach (var product in item.Value)
                {

                    Console.WriteLine("Barcode:{0,-10}, Vendor: {1,-10}, Title: {2,-12} Price: {3,8:F2}",
                    product.barcode, product.vendor, product.title, product.price);
                }
            }
        }
    }
}