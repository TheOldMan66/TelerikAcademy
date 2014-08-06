namespace ComputerDefinition
{
    using System;
    using System.Collections.Generic;
    using ComputerParts;

    internal class Computers
    {
        private static Computer pc, laptop, server;
        const string HPNAME = "HP";
        const string DELLNAME = "Dell";
        const string LENOVONAME = "Lenovo";

        public static void Main()
        {
            HardDiskFactory diskFactory = new HardDiskFactory();
            var manufacturer = Console.ReadLine();
            IComputerFactory factory;
            if (manufacturer == DELLNAME)
            {
                factory = new DellFactory();
            }
            else if (manufacturer == HPNAME)
            {
                factory = new HPFactory();
            }
            else if (manufacturer == LENOVONAME)
            {
                factory = new LenovoFactory();
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");
            }

            pc = factory.MakeDesktop();
            server = factory.MakeServer();
            laptop = factory.MakeLaptop();

            while (true)
            {
                var c = Console.ReadLine();
                if (c == null || c.StartsWith("Exit"))
                {
                    break;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var cn = cp[0];
                var ca = int.Parse(cp[1]);
                if (cn == "Charge")
                {
                    laptop.ChargeBattery(ca);
                }
                else if (cn == "Process")
                {
                    server.Process(ca);
                }
                else if (cn == "Play")
                {
                    pc.Play(ca);
                }

                continue;
            }
        }
    }
}
