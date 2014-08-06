namespace ComputerDefinition
{
    using System;
    using System.Threading.Tasks;
    using ComputerParts;

    public class Computer
    {
        private readonly LaptopBattery battery;

        internal Computer(ComputerTypes.Type type, ICPU cpu, Ram ram, IHardDrive hardDrives, Videocard videoCard, LaptopBattery battery)
        {
            this.CPU = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            if (type == ComputerTypes.Type.SERVER)
            {
                this.VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
        }

        private IHardDrive HardDrives { get; set; }

        private Videocard VideoCard { get; set; }

        private ICPU CPU { get; set; }

        private Ram Ram { get; set; }

        public void Play(int guessNumber)
        {
            this.CPU.GenerateRandomNumber(1, 10);
            var number = this.Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }

        internal void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
        }

        internal void Process(int data)
        {
            this.Ram.SaveValue(data);
            try
            {
                this.CPU.SquareNumber();
            }
            catch (ArgumentNullException)
            {
                this.VideoCard.Draw("Number too low.");
            }
            catch (ArgumentOutOfRangeException)
            {
                this.VideoCard.Draw("Number too high.");
            }

            int result = this.Ram.LoadValue();
            this.VideoCard.Draw(string.Format("Square of {0} is {1}.", data, result));
        }
    }
}
