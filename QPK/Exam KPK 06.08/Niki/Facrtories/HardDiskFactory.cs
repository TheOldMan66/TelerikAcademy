namespace ComputerParts
{
    public class HardDiskFactory
    {
        public IHardDrive CreateHardDisk(int capacity)
        {
            IHardDrive newDrive = new SingleHardDrive(capacity);
            return newDrive;
        }

        public IHardDrive CreateHardDisk(int capacity, int numOfDisksInRaid)
        {
            IHardDrive newDrive = new RaidHardDrive(capacity, numOfDisksInRaid);
            return newDrive;
        }
    }
}
