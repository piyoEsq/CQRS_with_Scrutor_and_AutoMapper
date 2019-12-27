using Sample.Models;

namespace Sample.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(UserId userId);
    }
}