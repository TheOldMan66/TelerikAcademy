using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public new const string CollisionGroupString = "GiftBlock";
        public const char Symbol = 'G';
        public GiftBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> particles = new List<GameObject>();
            if (this.IsDestroyed)
                particles.Add(new Gift(this.GetTopLeft()));
            return particles;
        }
    }
}
