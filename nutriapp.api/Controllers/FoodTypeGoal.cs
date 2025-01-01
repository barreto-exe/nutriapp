using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.FoodTypeGoal;

namespace nutriapp.api.Controllers;

public class FoodTypeGoal(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateFoodTypeGoal(CreateFoodTypeGoalCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodTypeGoal(int userId)
    {
        var command = new GetFoodTypeGoalCommand { User = userId };
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(response);
    }
}
