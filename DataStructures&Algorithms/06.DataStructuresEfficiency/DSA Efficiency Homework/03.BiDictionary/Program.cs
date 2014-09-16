using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace BiDictionary
{
    class Student : IComparable<Student>
    {
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Student other)
        {
            return this.age - other.age;
        }
        public override string ToString()
        {
            return "Name: " + this.name + ", age: " + this.age;
        }
    }

    class BiDictionary<K1, K2, V>
        where K1 : IComparable<K1>
        where K2 : IComparable<K2>
        where V : IComparable<V>
    {

        OrderedMultiDictionary<K1, V> key1Dictionary = new OrderedMultiDictionary<K1, V>(true);
        OrderedMultiDictionary<K2, V> key2Dictionary = new OrderedMultiDictionary<K2, V>(true);
        OrderedDictionary<K1, OrderedDictionary<K2, V>> key1And2Dictionary = new OrderedDictionary<K1, OrderedDictionary<K2, V>>();

        public void Add(K1 key1, K2 key2, V value)
        {
            key1Dictionary.Add(key1, value);
            key2Dictionary.Add(key2, value);
            if (!key1And2Dictionary.ContainsKey(key1))
            {
                key1And2Dictionary.Add(key1, new OrderedDictionary<K2,V>());
            }
                key1And2Dictionary[key1].Add(key2, value);
        }

        public ICollection<V> GetByK1(K1 key)
        {
            return key1Dictionary[key];
        }

        public ICollection<V> GetByK2(K2 key)
        {
            return key2Dictionary[key];
        }

        public V GetByK1AndK2(K1 key1, K2 key2)
        {
            if (!key1And2Dictionary.ContainsKey(key1))
            {
                throw new ArgumentException("No such K1 key");
            }
            return key1And2Dictionary[key1][key2];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BiDictionary<string, int, Student> testDictionary = new BiDictionary<string, int, Student>();
            testDictionary.Add("key1", 1, new Student("Student11",11));
            testDictionary.Add("key1", 2, new Student("Student12",12));
            testDictionary.Add("key1", 3, new Student("Student13",13));
            testDictionary.Add("key1", 4, new Student("Student14",14));
            testDictionary.Add("key2", 1, new Student("Student21",21));
            testDictionary.Add("key2", 2, new Student("Student22",22));
            testDictionary.Add("key2", 3, new Student("Student23",23));
            testDictionary.Add("key2", 4, new Student("Student24",24));

            Console.WriteLine("Finding by key1 and key2");
            Console.WriteLine(testDictionary.GetByK1AndK2("key2",3));

            Console.WriteLine("Finding by key1");
            foreach (var item in testDictionary.GetByK1("key1"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Finding by key2");
            foreach (var item in testDictionary.GetByK2(2))
            {
                Console.WriteLine(item);
            }
        }
    }
}

// I must implemet bunch of functionality, but ... it's a piece of cake, and no time for that.
