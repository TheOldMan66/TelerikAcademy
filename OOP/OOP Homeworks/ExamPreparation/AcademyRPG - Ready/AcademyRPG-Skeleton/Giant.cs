using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Giant : Character, IFighter, IGatherer
    {
        private bool boosted = false;
        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;

        }
        public int AttackPoints
        {
            get { if (!boosted) return 150; else return 250; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.boosted = true;
                return true;
            }

            return false;
        }
    }
}
