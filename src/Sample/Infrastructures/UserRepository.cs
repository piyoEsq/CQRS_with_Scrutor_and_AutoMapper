using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Sample.Interfaces.Repositories;
using Sample.Models;

namespace Sample.Infrastructures
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public List<User> Users { get; set; } = new List<User>();

        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }
        public void Add(User user)
        {
            Users.Add(user);
        }

        public User GetById(UserId userId)
        {
            var user = Users.SingleOrDefault(s => s.Id == userId) ?? User.Empty();
            return user;
        }
    }
}