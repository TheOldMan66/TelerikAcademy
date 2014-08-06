namespace Computers.UI.Console
{
    public interface IMotherboard
    {
        int LoadRamValue(); 

        void SaveRamValue(int value); 

        void DrawOnVideoCard(string data);
    }
}
