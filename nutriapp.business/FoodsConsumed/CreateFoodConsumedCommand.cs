using MediatR;

namespace nutriapp.business.FoodsConsumed;

public class CreateFoodConsumedCommand : IRequest<CreateFoodConsumedResponse>
{
    public int User { get; set; }
    public int Food { get; set; }
    public double? Quantity { get; set; }
    public int? MeasureType { get; set; }
    public double? CookedQuantity { get; set; }
    public int? CookedMeasureType { get; set; }
    public double? PracticalQuantity { get; set; }
    public int? PracticalMeasureType { get; set; }
}
