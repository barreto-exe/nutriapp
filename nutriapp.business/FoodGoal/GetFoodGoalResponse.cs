using nutriapp.business.Base;

namespace nutriapp.business.FoodGoal;

public class GetFoodGoalResponse : BaseCommandResponse
{
    public IEnumerable<models.FoodGoal> Goals { get; set; }
}