using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace nutriapp.api.Controllers;

[ApiController]
[Route("[controller]")]
public class MyControllerBase : ControllerBase
{
    protected readonly IMediator mediator;

    public MyControllerBase(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
