namespace ComputerParts
{
    using ComputerDefinition;

    public interface IComputerFactory
    {
        Computer MakeDesktop();

        Computer MakeLaptop();

        Computer MakeServer();
    }
}
