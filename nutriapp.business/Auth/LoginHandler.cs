using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using nutriapp.business.Auth;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace nutriapp.business.Login;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IConfiguration configuration;

    public LoginHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.configuration = configuration;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = new LoginResponse();

        var user = await unitOfWork.UserRepository
            .GetAll()
            .FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password.EncodeString(), cancellationToken);

        response.AddValidationMessages(
        [
            (user == null, "Invalid email or password")
        ]);

        if (!response.Success)
        {
            return response;
        }

        response.Token = GenerateToken(user!);

        return response;
    }

    private string GenerateToken(User user)
    {
        //Header
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
        var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
        var header = new JwtHeader(signingCredentials);

        //Claims
        var claims = new[]
        {
            new Claim("id", user.Id.ToString()),
            new Claim("name", $"{user.Name} {user.Lastname}"),
            new Claim("email", user.Email),
        };

        //Payload
        var payload = new JwtPayload(string.Empty, string.Empty, claims, DateTime.UtcNow, DateTime.UtcNow.AddDays(30));

        var token = new JwtSecurityToken(header, payload);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}