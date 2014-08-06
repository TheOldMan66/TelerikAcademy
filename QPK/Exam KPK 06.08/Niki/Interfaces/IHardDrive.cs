namespace ComputerParts
{
    public interface IHardDrive
    {
        int Capacity { get; }

        void SaveData(int addr, string newData);

        string LoadData(int address);
    }
}
