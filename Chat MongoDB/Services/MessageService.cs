using Chat_MongoDB.Data;
using Chat_MongoDB.Models;

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
            message.Timestamp = DateTime.UtcNow;
            _context.Messages.InsertOne(message);
        }
    }

}
