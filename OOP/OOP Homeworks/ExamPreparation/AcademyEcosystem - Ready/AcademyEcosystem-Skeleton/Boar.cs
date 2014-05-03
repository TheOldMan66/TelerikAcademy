using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Boar : Animal, ICarnivore, IHerbivore
    {
        public Boar(string name, Point location)
            : base(name, location, 4)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.Size <= 4 )
            {
                return animal.GetMeatFromKillQuantity();
            }
            return 0;
        }

        public int EatPlant(Plant p)
        {
            if (p != null)
            {
                this.Size++;
                return p.GetEatenQuantity(2);
            }

            return 0;
        }
    }
}
