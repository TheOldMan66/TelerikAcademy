using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "ExplodingBlock";
        public const char Symbol = '@';

        public ExplodingBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> particles = new List<GameObject>();
            if (this.IsDestroyed)
            {
                particles.Add(new ExplodingParticle(new MatrixCoords(topLeft.Row - 1, topLeft.Col - 1)));
                particles.Add(new ExplodingParticle(new MatrixCoords(topLeft.Row - 1, topLeft.Col)));
                particles.Add(new ExplodingParticle(new MatrixCoords(topLeft.Row - 1, topLeft.Col + 1)));
                particles.Add(new ExplodingParticle(new MatrixCoords(topLeft.Row, topLeft.Col - 1)));
                particles.Add(new ExplodingParticle(new MatrixCoords(topLeft.Row, topLeft.Col + 1)));
                particles.Add(new ExplodingParticle(new MatrixCoords(topLeft.Row + 1, topLeft.Col - 1)));
                particles.Add(new ExplodingParticle(new MatrixCoords(topLeft.Row + 1, topLeft.Col)));
                particles.Add(new ExplodingParticle(new MatrixCoords(topLeft.Row + 1, topLeft.Col + 1)));
            }
            return particles;
        }

        public override string GetCollisionGroupString()
        {
            return ExplodingBlock.CollisionGroupString;
        }
    }
}
