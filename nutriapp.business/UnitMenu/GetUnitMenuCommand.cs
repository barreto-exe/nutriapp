using MediatR;

namespace nutriapp.business.UnitMenu;

public class GetUnitMenuCommand : IRequest<GetUnitMenuResponse>
{
    public int User { get; set; }
}
