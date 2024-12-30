using nutriapp.core.Entities;

namespace nutriapp.business.Interfaces;

public interface IUserService
{
    Task<User> Create(User user);
    Task<User> GetByEmail(string email);
    Task<User> GetById(int id);
}