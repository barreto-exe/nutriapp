using nutriapp.business.Interfaces;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<User> Create(User user)
    {
        user.CreatedDate = DateTime.Now;

        await unitOfWork.UserRepository.Add(user);
        await unitOfWork.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetByEmail(string email)
    {
        var users = unitOfWork.UserRepository.GetAll();
        var user = users.Where(x => x.Email == email).FirstOrDefault();
        return user;
    }
}