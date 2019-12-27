using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Sample.Interfaces.Repositories;
using Sample.Models;

namespace Sample.Infrastructures
{
    public class CacheUserRepository : IUserRepository
    {
        private readonly ILogger<CacheUserRepository> _logger;
        private readonly IUserRepository _userRepository;
        private Dictionary<UserId, User> cache = new Dictionary<UserId, User>();

        public CacheUserRepository(ILogger<CacheUserRepository> logger,
                                   IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User GetById(UserId userId)
        {
            User user = null;
            if (cache.TryGetValue(userId, out user))
            {
                _logger.LogInformation("User found in cached data.");
                return user;
            }

            _logger.LogInformation("User not found in cached data.");
            user = _userRepository.GetById(userId);
            cache.TryAdd(userId, user);
            return user;
        }
    }
}