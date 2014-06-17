using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine,IComparable<Machine>
    {
        private string name;
        internal string type;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defencePoints;
        private IList<string> targets = new List<string>();

        public Machine(string name, double attack, double defence)
        {
            this.name = name;
            this.attackPoints = attack;
            this.defencePoints = defence;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Machine name cannot be null or empty");
                else
                    this.name = value;
            }
        }
        public string Type
        {
            get { return this.type; }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Pilot cannot be null");
                else
                    this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            internal set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defencePoints;
            }
            internal set
            {
                this.defencePoints = value;
            }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
//            throw new NotImplementedException();
        }

        public virtual string GetMachineInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" *Health: " + this.HealthPoints);
            sb.AppendLine(" *Attack: " + this.AttackPoints);
            sb.AppendLine(" *Defense: " + this.DefensePoints);
            sb.Append(" *Targets: ");
            if (this.targets.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                foreach (string item in this.targets)
                    sb.Append(item + ", ");
                sb.Remove(sb.Length - 2, 2);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public int CompareTo(Machine other)
        {
            int result = this.healthPoints.CompareTo(other.healthPoints);
            if (result == 0)
            {
                result = this.name.CompareTo(other.name);
            }
            return result;
        }
    }
}
