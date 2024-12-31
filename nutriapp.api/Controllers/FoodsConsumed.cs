using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.FoodsConsumed;

namespace nutriapp.api.Controllers;

public class FoodConsumed(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateFoodConsumed(CreateFoodConsumedCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodConsumed([FromQuery] GetFoodConsumedCommand command)
    {
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(response);
    }
}
