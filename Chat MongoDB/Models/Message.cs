using MongoDB.Bson;

namespace Chat_MongoDB.Models
{
    public class Message
    {
        public ObjectId Id { get; set; }
        public ObjectId FromUserId { get; set; }
        public ObjectId ToUserId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
