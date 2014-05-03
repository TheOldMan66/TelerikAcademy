using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        public new const string CollisionGroupString = "ShootingRacket";
        private int shootEnableTime;
        private bool canShot;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            shootEnableTime = 100;
            canShot = false;
        }

        public override void Update()
        {
            if (canShot)
            {
                shootEnableTime--;
            }
            if (shootEnableTime == 0)
            {
                canShot = false;
            }
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return base.CanCollideWith(otherCollisionGroupString) || otherCollisionGroupString == "Gift";
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains(Gift.CollisionGroupString))
            {
                this.canShot = true;
                this.shootEnableTime = 100;
            }
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (canShot && shootEnableTime % 4 == 0)
            {
                produceObjects.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + Width / 2)));
                this.shootEnableTime--;
            }
            return produceObjects;
        }
    }
}
