using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.MealTypes;

namespace nutriapp.api.Controllers;

public class MealTypes(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateMealType(CreateMealTypeCommand command)
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
    public async Task<IActionResult> GetMealTypes()
    {
        int userId = Convert.ToInt32(GetTokenClaimValue("id"));

        var command = new GetMealTypesCommand { User = userId };
        var response = await mediator.Send(command);

        if (response == null || !response.Success) return NotFound();

        return Ok(ControllerStandardResponse(response));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMealType(UpdateMealTypeCommand command)
    {
        command.User = Convert.ToInt32(GetTokenClaimValue("id"));

        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(ControllerStandardResponse(response));
        }

        return Ok(ControllerStandardResponse(response));
    }
}
