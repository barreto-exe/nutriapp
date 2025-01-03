using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.FoodMenuMeasure;

namespace nutriapp.api.Controllers;

public class FoodMenuMeasure(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateFoodGoal(CreateFoodMenuMeasureCommand command)
    {
        command.User = Convert.ToInt32(GetTokenClaimValue("id"));

        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(ControllerStandardResponse(response));
        }

        return Ok(ControllerStandardResponse(response));
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodGoal([FromQuery] GetFoodMenuMeasureCommand command)
    {
        command.User = Convert.ToInt32(GetTokenClaimValue("id"));

        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(ControllerStandardResponse(response));
    }
}
