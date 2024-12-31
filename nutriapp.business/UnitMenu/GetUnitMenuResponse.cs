using nutriapp.business.Base;
using nutriapp.models;

namespace nutriapp.business.UnitMenu;

public class GetUnitMenuResponse : BaseCommandResponse
{
    public IEnumerable<FoodTypeQuantity> UnitMenu { get; set; }
}