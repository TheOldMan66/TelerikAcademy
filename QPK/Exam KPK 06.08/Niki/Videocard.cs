namespace ComputerParts
{
    using System;

    internal class Videocard : IVideocard
    {
        public Videocard()
        {
            this.IsMonochrome = true;
        }

        public Videocard(bool isMonochrome)
        {
            this.IsMonochrome = isMonochrome;
        }

        public bool IsMonochrome { get; set; }

        public void Draw(string a)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(a);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(a);
                Console.ResetColor();
            }
        }
    }
}
