using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class GSMBattery
    {
        public enum batteryType { LiIon, NiMH, NiCD }; // task 3

        private batteryType model;
        private int hoursIdle;
        private int hoursTalk;

        public batteryType Model
        {
            get { return model; }
            set { model = value; }
        }

        public int HoursIdle
        {
            get { return hoursIdle; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid battery time");
                else
                    hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid battery time");
                else
                    hoursTalk = value;
            }
        }

        public GSMBattery(int hoursIdle, int hoursTalk)
        {
            this.HoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public GSMBattery(int hoursIdle, int hoursTalk,batteryType model)
            : this(hoursIdle,hoursTalk)
        {
            this.Model = model;
        }
    }
}
