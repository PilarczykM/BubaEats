using BubaEats.Domain.Entities;

namespace BubaEats.Application.Common.Interfaces.Persistent;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
