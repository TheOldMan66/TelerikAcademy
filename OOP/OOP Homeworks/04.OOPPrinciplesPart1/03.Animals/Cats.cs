using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Cat : Animal
    {
        public Cat(string name, int age, Genders gender)
            : base(name, age, gender)
        {
        }

    }

    class Kitten : Cat
    {
        public Kitten(string name, int age, Genders gender)
            : base(name, age, gender)
        {
            if (gender == Genders.male)
                throw new ArgumentException("Kittens can be only female");
        }
        public override string MakeSound()
        {
            return this.Name+" is kitten and say 'miau-miau'";
        }
    }
    class Tomcat: Cat
    {
        public Tomcat(string name, int age, Genders gender)
            : base(name, age, gender)
        {
            if (gender == Genders.female)
                throw new ArgumentException("Tomcats can be only male");
        }
        public override string MakeSound()
        {
            return this.Name + " is tomcat and say 'miaauuuu'";
        }
    }
}
