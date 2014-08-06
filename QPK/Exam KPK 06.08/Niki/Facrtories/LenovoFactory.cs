namespace ComputerParts
{
    using ComputerDefinition;

    internal class LenovoFactory : IComputerFactory
    {
        private HardDiskFactory diskFactory = new HardDiskFactory();

        public Computer MakeDesktop()
        {
            var ram = new Ram(4);
            var videoCard = new Videocard(true);
            var cpu = new CPU64(ram, 2);
            IHardDrive hardDrive = this.diskFactory.CreateHardDisk(2000);
            Computer computer = new Computer(ComputerTypes.Type.PC, cpu, ram, hardDrive, videoCard, null);
            return computer;
        }

        public Computer MakeServer()
        {
            var ram = new Ram(8);
            var videoCard = new Videocard(true);
            var cpu = new CPU128(ram, 2);
            var hardDrive = this.diskFactory.CreateHardDisk(500, 2);
            Computer computer = new Computer(ComputerTypes.Type.PC, cpu, ram, hardDrive, videoCard, null);
            return computer;
        }

        public Computer MakeLaptop()
        {
            var ram = new Ram(16);
            var videoCard = new Videocard(false);
            var cpu = new CPU64(ram, 2);
            var hardDrive = this.diskFactory.CreateHardDisk(1000);
            Computer computer = new Computer(ComputerTypes.Type.PC, cpu, ram, hardDrive, videoCard, new LaptopBattery());
            return computer;
        }
    }
}
