using MediatR;

namespace nutriapp.business.FoodTypeGroupGoal;

public class CreateFoodTypeGroupGoalCommand : IRequest<CreateFoodTypeGroupGoalResponse>
{
    public int MealType { get; set; }
    public int FoodTypeGroup { get; set; }
    public int Quantity { get; set; }
}