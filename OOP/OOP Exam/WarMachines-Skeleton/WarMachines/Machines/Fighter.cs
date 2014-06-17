using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        private bool stealth;

        public Fighter(string name, double attack, double defence, bool stealth)
            : base(name, attack, defence)
        {
            this.HealthPoints = 200;
            this.stealth = stealth;
            this.type = "Fighter";
        }
        public bool StealthMode
        {
            get { return this.stealth; }
        }

        public void ToggleStealthMode()
        {
            this.stealth = !this.stealth;
        }

        public override string GetMachineInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("- " + this.Name);
            sb.AppendLine(" *Type: Fighter");
            sb.Append(base.GetMachineInfo());
            sb.Append(" *Stealth: " + (this.stealth ? "ON" : "OFF"));
            return sb.ToString();
        }
    }
}
