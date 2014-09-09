namespace MongoChat.Model
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;
    public class User
    {
        public string UserName { get; set; }

        [BsonIgnore]
        public DateTime LastLogin { get; set; }
    }
}
