using nutriapp.business.Base;
using GroupUnitMenuModel = nutriapp.models.GroupUnitMenu;

namespace nutriapp.business.FoodTypeGroupGoal;

public class GetFoodTypeGroupGoalResponse : BaseCommandResponse
{
    public IEnumerable<GroupUnitMenuModel>? GroupUnitMenu { get; set; }
}