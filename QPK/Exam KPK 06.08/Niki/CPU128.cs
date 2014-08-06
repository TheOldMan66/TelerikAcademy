namespace ComputerParts
{
    using System;

    internal class CPU128 : AbstractCPU
    {
        internal CPU128(Ram ram, byte numberOfCores)
            : base(ram, numberOfCores)
        {
        }

        public override void SquareNumber()
        {
            var data = this.Ram.LoadValue();
            if (data < 0)
            {
                throw new ArgumentNullException("Number too low.");
            }
            else if (data > 2000)
            {
                throw new ArgumentOutOfRangeException("Number too high.");
            }
            else
            {
                int value = data * data;
                this.Ram.SaveValue(value);
            }
        }
    }
}
