using nutriapp.business.Base;
using nutriapp.models;

namespace nutriapp.business.MealTypes;

public class GetMealTypesResponse : BaseCommandResponse
{
    public IEnumerable<MealType>? MealTypes { get; set; }
}