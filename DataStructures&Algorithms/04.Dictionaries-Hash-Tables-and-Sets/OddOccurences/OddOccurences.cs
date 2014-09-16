using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurences
{
    class OddOccurences
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>(new string[] { "JS", "C#", "SQL", "JS", "PHP", "JS", "PHP", "SQL", "SQL", "JS" });
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            foreach (string item in input)
            {
                if (result.ContainsKey(item))
                {
                    result[item] = !result[item];
                }
                else
                {
                    result[item] = true;
                }
            }
            Console.WriteLine("Input:");
            Console.WriteLine(string.Join(", ", input));
            Console.WriteLine("String that was found odd number of times:");
            foreach (var item in result)
            {
                if (item.Value)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
