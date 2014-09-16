using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace _03.Trie_V3
{
    class Trie
    {
        public int count;
        private Dictionary<char, Trie> childs;

        public Trie()
        {
            childs = new Dictionary<char, Trie>();
        }

        public void AddWord(string word, int pos = 0)
        {
            if (!this.childs.ContainsKey(word[pos]))
            {
                this.childs.Add(word[pos], new Trie());
            }

            if (pos < word.Length - 1)
            {
                this.childs[word[pos]].AddWord(word, pos + 1);
            }
        }

        public bool CountWord(string word, int pos = 0)
        {
            if (!this.childs.ContainsKey(word[pos]))
            {
                return false;
            }

            if (pos < word.Length - 1)
            {
                this.childs[word[pos]].CountWord(word,pos+1);
            }
            else
            {
                this.childs[word[pos]].count++;
            }

            return true;
        }

        public int GetWordCount(string word, int pos = 0)
        {
            if (!this.childs.ContainsKey(word[pos]))
            {
                return 0;
            }

            if (pos < word.Length - 1)
            {
                return this.childs[word[pos]].GetWordCount(word,pos+1);
            }
            else
            {
                return this.childs[word[pos]].count;
            }
            return 0;
        }
    }

    class Program
    {
        static Random rnd = new Random();
        private static List<string> ReadFile(string fileName)
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
            List<string> words = new List<string>(text.ToLower().Split(new char[] { '"', '\'', '\r', '\n', '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine(" Done. {0} words extracted", words.Count());
            return words;
        }

        static void Main(string[] args)
        {
            List<string> words = ReadFile("../../../sample.txt");
            Trie testTrie = new Trie();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.Write("Building trie for searching");
            List<string> wordsToCount = new List<string>();
            for (int i = 0; i < 20000; i++)
            {
                string word = words[rnd.Next(words.Count)];
                wordsToCount.Add(word);
                testTrie.AddWord(word);
            }
            Console.WriteLine(" Done");

            Console.Write("Counting words");

            Parallel.ForEach(words, (word) => testTrie.CountWord(word));
            // Or if U want to use only one core - comment line above and uncomment foreach below

            //foreach (string word in words)
            //{
            //    testTrie.CountWord(word);
            //}

            Console.WriteLine(" Done");

            Console.WriteLine();
            Console.WriteLine("Result:");
            Console.WriteLine("Total words: {0}", words.Count);
            Console.WriteLine("Words to find: {0} (1000 is not enough :) ", wordsToCount.Count);
            Console.WriteLine("Total time for building tree, adding words and counting: {0}", sw.Elapsed);
            Console.WriteLine();
            sw.Stop();

            Console.WriteLine("Show count of 10 random words: ");
            for (int i = 0; i < 10; i++)
            {
                string word = wordsToCount[rnd.Next(wordsToCount.Count)];
                Console.WriteLine("Word: {0} occured {1} times", word, testTrie.GetWordCount(word));

            }
        }
    }
}
