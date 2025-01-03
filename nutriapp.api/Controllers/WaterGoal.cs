using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.WaterMeasures;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace nutriapp.api.Controllers;

public class WaterGoal(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateWaterMeasure(CreateWaterMeasureCommand command)
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
    public async Task<IActionResult> GetWaterMeasures()
    {
        int userId = Convert.ToInt32(GetTokenClaimValue("id"));

        var response = await mediator.Send(new GetWaterMeasureCommand { User = userId });

        if (response == null || !response.Success) return NotFound();

        return Ok(ControllerStandardResponse(response));
    }

}
