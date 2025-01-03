using nutriapp.business.Base;

namespace nutriapp.business.Auth;

public class RegisterResponse : BaseCommandResponse
{
    public string Token { get; set; }
}