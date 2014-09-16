using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTable;

namespace HashSet
{
    class HashedSet<K> where K : IComparable<K>, IEquatable<K>
    {
        private HashTable<K, bool> container;

        public HashedSet()
        {
            this.container = new HashTable<K, bool>();
        }

        public int Count
        {
            get
            {
                return this.container.Count;
            }
        }

        public void Add(K element)
        {
            this.container.Add(element, true);
        }

        public bool Contains(K element)
        {
            return this.container.Find(element);
        }

        public bool Remove(K element)
        {
            try
            {
                this.container.Remove(element);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void Clear()
        {
            this.container.Clear();
        }

        public K[] ToArray()
        {
            return container.Keys();
        }

        public HashedSet<K> Union(HashedSet<K> otherSet)
        {
            HashedSet<K> union = new HashedSet<K>();
            K[] keys = container.Keys();
            foreach (K item in keys)
            {
                union.Add(item);
            }

            keys = otherSet.ToArray();
            foreach (K item in keys)
            {
                if (!union.Contains(item))
                {
                    union.Add(item);
                }
            }

            return union;
        }

        public HashedSet<K> Intersect(HashedSet<K> otherSet)
        {
            HashedSet<K> intersect = new HashedSet<K>();
            K[] keys = container.Keys();
            foreach (K item in keys)
            {
                if (otherSet.Contains(item))
                {
                    intersect.Add(item);
                }
            }
            return intersect;
        }
    }

    class HashedSetTest
    {
        static void Main(string[] args)
        {
            HashedSet<string> testSet = new HashedSet<string>();
            Console.WriteLine(testSet.Contains("Test1"));
            testSet.Add("Test1");
            testSet.Add("Test2");
            testSet.Add("Test3");
            Console.WriteLine(testSet.Contains("Test1"));
            Console.WriteLine(testSet.Count);
            testSet.Remove("Test1");
            Console.WriteLine(testSet.Count);

            HashedSet<string> namesSet = new HashedSet<string>();
            namesSet.Add("Pesho");
            namesSet.Add("Gosho");
            namesSet.Add("Stamat");

            testSet.Add("Common element");
            namesSet.Add("Common element");
            HashedSet<string> union = namesSet.Union(testSet);
            Console.WriteLine("Union:");
            Console.WriteLine(string.Join(", ", union.ToArray()));

            HashedSet<string> intersect = namesSet.Intersect(testSet);
            Console.WriteLine("Intersection:");
            Console.WriteLine(string.Join(", ", intersect.ToArray()));
        }
    }
}


