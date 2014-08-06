namespace ComputerParts
{
    using System;
    using System.Collections.Generic;

    public class SingleHardDrive : IHardDrive
    {
        private int capacity;
        private Dictionary<int, string> data;

        public SingleHardDrive(int capacity)
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
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
            this.data[addr] = newData;
        }

        public string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
