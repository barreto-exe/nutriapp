using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.FoodTypeGoal;

public class CreateFoodTypeGoalCommand : IRequest<CreateFoodTypeGoalResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public int FoodType { get; set; }
    public int MaxQuantity { get; set; }
}