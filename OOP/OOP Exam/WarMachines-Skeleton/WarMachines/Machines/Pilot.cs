using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> engagedMachines = new List<IMachine>();

        public Pilot(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return this.name; }
        }

        public void AddMachine(IMachine machine)
        {
            engagedMachines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            string numMachines = "no";
            if (this.engagedMachines.Count != 0)
            {
                numMachines = this.engagedMachines.Count.ToString();
            }
            if (this.engagedMachines.Count == 1)
            {
                sb.AppendLine(string.Format("{0} - {1} machine", this.Name, numMachines));                
            }
            else
            {
                sb.AppendLine(string.Format("{0} - {1} machines", this.Name, numMachines));
            }

            List<Machine> tempMachines = new List<Machine>();
            foreach (Machine item in this.engagedMachines)
            {
                tempMachines.Add(item);
            }
            tempMachines.Sort();

            foreach (Machine item in tempMachines)
            {
                if (item.type == "Tank")
                {
                    sb.AppendLine((item as Tank).GetMachineInfo());                    
                }
                else
                {
                    sb.AppendLine((item as Fighter).GetMachineInfo());                    
                }
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString().Trim();
        }
    }
}
