using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.WaterConsumed;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace nutriapp.api.Controllers;

public class WaterConsumed(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateWaterConsumed(CreateWaterConsumedCommand command)
    {
        command.User = Convert.ToInt32(GetTokenClaimValue("id"));

        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetWaterConsumed()
    {
        int userId = Convert.ToInt32(GetTokenClaimValue("id"));

        var response = await mediator.Send(new GetWaterConsumedCommand { User = userId });

        if (response == null || !response.Success) return NotFound();

        return Ok(response);
    }
}
