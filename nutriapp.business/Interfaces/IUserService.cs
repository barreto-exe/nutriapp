using nutriapp.core.Entities;

namespace nutriapp.business.Interfaces;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<User> GetByEmailAsync(string email);
}