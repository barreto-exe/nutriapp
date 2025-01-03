using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.Base;
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

    protected object ControllerStandardResponse(dynamic data)
    {
        return new
        {
            Data = data,
            data.Message,
            data.Success
        };
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
