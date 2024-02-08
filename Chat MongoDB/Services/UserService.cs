using Chat_MongoDB.Data;
using Chat_MongoDB.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Chat_MongoDB.Services
{
    public class UserService
    {
        private readonly MongoDbContext _context;

        public UserService(MongoDbContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
           
            _context.Users.InsertOne(user);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.Find(user => true).ToList();
        }
    }
}
