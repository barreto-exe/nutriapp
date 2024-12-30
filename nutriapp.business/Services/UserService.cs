using nutriapp.business.Base;
using nutriapp.business.Interfaces;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<User> CreateAsync(User user)
    {
        user.CreatedDate = DateTime.Now;

        await unitOfWork.UserRepository.Add(user);
        await unitOfWork.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var users = unitOfWork.UserRepository.GetAll();
        var user = users.Where(x => x.Email == email).FirstOrDefault();
        return user;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await unitOfWork.UserRepository.GetById(id);
        return user;
    }
}