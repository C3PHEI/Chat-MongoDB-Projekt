using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Chat_MongoDB.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string fromUserId { get; set; }

        public string message { get; set; }

        [BsonElement("timestamp")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime timestamp { get; set; }

        public ChatWithParticipants chatWith { get; set; }
    }

    public class ChatWithParticipants
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string P1 { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string P2 { get; set; }
    }
}
