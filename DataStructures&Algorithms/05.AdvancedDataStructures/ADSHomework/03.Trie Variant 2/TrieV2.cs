using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrieV2
{

    class TrieV2
    {
        public static Random rnd = new Random();
        public static List<string> words;

        private static Dictionary<string, int> ReadFile(string fileName)
        {
            string text = "";
            try
            {
                Console.Write("Reading file");
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
            Console.WriteLine(" Done");
            Console.Write("Extracting words");
            words = new List<string>(text.ToLower().Split(new char[] { '"', '\'', '\r', '\n', '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine(" Done. {0} words extracted", words.Count());

            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
                if (i % (words.Count / 100) == 0)
                {
                    Console.Write("\rBuilding dictionary. {0} percent complete", (i * 100) / words.Count);
                }

                if (!result.ContainsKey(words[i]))
                {
                    result.Add(words[i], 1);
                }
                else
                {
                    result[words[i]]++;
                }
            }

            Console.WriteLine();
            return result;
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = ReadFile("../../../sample.txt");
            Console.WriteLine("Finding number of occurences for 1000 random words in text:");
            for (int i = 0; i < 1000; i++)
            {
                string wordToFind = words[rnd.Next(words.Count)];
                Console.WriteLine("Word {0} is found {1} times",
                    wordToFind, dictionary[wordToFind]);
            }
        }
    }
}

// This is more efficient way from previous, or I use bad trie in previous example    ... :)