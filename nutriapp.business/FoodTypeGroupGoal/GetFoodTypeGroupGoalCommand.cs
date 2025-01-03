using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.FoodTypeGroupGoal;

public class GetFoodTypeGroupGoalCommand : IRequest<GetFoodTypeGroupGoalResponse>
{
    [JsonIgnore]
    public int User { get; set; }
}
