using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingParticle : MovingObject
    {
        int timeToLive = 1;
        public new const string CollisionGroupString = "particle";

        public ExplodingParticle(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '.' } }, new MatrixCoords(0,0))
        {
        }

        public override string GetCollisionGroupString()
        {
            return ExplodingParticle.CollisionGroupString;
        }

        public override void Update()
        {
            if (--timeToLive == 0)
                this.IsDestroyed = true;
        }
    }
}
