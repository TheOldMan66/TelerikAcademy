using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public enum Genders { male, female };
    class Animal : ISound
    {
        private string name;
        private int age;
        private Genders gender;


        public string Name
        {
            get { return name; }
            private set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Animal must have name");
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0 || value > 300)
                    throw new ArgumentOutOfRangeException("Age of animal must be in range [0-300]");
                age = value;
            }
        }

        public Genders Gender
        {
            get { return this.gender; }
            private set { gender = value; }
        }

        public Animal(string name, int age, Genders gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public virtual string MakeSound()
        {
            throw new NotImplementedException("MakeSound is not implemented for this animal.");
            //return string.Format("{0} have undefined sound", this.Name);
        }
    }
}
