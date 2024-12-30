using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.Users;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IUserService userService;

    public CreateUserHandler(IUnitOfWork unitOfWork, IUserService userService)
    {
        this.unitOfWork = unitOfWork;
        this.userService = userService;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userService.GetByEmail(request.Email);

        if (user != null)
        {
            return new CreateUserResponse
            {
                Success = false,
                Message = "User already exists"
            };
        }

        user = new User
        {
            Email = request.Email,
            Password = request.Password,
            Name = request.Name,
            Lastname = request.LastName
        };

        var createdUser = await userService.Create(user);
        return new CreateUserResponse
        {
            Success = true,
            Message = "OK",
            UserId = createdUser.Id
        };
    }
}