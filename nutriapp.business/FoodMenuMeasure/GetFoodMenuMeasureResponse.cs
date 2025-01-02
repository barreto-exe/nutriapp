using nutriapp.business.Base;

namespace nutriapp.business.FoodMenuMeasure;

public class GetFoodMenuMeasureResponse : BaseCommandResponse
{
    public IEnumerable<models.FoodGoal> Goals { get; set; }
}