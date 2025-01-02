using MediatR;

namespace nutriapp.business.FoodGoal;

public class GetFoodGoalCommand : IRequest<GetFoodGoalResponse>
{
    public int User { get; set; }
    public DateTime Date { get; set; }
}