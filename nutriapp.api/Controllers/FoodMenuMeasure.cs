using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.FoodMenuMeasure;

namespace nutriapp.api.Controllers;

public class FoodMenuMeasure(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateFoodGoal(CreateFoodMenuMeasureCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodGoal([FromQuery] GetFoodMenuMeasurelCommand command)
    {
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(response);
    }
}
