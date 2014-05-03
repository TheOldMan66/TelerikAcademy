using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class Call // task 8
    {
        private DateTime callDate;
        private string dialedPhone;
        private int duration;

        public Call(DateTime date, string number, int duration)
        {
            this.CallDate = date;
            this.DialedPhone = number;
            this.Duration = duration;
        }

        public DateTime CallDate
        {
            get { return callDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Invalid call date");
                else
                    callDate = value;
            }
        }

        public string DialedPhone
        {
            get { return dialedPhone; }
            set
            {
                ulong tmp;
                if (ulong.TryParse(value, out tmp))
                    dialedPhone = value;
                else
                    throw new ArgumentException("Invalid phone number");
            }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                if (value > 0)
                    duration = value;
                else
                    throw new ArgumentException("Invalid call duration");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Date: ");
            sb.Append(this.CallDate);
            sb.Append(" Phone: ");
            sb.Append(this.dialedPhone);
            sb.Append(" Duration: ");
            sb.Append(TimeSpan.FromSeconds(this.duration));
            return sb.ToString();
        }
    }
}
