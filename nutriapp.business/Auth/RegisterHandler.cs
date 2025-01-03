using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Login;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.Auth;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IMediator mediator;

    public RegisterHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.mediator = mediator;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = new RegisterResponse();

        var user = await unitOfWork.UserRepository
            .GetAll()
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

        response.AddValidationMessages(
        [
            (user != null, "Email already in use")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var userEntity = mapper.Map<User>(request);

        userEntity.CreatedDate = DateTime.Now;
        userEntity.Password = request.Password.EncodeString();

        await unitOfWork.UserRepository.AddAsync(userEntity);
        await unitOfWork.SaveChangesAsync();

        var loginCommand = new LoginCommand
        {
            Email = request.Email,
            Password = request.Password
        };

        var loginResponse = await mediator.Send(loginCommand, cancellationToken);

        response.Token = loginResponse.Token;

        return response;
    }
}