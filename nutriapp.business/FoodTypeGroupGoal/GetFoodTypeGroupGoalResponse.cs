using nutriapp.business.Base;
using nutriapp.models;

namespace nutriapp.business.FoodTypeGroupGoal;

public class GetFoodTypeGroupGoalResponse : BaseCommandResponse
{
    public IEnumerable<FoodTypeGroupGoalDetail>? Goals { get; set; }
}