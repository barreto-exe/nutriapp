using nutriapp.business.Base;

namespace nutriapp.business.Login;

public class LoginResponse : BaseCommandResponse
{
    public string Token { get; set; }
}