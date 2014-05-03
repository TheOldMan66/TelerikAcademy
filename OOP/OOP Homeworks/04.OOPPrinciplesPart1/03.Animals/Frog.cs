using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Frog : Animal
    {
        public Frog(string name, int age, Genders gender)
            : base(name, age, gender)
        {

        }
        public override string MakeSound()
        {
            return this.Name + " is frog and say 'croak-croak'";
        }

    }
}
