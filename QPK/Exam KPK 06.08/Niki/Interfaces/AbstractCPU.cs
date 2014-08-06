namespace ComputerParts
{
    using System;

    internal abstract class AbstractCPU : ICPU
    {
        private static Random rnd = new Random();

        public AbstractCPU(Ram ram, byte numberOfCores)
        {
            this.Ram = ram;
            this.NumberOfCores = numberOfCores;
        }

        internal Ram Ram { get; set; }

        private byte NumberOfCores { get; set; }

        public void GenerateRandomNumber(int min, int max)
        {
            int randomNumber;
            randomNumber = rnd.Next(max - min) + min;
            this.Ram.SaveValue(randomNumber);
        }

        public abstract void SquareNumber();
    }
}
