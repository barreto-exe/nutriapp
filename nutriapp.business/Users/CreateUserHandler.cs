using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.Users;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IUserService userService;
    private readonly IMapper mapper;

    public CreateUserHandler(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.userService = userService;
        this.mapper = mapper;
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

        user = mapper.Map<User>(request);

        await userService.Create(user);

        return new CreateUserResponse
        {
            Success = true,
            Message = "OK",
            UserId = user.Id
        };
    }
}