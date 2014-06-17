using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    class Person
    {
        private string name;
        private int? age;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentException("Person must have a name.");
            }
        }
        public int? Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentOutOfRangeException("Age must be in range 0..120");
                else
                    this.age = value;
            }
        }
        public override string ToString()
        {
            string s = "Name: " + this.Name + " Age: ";
            if (age == null)
                s = s + "unspecified";
            else
                s = s + age.ToString();
            return s;
        }
        public Person(string name)
        {
            this.name = name;
            this.age = null;
        }
        public Person(string name, int? age)
        {
            this.name = name;
            this.age = age;
        }
    }
    class PersonTest
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Pesho");
            Person person2 = new Person("Gosho", 22);
            Person person3 = new Person("Stefko", null);
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
        }
    }
}
