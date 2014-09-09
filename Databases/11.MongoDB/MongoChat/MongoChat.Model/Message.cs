namespace MongoChat.Model
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        public ObjectId id { get; set; }
        public DateTime TimeStamp { get; set; }
        public User Sender { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return this.Sender.UserName + " " +
                    this.TimeStamp.ToLocalTime().ToShortDateString() + " " +
                    this.TimeStamp.ToLocalTime().ToShortTimeString() + " " +
                    this.Text;
        }
    }
}
