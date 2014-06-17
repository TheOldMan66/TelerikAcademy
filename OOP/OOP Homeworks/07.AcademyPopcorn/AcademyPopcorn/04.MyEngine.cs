using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MyEngine : Engine // TASK 4
    {
        ShootingRacket playerRacket;
        public MyEngine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : base(renderer, userInterface, sleepTime)
        {
        }

    }
} 
