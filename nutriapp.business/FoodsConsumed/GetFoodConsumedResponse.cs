using nutriapp.business.Base;
using nutriapp.models;

namespace nutriapp.business.FoodsConsumed;

public class GetFoodConsumedResponse : BaseCommandResponse
{
    public List<FoodConsumed> FoodConsumed { get; set; }
}