namespace ComputerParts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaidHardDrive : IHardDrive
    {
        private int capacity;
        private int numOfDisks;
        private List<IHardDrive> hds;

        public RaidHardDrive(int capacity, int numOfDisksInRaid)
        {
            this.numOfDisks = numOfDisksInRaid;
            this.capacity = capacity;
            this.hds = new List<IHardDrive>();
            for (int i = 0; i < this.numOfDisks; i++)
            {
                IHardDrive drive = new SingleHardDrive(capacity);
                this.hds.Add(drive);
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public void SaveData(int addr, string newData)
        {
            foreach (IHardDrive drive in this.hds)
            {
                drive.SaveData(addr, newData);
            }
        }

        public string LoadData(int address)
        {
            if (!this.hds.Any())
            {
                throw new InvalidOperationException("No hard drive in the RAID array!");
            }

            return this.hds.First().LoadData(address);
        }
    }
}