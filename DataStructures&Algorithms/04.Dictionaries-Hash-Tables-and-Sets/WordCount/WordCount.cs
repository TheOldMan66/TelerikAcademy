using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordCount
{
    class WordCount
    {
        private static List<string> ReadFile(string fileName)
        {
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            List<string> result = new List<string>(text.ToLower().Split(new char[] { '"', '\'', '\r', '\n', '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries));
            return result;
        }

        static Dictionary<string, int> CountWords(List<string> input)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (string word in input)
            {
                if (words.ContainsKey(word))
                {
                    words[word]++;
                }
                else
                {
                    words[word] = 1;
                }
            }
            return words;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Reading file (Please be patient-there is more than half million words in file)");
            List<string> input = ReadFile("../../dickens.txt");
            Console.WriteLine("{0} words readed", input.Count);
            Console.WriteLine("Countiung words");
            Dictionary<string, int> words = CountWords(input);
            Console.WriteLine("{0} distinct words found", words.Count);
            Console.WriteLine("Sorting");
            int count = 0;
            foreach (KeyValuePair<string, int> item in words.OrderByDescending(key => key.Value))
            {
                Console.WriteLine("Word {0} is found {1} times", item.Key, item.Value);
                count++;
                if (count % 20 == 0)
                {
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
}
