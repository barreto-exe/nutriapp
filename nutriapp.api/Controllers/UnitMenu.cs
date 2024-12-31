using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.UnitMenu;

namespace nutriapp.api.Controllers;

public class UnitMenu(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateUnitMenu(CreateUnitMenuCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetUnitMenu(int userId)
    {
        var command = new GetUnitMenuCommand { User = userId };
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(response);
    }
}
