using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class GSMDisplay
    {
        private int sizeX;
        private int sizeY;
        private int numberOfColors;

        public int SizeX
        {
            get { return sizeX; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Invalid display resolution");
                else
                    sizeX = value;
            }
        }

        public int SizeY
        {
            get { return sizeY; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Invalid display resolution");
                else
                    sizeY = value;
            }
        }

        public int NumberOfColors
        {
            get { return numberOfColors; }
            set
            {
                if (value < 2)
                    throw new ArgumentException("Invalid display color count");
                else
                    numberOfColors = value;
            }
        }

        public GSMDisplay(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        public GSMDisplay(int sizeX, int sizeY, int numOfColors)
            : this(sizeX, sizeY)
        {
                this.NumberOfColors = numOfColors;
        }
    }
}
