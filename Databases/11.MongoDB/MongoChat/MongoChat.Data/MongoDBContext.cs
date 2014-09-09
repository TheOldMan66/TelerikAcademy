namespace MongoChat.Data
{
    using MongoChat.Model;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System;
    using System.Collections.Generic;

    public class MongoDBContext
    {
        private const string MESSAGE_COLLECTION_NAME = "Messages";
        private MongoClient mongoClient;
        private MongoServer mongoServer;
        private MongoDatabase mongoDatabase;

        public MongoDBContext()
        {
            this.mongoClient = new MongoClient(MongoChatSettings.Default.MongoConnectionString);
            this.mongoServer = mongoClient.GetServer();
            mongoDatabase = mongoServer.GetDatabase("mongochat");
            if (!mongoDatabase.CollectionExists(MESSAGE_COLLECTION_NAME))
            {
                mongoDatabase.CreateCollection(MESSAGE_COLLECTION_NAME);
            }
        }

        public void AddPost(Message post)
        {
            var posts = mongoDatabase.GetCollection<Message>(MESSAGE_COLLECTION_NAME);
            posts.Insert(post);
        }

        public IEnumerable<Message> GetPosts()
        {
            var postsDB = mongoDatabase.GetCollection<Message>(MESSAGE_COLLECTION_NAME);
            List<Message> list = new List<Message>();
            var messages = postsDB.FindAll();
            foreach (var item in messages)
            {
                list.Add(item);
            }
            return list;
        }

        public IEnumerable<Message> GetPosts(DateTime fromDate)
        {
            var query = Query.GT("TimeStamp", fromDate.ToUniversalTime());
            var postDB = mongoDatabase.GetCollection<Message>(MESSAGE_COLLECTION_NAME);
            var messages = postDB.Find(query);
            List<Message> list = new List<Message>();
            foreach (var item in messages)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
