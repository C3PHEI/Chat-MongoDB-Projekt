using MongoDB.Bson;
using System;

namespace Chat_MongoDB.Models
{
    public class LoginHistory
    {
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
    }
}

