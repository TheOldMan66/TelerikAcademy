using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Gma.DataStructures.StringSearch;

namespace Trie
{

    class Trie
    {
        public static Random rnd = new Random();
        public static List<string> words;

        private static Trie<int> ReadFile(string fileName)
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
            Trie<int> result = new Trie<int>();
            Console.WriteLine(" Done. {0} words extracted", words.Count());
            for (int i = 0; i < words.Count; i++)
            {
                if (i % (words.Count / 100) == 0)
                {
                    Console.Write("\rBuilding trie {0} percent complete", (i * 100) / words.Count);
                }
                result.Add(words[i], i);
            }

            Console.WriteLine();
            return result;
        }

        static void Main(string[] args)
        {
            Trie<int> trie = ReadFile("../../../sample.txt");
            Console.WriteLine("Finding number of occurences for 1000 random words in text:");
            for (int i = 0; i < 1000; i++)
            {
                string wordToFind = words[rnd.Next(words.Count)];
                Console.WriteLine("Word {0} is found {1} times",
                    wordToFind, trie.Retrieve(wordToFind).Count());
            }
        }
    }
}

// This trie implement searchig as ".StartsWith(string s)", so it work slowly and give more results.
//for example for "ho" it will return "honey", "hour", "how" e.t.c.