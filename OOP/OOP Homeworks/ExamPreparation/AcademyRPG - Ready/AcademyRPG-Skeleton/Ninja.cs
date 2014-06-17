using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints = 0;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;

        }
        public int AttackPoints
        {
            get { return attackPoints; }
        }
        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public bool IsDestoyed
        {
            get
            {
                this.HitPoints = 1;
                return false;
            }
        }
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int targetToAttack = -1;
            int maxTargetStrenght = -1;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > maxTargetStrenght)
                    {
                        maxTargetStrenght = availableTargets[i].HitPoints;
                        targetToAttack = i;
                    }
                }
            }
            return targetToAttack;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += resource.Quantity * 2;
                return true;
            }
            else if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }
            else
                return false;
        }
    }
}
