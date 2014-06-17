using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IEnumerableExtensions
{
    /* Implement a set of extension methods for IEnumerable<T> that implement the following group functions: 
     * sum, product, min, max, average. */

    public static class IenumerableExtensions
    {
        public static decimal Sum<T>(this IEnumerable<T> input)
        {
            decimal sum = 0.0M;
            try
            {
                foreach (var item in input)
                    sum = sum + Convert.ToDecimal(item);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Non-numerical elements found in collection.");
            }
            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> input)
        {
            decimal product = 1.0M;
            try
            {
                foreach (var item in input)
                    product = product * Convert.ToDecimal(item);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Non-numerical elements found in collection.");
            }
            return product;
        }

        public static decimal Min<T>(this IEnumerable<T> input) where T : IComparable
        {
            decimal min = decimal.MaxValue;
            try
            {
                foreach (var item in input)
                    if (min < Convert.ToDecimal(item))
                        min = Convert.ToDecimal(item);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Non-numerical elements found in collection.");
            }
            return min;
        }

        public static decimal Max<T>(this IEnumerable<T> input) where T : IComparable
        {
            decimal max = decimal.MinValue;
            try
            {
                foreach (var item in input)
                    if (max > Convert.ToDecimal(item))
                        max = Convert.ToDecimal(item);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Non-numerical elements found in collection.");
            }
            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> input)
        {
            int count = 0;
            foreach (T item in input)
                count++;
            return input.Sum<T>() / count;
        }
    }
    class IEnumerable
    {
        static void Main(string[] args)
        {
            int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] dblArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] strArray = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Console.WriteLine("Sum of:");
            Console.WriteLine("Int array:" + intArr.Sum<int>());
            Console.WriteLine("Double array:" + dblArr.Sum<double>());
            Console.WriteLine("String array (filled with int's):" + strArray.Sum<string>());
            Console.WriteLine("Product of:");
            Console.WriteLine("Int array:" + intArr.Product<int>());
            Console.WriteLine("Double array:" + dblArr.Product<double>());
            Console.WriteLine("String array (filled with int's):" + strArray.Product<string>());
            Console.WriteLine("Average of:");
            Console.WriteLine("Int array:" + intArr.Average<int>());
            Console.WriteLine("Double array:" + dblArr.Average<double>());
            Console.WriteLine("String array (filled with int's):" + strArray.Average<string>());
        }
    }
}
