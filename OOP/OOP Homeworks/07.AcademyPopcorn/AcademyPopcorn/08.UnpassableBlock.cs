using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlock : IndestructibleBlock // TASK 8
    {
        public new const string CollisionGroupString = "UnpassableBlock";
        public new const char Symbol = '%';

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

    }
}
