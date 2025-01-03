using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.MealTypes;

public class GetMealTypesCommand : IRequest<GetMealTypesResponse>
{
    [JsonIgnore]
    public int User { get; set; }
}