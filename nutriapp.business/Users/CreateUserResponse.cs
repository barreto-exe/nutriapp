using nutriapp.business.Base;

namespace nutriapp.business.Users;

public class CreateUserResponse : BaseCommandResponse
{
    public int? UserId { get; set; }
}