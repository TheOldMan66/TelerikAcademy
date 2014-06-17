using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball // TASK 6
    {
        private int trailLen;
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed, int trailLen)
            : base(topLeft, speed)
        {
            this.trailLen = trailLen;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> trail = new List<GameObject>();
            trail.Add(new TrailObject(this.topLeft,trailLen));
            return trail;
        }
}
}
