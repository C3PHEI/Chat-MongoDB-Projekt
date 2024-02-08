using Chat_MongoDB.Models;
using MongoDB.Driver;

namespace Chat_MongoDB.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("users");
        public IMongoCollection<Message> Messages => _database.GetCollection<Message>("messages");
        public IMongoCollection<LoginHistory> loginHistory => _database.GetCollection<LoginHistory>("loginHistory");
    }

}
