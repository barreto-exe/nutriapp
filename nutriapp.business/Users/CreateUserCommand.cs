using MediatR;

namespace nutriapp.business.Users;

public class CreateUserCommand : IRequest<CreateUserResponse>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string Lastname { get; set; }
}