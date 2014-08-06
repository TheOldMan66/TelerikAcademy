namespace ComputerParts
{
    using ComputerDefinition;

    internal class HPFactory : IComputerFactory
    {
        private HardDiskFactory diskFactory = new HardDiskFactory();

        public Computer MakeDesktop()
        {
            var ram = new Ram(2);
            var videoCard = new Videocard(false);
            var cpu = new CPU32(ram, 2);
            IHardDrive hardDrive = this.diskFactory.CreateHardDisk(500);
            Computer computer = new Computer(ComputerTypes.Type.PC, cpu, ram, hardDrive, videoCard, null);
            return computer;
        }

        public Computer MakeServer()
        {
            var ram = new Ram(32);
            var videoCard = new Videocard(true);
            var cpu = new CPU64(ram, 4);
            var hardDrive = this.diskFactory.CreateHardDisk(1000, 2);
            Computer computer = new Computer(ComputerTypes.Type.PC, cpu, ram, hardDrive, videoCard, null);
            return computer;
        }

        public Computer MakeLaptop()
        {
            var ram = new Ram(4);
            var videoCard = new Videocard(false);
            var cpu = new CPU64(ram, 2);
            var hardDrive = this.diskFactory.CreateHardDisk(500);
            Computer computer = new Computer(ComputerTypes.Type.PC, cpu, ram, hardDrive, videoCard, new LaptopBattery());
            return computer;
        }
    }
}
