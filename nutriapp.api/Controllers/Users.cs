using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.Users;

namespace nutriapp.api.Controllers;

public class Users(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(ControllerStandardResponse(response));
        }

        return Ok(ControllerStandardResponse(response));
    }
}
