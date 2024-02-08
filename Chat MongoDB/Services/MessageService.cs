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

        // In your MessageService class

        public List<Message> GetMessagesBetweenParticipants(string participantId1, string participantId2)
        {
            var builder = Builders<Message>.Filter;
            // Diese Abfrage prüft, ob eine der beiden IDs in den Feldern P1 oder P2 erscheint
            var filter = builder.Or(
                builder.And(
                    builder.Eq("chatWith.P1", participantId1),
                    builder.Eq("chatWith.P2", participantId2)
                ),
                builder.And(
                    builder.Eq("chatWith.P1", participantId2),
                    builder.Eq("chatWith.P2", participantId1)
                ),
                builder.And(
                    builder.Eq("chatWith.P1", participantId1),
                    builder.Eq("fromUserId", participantId2)
                ),
                builder.And(
                    builder.Eq("chatWith.P1", participantId2),
                    builder.Eq("fromUserId", participantId1)
                )
            );

            return _context.Messages.Find(filter).ToList();
        }


    }
}
