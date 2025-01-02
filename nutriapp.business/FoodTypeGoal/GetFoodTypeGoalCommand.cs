using MediatR;

namespace nutriapp.business.FoodTypeGoal;

public class GetFoodTypeGoalCommand : IRequest<GetFoodTypeGoalResponse>
{
    public int User { get; set; }
    public DateTime Date { get; set; }
}
