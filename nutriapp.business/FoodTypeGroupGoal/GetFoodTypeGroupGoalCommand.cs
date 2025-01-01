using MediatR;

namespace nutriapp.business.FoodTypeGroupGoal;

public class GetFoodTypeGroupGoalCommand : IRequest<GetFoodTypeGroupGoalResponse>
{
    public int User { get; set; }
}
