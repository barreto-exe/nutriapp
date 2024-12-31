using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.GroupUnitMenu;

namespace nutriapp.api.Controllers;

public class GroupUnitMenu(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateGroupUnitMenu(CreateGroupUnitMenuCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetGroupUnitMenu(int userId)
    {
        var command = new GetGroupUnitMenuCommand { User = userId };
        var response = await mediator.Send(command);

        return Ok(response);
    }
}
