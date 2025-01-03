using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.MealTypes;

public class UpdateMealTypeCommand : IRequest<UpdateMealTypeResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public int Meal { get; set; }
    public required string Name { get; set; }
}
