using Chat_MongoDB.Data;
using Chat_MongoDB.Models;
using MongoDB.Driver;

namespace Chat_MongoDB.Services
{
    public class MessageService
    {
        private readonly MongoDbContext _context;

        public MessageService(MongoDbContext context)
        {
            _context = context;
        }

        public void PostMessage(Message message)
        {
            message.timestamp = DateTime.UtcNow;
            _context.Messages.InsertOne(message);
        }

        public List<Message> GetMessages()
        {
            return _context.Messages.Find(message => true).ToList();
        }
    }
}
