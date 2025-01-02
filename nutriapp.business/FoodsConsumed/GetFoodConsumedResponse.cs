using nutriapp.business.Base;
using nutriapp.models;

namespace nutriapp.business.FoodsConsumed;

public class GetFoodConsumedResponse : BaseCommandResponse
{
    public List<FoodUnitEquivalent> FoodConsumed { get; set; }
}