using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.OrderedBag
{
    public class Product : IComparable<Product>
    {
        public string name;
        public decimal price;
        public Product(string name, decimal price)
        {
            this.name = name;
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
            OrderedBag<Product> store = new OrderedBag<Product>();
            for (int i = 0; i < 500000; i++)
            {
                store.Add(new Product("SKU " + i, rnd.Next(100000000) / 100.0M));
                if (i % 1000 == 0)
                {
                    Console.Write("\rGenerating store. {0} percent done", i / 5000);
                }
            }
            Console.WriteLine();
            Product lowerRange = new Product("", 400.0M);
            Product upperRange = new Product("", 500.0M);
            var view = store.Range(lowerRange, true, upperRange, true).Take(20);
            foreach (var item in view)
            {
                Console.WriteLine("Item # {0,-12} Price: {1,8:F2}", item.name,item.price);
            } 
        }
    }
}
