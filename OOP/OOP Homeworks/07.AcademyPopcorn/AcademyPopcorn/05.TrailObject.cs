using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject // TASK 5
    {
        internal int timeToLive;
        public new const string CollisionGroupString = "block";

        public TrailObject(MatrixCoords topLeft, int time)
            : base(topLeft, new char[,] { { '.' } })
        {
            this.timeToLive = time;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return false;
        }

        public override void Update()
        {
            if (--timeToLive <= 0)
                this.IsDestroyed = true;
        }
    }
}
