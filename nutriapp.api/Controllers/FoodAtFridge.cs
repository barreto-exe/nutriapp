using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.FoodAtFridge;

namespace nutriapp.api.Controllers;

public class FoodAtFridge(IMediator mediator) : MyControllerBase(mediator)
{

    [HttpPost]
    public async Task<IActionResult> CreateFoodAtFridge(CreateFoodAtFridgeCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodAtFridge([FromQuery] GetFoodAtFridgeCommand command)
    {
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(response);
    }
}
