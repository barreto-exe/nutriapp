﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.WaterConsumed;

namespace nutriapp.api.Controllers;

public class WaterConsumed(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateWaterConsumed(CreateWaterConsumedCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}