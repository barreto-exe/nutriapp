using nutriapp.business.Base;
using nutriapp.models;

namespace nutriapp.business.FoodAtFridge;

public class GetFoodAtFridgeResponse : BaseCommandResponse
{
    public List<FoodUnitEquivalent> FoodAtFridge { get; set; }
}