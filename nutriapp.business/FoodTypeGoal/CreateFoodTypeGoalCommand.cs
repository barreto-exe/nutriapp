using MediatR;

namespace nutriapp.business.FoodTypeGoal;

public class CreateFoodTypeGoalCommand : IRequest<CreateFoodTypeGoalResponse>
{
    public int User { get; set; }
    public int FoodType { get; set; }
    public int MaxQuantity { get; set; }
}