using BubaEats.Application.Common.Interfaces.Persistent;
using BubaEats.Domain.Entities;

namespace BubaEats.Infrastructure.Persistent;

public class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> _users = [];
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email == email);
    }
}
