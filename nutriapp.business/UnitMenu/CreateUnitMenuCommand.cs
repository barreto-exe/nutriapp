using MediatR;

namespace nutriapp.business.UnitMenu;

public class CreateUnitMenuCommand : IRequest<CreateUnitMenuResponse>
{
    public int User { get; set; }
    public int FoodType { get; set; }
    public int MaxQuantity { get; set; }
}