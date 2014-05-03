using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstopableBall : Ball // TASK 8
    {
        public new const string CollisionGroupString = "UnstopableBall";

        public UnstopableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { '0' } };
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return base.CanCollideWith(otherCollisionGroupString) || otherCollisionGroupString == "UnpassableBlock";
        }

        public override string GetCollisionGroupString()
        {
            return UnstopableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (!collisionData.hitObjectsCollisionGroupStrings.Contains(UnpassableBlock.CollisionGroupString) &&
                !collisionData.hitObjectsCollisionGroupStrings.Contains(Racket.CollisionGroupString))
                return;
            if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
            {
                this.Speed.Row *= -1;
            }
            if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
            {
                this.Speed.Col *= -1;
            }
        }
    }
}
