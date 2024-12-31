using MediatR;

namespace nutriapp.business.GroupUnitMenu;

public class GetGroupUnitMenuCommand : IRequest<GetGroupUnitMenuResponse>
{
    public int User { get; set; }
}
