using nutriapp.business.Base;
using nutriapp.models;

namespace nutriapp.business.FoodTypeGoal;

public class GetFoodTypeGoalResponse : BaseCommandResponse
{
    public List<models.FoodTypeGoal> Goals { get; set; }
}