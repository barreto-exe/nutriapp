﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.Users;

namespace nutriapp.api.Controllers;

public class UsersController : MyControllerBase
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

}
