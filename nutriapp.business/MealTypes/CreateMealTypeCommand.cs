using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.MealTypes;

public class CreateMealTypeCommand : IRequest<CreateMealTypeResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public required string Name { get; set; }
}