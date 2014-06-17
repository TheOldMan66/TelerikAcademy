using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class GSM
    {
        private static readonly GSM iPhone4S = new GSM("IPhone 4S", "Apple", 1500M, "BigBoss",
                    new GSMBattery(200, 20, GSMBattery.batteryType.LiIon),
                    new GSMDisplay(800, 600, 16000000)); // task 6
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private GSMDisplay display;
        private GSMBattery battery;
        private List<Call> callHistory; // task 9

        public static GSM IPhone4S // task 6
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Model // task 5
        {
            get { return model; }
            set {
                if (value == null || value == "")
                    throw new ArgumentException("Invalid model name");
                else 
                    model = value;
            }
        }

        public string Manufacturer // task 5
        {
            get { return manufacturer; }
            set {
                if (value == null || value == "")
                    throw new ArgumentException("Invalid maufacturer name");
                else
                    manufacturer = value;
            }
        }

        public decimal? Price // task 5
        {
            get { return price; }
            set {
                if (value < 0)
                    throw new ArgumentException("Invalid price");
                else 
                    price = value;
            }
        }

        public string Owner // task 5
        {
            get
            {
                if (owner == "" || owner == null)
                    return "Unknown";
                else
                    return owner;
            }
            set { owner = value; }
        }

        public GSMDisplay Display // task 2
        {
            get { return display; }
            set { display = value; }
        }
        public GSMBattery Battery // task 2
        {
            get { return battery; }
            set { battery = value; }
        }

        public GSM(string model, string manufacturer) // task 2
        {
            if (model == null || model == "")
                throw new ArgumentException("Invalid model name");
            else
                this.model = model;

            if (manufacturer == null || manufacturer == "") // task 2
                throw new ArgumentException("Invalid manufacturer name");
            else
                this.manufacturer = manufacturer;
            this.price = null;
            this.callHistory = new List<Call>(); // task 9
        }

        public GSM(string model, string manufacturer, decimal? price) // task 2
            : this(model, manufacturer)
        {
            if (price < 0)
                throw new ArgumentException("Invalid price");
            else
                this.price = price;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner) // task 2
            : this(model, manufacturer, price)
        {
            this.owner = owner;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, GSMBattery battery) // task 2
            : this(model, manufacturer, price, owner)
        {
            this.battery = battery;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, GSMBattery battery, GSMDisplay display) // task 2
            : this(model, manufacturer, price, owner, battery)
        {
            this.display = display;
        }

        public override string ToString() //task 4
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Model: ");
            sb.AppendLine(this.Model);
            sb.Append("Manufacturer: ");
            sb.AppendLine(this.Manufacturer);
            sb.Append("Price: ");
            if (this.price == null)
                sb.Append("No information");
            else
                sb.Append(string.Format("{0:C}", this.Price));
            sb.Append(Environment.NewLine);
            sb.Append("Owner: ");
            sb.AppendLine(this.Owner);
            sb.Append("Display: ");
            if (this.display == null)
            {
                sb.Append("No information");
            }
            else
            {
                sb.Append(" Resolution ");
                sb.Append(this.display.SizeX);
                sb.Append(" x ");
                sb.Append(this.display.SizeY);
                sb.Append(" pixels, ");
                sb.Append(this.display.NumberOfColors);
                sb.Append(" colors");
            }
            sb.Append(Environment.NewLine);
            sb.Append("Battery: ");
            if (this.battery == null)
            {
                sb.Append("No information");
            }
            else
            {
                sb.Append(" Model: ");
                sb.Append(this.battery.Model);
                sb.Append(", Talk time (hours): ");
                sb.Append(this.battery.HoursTalk);
                sb.Append(", Idle time (hours): ");
                sb.Append(this.battery.HoursIdle);
            }
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        public List<Call> CallHistory
        {
            get { return this.callHistory; }
        }

        public void RemoveCallListItem(int index) // task 10
        {
            if (index > -1 && index < this.callHistory.Count)
                this.callHistory.RemoveAt(index);
            else
                throw new IndexOutOfRangeException("Invalid call history index");
        }

        public void AddCallInHistory(Call call) // task 10
        {
            this.callHistory.Add(call);
        }

        public void ClearCallHistory() // task 10
        {
            this.callHistory.Clear();
        }

        public void PrintCallHistory()
        {
            if (this.callHistory.Count == 0)
                Console.WriteLine("Call history is empty");
            else
            foreach (Call call in this.callHistory)
                Console.WriteLine(call);
        }

        public decimal CalculateCallTotalPrice(decimal pricePerMinute) // task 11
        {
            int totalDuration = 0;
            foreach (Call call in this.callHistory)
                totalDuration = totalDuration + call.Duration;
            return totalDuration / 60 * pricePerMinute;
        }
    }
}
