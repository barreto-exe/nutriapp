using MediatR;
using Microsoft.AspNetCore.Mvc;
using nutriapp.business.MealTypes;

namespace nutriapp.api.Controllers;

public class MealTypes(IMediator mediator) : MyControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateMealType(CreateMealTypeCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetMealTypes(int userId)
    {
        var command = new GetMealTypesCommand { User = userId };
        var response = await mediator.Send(command);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMealType(UpdateMealTypeCommand command)
    {
        var response = await mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}
