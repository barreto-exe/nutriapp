using MediatR;
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
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodGroupGoal(int userId)
    {
        var command = new GetFoodTypeGroupGoalCommand { User = userId };
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(response);
    }
}
