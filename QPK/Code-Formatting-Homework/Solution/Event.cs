namespace Events
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int compareByDate = this.Date.CompareTo(other.Date);
            int compareByTitle = this.Title.CompareTo(other.Title);
            int compareByLocation = this.Location.CompareTo(other.Location);

            if (compareByDate == 0)
            {
                if (compareByTitle == 0)
                {
                    return compareByLocation;
                }
                else
                {
                    return compareByTitle;
                }
            }
            else
            {
                return compareByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            result.Append(" | " + this.Title);
            if (this.Location != null && this.Location != string.Empty)
            {
                result.Append(" | " + this.Location);
            }

            return result.ToString();
        }
    }
}