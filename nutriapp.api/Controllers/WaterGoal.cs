using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.WaterMeasures;

namespace nutriapp.api.Controllers;

public class WaterGoal(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateWaterMeasure(CreateWaterMeasureCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetWaterMeasures(int userId)
    {
        var response = await mediator.Send(new GetWaterMeasureCommand { UserId = userId });

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

}
