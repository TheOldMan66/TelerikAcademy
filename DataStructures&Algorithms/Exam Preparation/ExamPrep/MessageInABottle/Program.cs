using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageInABottle
{
    class Program
    {
        static Dictionary<string, string> grammar;
        static SortedSet<string> results = new SortedSet<string>();

        static void Recursion(string message, LinkedList<string> currentResult)
        {
            if (message.Length == 0)
            {
                results.Add(string.Join("",currentResult));
            }
            foreach (string code in grammar.Keys)
            {
                if (message.StartsWith(code))
                {
                    currentResult.AddLast(grammar[code]);
                    Recursion(message.Substring(code.Length), currentResult);
                    currentResult.RemoveLast();
                }
            }
        }

        static void Main(string[] args)
        {
            string originalMessage = Console.ReadLine();
            string cypher = Console.ReadLine();
            string[] cypehrNumbers = cypher.Split("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] cypehrLetters = cypher.Split("0123456789".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            grammar = new Dictionary<string, string>();
            for (int i = 0; i < cypehrNumbers.Length; i++)
            {
                grammar.Add(cypehrNumbers[i],cypehrLetters[i]);
            }
            Recursion(originalMessage, new LinkedList<string>());
            Console.WriteLine(results.Count);
            Console.WriteLine(string.Join("\n",results));
        }
    }
}
