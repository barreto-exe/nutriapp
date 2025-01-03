using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace nutriapp.api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class MyControllerBase : ControllerBase
{
    protected readonly IMediator mediator;

    public MyControllerBase(IMediator mediator)
    {
        this.mediator = mediator;
    }

    protected string GetTokenClaimValue(string key)
    {
        var accessToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (string.IsNullOrEmpty(accessToken))
        {
            return string.Empty;
        }

        accessToken = accessToken.Trim().Replace("Bearer ", "");
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
        return jwt.Claims.First(c => c.Type == key).Value;
    }
}
