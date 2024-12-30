using MediatR;
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

    [HttpGet]
    public async Task<IActionResult> GetWaterConsumed(int userId)
    {
        var response = await mediator.Send(new GetWaterConsumedCommand { User = userId });

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}
