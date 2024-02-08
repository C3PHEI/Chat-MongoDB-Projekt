using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat_MongoDB.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}
