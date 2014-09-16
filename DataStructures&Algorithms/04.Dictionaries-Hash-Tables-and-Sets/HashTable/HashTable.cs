using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable<K, T> where K : IComparable<K>, IEquatable<K>
    {
        private const int initialCapacity = 16;
        private int numOfElements = 0;
        private const float maxFillRatio = 0.75F;
        private LinkedList<KeyValuePair<K, T>>[] container;

        public HashTable()
            : this(16)
        {
        }

        public HashTable(int capacity)
        {
            Clear();
        }

        private void ExpandContainer()
        {
            LinkedList<KeyValuePair<K, T>>[] newContainer = new LinkedList<KeyValuePair<K, T>>[this.container.Length * 2];
            LinkedListNode<KeyValuePair<K, T>> element;

            numOfElements = 0;
            for (int i = 0; i < container.Length; i++)
            {
                if (container[i] != null)
                {
                    element = this.container[i].First;
                    while (element != null)
                    {
                        AddInternal(element.Value, newContainer);
                        element = element.Next;
                    }
                }
            }

            this.container = newContainer;
        }


        public void Add(K key, T value)
        {
            if (FindInternal(key, false) != null)
            {
                throw new ArgumentException("Duplicate key");
            }
            float fillRatio = numOfElements / (float)this.container.Length;
            if (fillRatio > maxFillRatio)
            {
                ExpandContainer();
            }
            KeyValuePair<K, T> elementToAdd = new KeyValuePair<K, T>(key, value);
            AddInternal(new KeyValuePair<K, T>(key, value), this.container);
        }

        private void AddInternal(KeyValuePair<K, T> elementToAdd, LinkedList<KeyValuePair<K, T>>[] volume)
        {
            int hashCode = (elementToAdd.Key.GetHashCode() & 0x7FFFFFFF) % volume.Length;
            if (volume[hashCode] == null)
            {
                volume[hashCode] = new LinkedList<KeyValuePair<K, T>>();
            }
            volume[hashCode].AddLast(elementToAdd);
            numOfElements++;
        }


        private LinkedListNode<KeyValuePair<K, T>> FindInternal(K key, bool delete)
        {
            int hashCode = (key.GetHashCode() & 0x7FFFFFFF) % this.container.Length;
            if (this.container[hashCode] == null)
            {
                return null;
            }

            LinkedListNode<KeyValuePair<K, T>> element = this.container[hashCode].First;
            while (element != null)
            {
                if (key.CompareTo(element.Value.Key) == 0)
                {
                    if (delete)
                    {
                        LinkedListNode<KeyValuePair<K, T>> copyOfElement = element;
                        container[hashCode].Remove(element);
                        numOfElements--;
                        return copyOfElement;
                    }
                    else
                    {
                        return element;
                    }
                }
                element = element.Next;
            }

            return null;
        }


        public T Find(K key)
        {
            LinkedListNode<KeyValuePair<K, T>> element = FindInternal(key, false);
            if (element == null)
            {
                return default(T);
            }
            else
            {
                return element.Value.Value;
            }
        }

        public T Remove(K key)
        {
            LinkedListNode<KeyValuePair<K, T>> element = FindInternal(key, true);
            if (element == null)
            {
                throw new KeyNotFoundException("Key not found");
            }
            else
            {
                return element.Value.Value;
            }
        }

        public bool Contains(K key)
        {
            LinkedListNode<KeyValuePair<K, T>> element = FindInternal(key, false);
            return element != null;
        }

        public int Count
        {
            get
            {
                return numOfElements;
            }
        }

        public void Clear()
        {
            this.container = new LinkedList<KeyValuePair<K, T>>[initialCapacity];
            numOfElements = 0;

        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                LinkedListNode<KeyValuePair<K, T>> elementToChange = FindInternal(key, false);
                elementToChange.Value = new KeyValuePair<K, T>(elementToChange.Value.Key, value);
            }
        }

        public K[] Keys()
        {
            List<K> keys = new List<K>();
            LinkedListNode<KeyValuePair<K, T>> element;

            for (int i = 0; i < container.Length; i++)
            {
                if (container[i] != null)
                {
                    element = this.container[i].First;
                    while (element != null)
                    {
                        keys.Add(element.Value.Key);
                        element = element.Next;
                    }
                }
            }

            return keys.ToArray();
        }
    }


    public class HashTableTester
    {
        static void Main(string[] args)
        {

            HashTable<string, string> testHash = new HashTable<string, string>();
            for (int i = 0; i < 10; i++)
            {
                testHash.Add("Key" + i, "Value " + i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Key: {0}, Value: {1}", "Key" + i, testHash["Key" + i]);
            }

            Console.WriteLine("List of keys:");
            Console.WriteLine(String.Join(", ", testHash.Keys()));

            Console.WriteLine("Old value of Key4: " + testHash["Key4"]);
            testHash["Key4"] = "New value";
            Console.WriteLine("New value of Key4: " + testHash["Key4"]);

            Console.WriteLine("Removing element Key4");
            testHash.Remove("Key4");

            Console.WriteLine("Is element Key5 exist? " + testHash.Contains("Key5"));
            Console.WriteLine("Is element Key4 exist? " + testHash.Contains("Key4"));

            Console.Write("Finding element Key5: ");
            Console.WriteLine(testHash.Find("Key5"));
            Console.Write("Finding element Key55: ");
            Console.WriteLine(testHash.Find("Key55"));
        }
    }
}