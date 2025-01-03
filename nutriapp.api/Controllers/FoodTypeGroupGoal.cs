﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.FoodTypeGroupGoal;

namespace nutriapp.api.Controllers;

public class FoodTypeGroupGoal(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateFoodGroupGoal(CreateFoodTypeGroupGoalCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(ControllerStandardResponse(response));
        }

        return Ok(ControllerStandardResponse(response));
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodGroupGoal()
    {
        var userId = Convert.ToInt32(GetTokenClaimValue("id"));

        var command = new GetFoodTypeGroupGoalCommand { User = userId };
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(ControllerStandardResponse(response));
    }
}
