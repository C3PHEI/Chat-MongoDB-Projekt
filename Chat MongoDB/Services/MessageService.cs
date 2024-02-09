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

        public List<Message> GetMessagesBetweenParticipants(string Person1, string Person2)
        {
            var builder = Builders<Message>.Filter;

            // Dieser Filter prüft, ob die IDs in irgendeiner Kombination in P1 und P2 erscheinen
            var filter = builder.Or(
                builder.And(
                    builder.Eq("chatWith.P1", Person1),
                    builder.Eq("chatWith.P2", Person2)
                ),
                builder.And(
                    builder.Eq("chatWith.P1", Person2),
                    builder.Eq("chatWith.P2", Person1)
                )
            );

            return _context.Messages.Find(filter).ToList();
        }

    }
}
