using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.FoodGoal;

namespace nutriapp.api.Controllers;

public class FoodGoal(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateFoodGoal(CreateFoodGoalCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodGoal([FromQuery] GetFoodGoalCommand command)
    {
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(response);
    }
}
