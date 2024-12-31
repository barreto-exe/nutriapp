using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.business.Services;
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
        var response = new CreateUserResponse();
        var user = await userService.GetByEmailAsync(request.Email);

        response.AddValidationMessages(
        [
            (user != null, "User already exists")
        ]);

        if (!response.Success)
        {
            return response;
        }

        user = mapper.Map<User>(request);

        await userService.CreateAsync(user);

        response.UserId = user.Id;
        return response;
    }
}