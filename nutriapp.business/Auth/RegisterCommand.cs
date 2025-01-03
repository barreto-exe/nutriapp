using MediatR;

namespace nutriapp.business.Auth;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
}