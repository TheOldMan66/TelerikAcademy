using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Zombie: Animal
    {
        public Zombie(string name, Point location)
            :base(name,location,int.MaxValue)
        {
            this.Size = 1;
        }

        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
