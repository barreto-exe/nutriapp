using nutriapp.business.Base;
using GroupUnitMenuModel = nutriapp.models.GroupUnitMenu;

namespace nutriapp.business.GroupUnitMenu;

public class GetGroupUnitMenuResponse : BaseCommandResponse
{
    public IEnumerable<GroupUnitMenuModel>? GroupUnitMenu { get; set; }
}