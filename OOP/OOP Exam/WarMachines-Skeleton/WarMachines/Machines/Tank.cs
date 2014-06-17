using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        private bool defenceMode;


        public Tank(string name, double attack, double defence)
            : base(name, attack, defence)
        {
            this.HealthPoints = 100;
            this.ToggleDefenseMode();
//            this.defenceMode = true;
            this.type = "Tank";

        }

        public bool DefenseMode
        {
            get { return this.defenceMode; }
        }

        public void ToggleDefenseMode()
        {
            if (!defenceMode)
            {
                this.AttackPoints = this.AttackPoints - 40;
                this.DefensePoints = this.DefensePoints + 30;
            }
            else
            {
                this.AttackPoints = this.AttackPoints + 40;
                this.DefensePoints = this.DefensePoints - 30;

            }
            defenceMode = !defenceMode;
        }

        public override string GetMachineInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("- " + this.Name);
            sb.AppendLine(" *Type: Tank");
            sb.Append(base.GetMachineInfo());
            sb.Append(" *Defense: " + (this.defenceMode ? "ON" : "OFF"));
            return sb.ToString();
        }
    }
}
