using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.FoodAtFridge;

public class CreateFoodAtFridgeCommand : IRequest<CreateFoodAtFridgeResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public int Food { get; set; }
    public double? Quantity { get; set; }
    public int? MeasureType { get; set; }
    public double? CookedQuantity { get; set; }
    public int? CookedMeasureType { get; set; }
    public double? PracticalQuantity { get; set; }
    public int? PracticalMeasureType { get; set; }
}