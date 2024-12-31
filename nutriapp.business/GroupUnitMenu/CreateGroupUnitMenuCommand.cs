using MediatR;

namespace nutriapp.business.GroupUnitMenu;

public class CreateGroupUnitMenuCommand : IRequest<CreateGroupUnitMenuResponse>
{
    public int MealType { get; set; }
    public int FoodTypeGroup { get; set; }
    public int Quantity { get; set; }
}