using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries_Hash_Tables_and_Sets
{
    class CountDoubles
    {
        static void Main(string[] args)
        {
            double[] input = new double[] { 3.14, 2.71, 3.14, 4.5, 4.5, 3.14, 4.5, 0, 4.5 };
            Dictionary<double, int> result = new Dictionary<double, int>();
            foreach (double item in input)
            {
                if (result.ContainsKey(item))
                {
                    result[item]++;
                }
                else
                {
                    result[item] = 1;
                }
            }
            Console.WriteLine("Input:");
            Console.WriteLine(string.Join(", ",input));
            Console.WriteLine("Result:");
            foreach (var item in result)
            {
                Console.WriteLine("{0} is found {1} times",item.Key,item.Value);
            }
        }
    }
}
