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

        [BsonRepresentation(BsonType.ObjectId)]
        public string toUserId { get; set; }

        public string message { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime timestamp { get; set; }
    }
}