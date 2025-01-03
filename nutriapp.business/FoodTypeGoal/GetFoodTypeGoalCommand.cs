using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.FoodTypeGoal;

public class GetFoodTypeGoalCommand : IRequest<GetFoodTypeGoalResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public DateTime Date { get; set; }
}
