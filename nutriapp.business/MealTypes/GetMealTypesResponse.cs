using nutriapp.models;

namespace nutriapp.business.MealTypes;

public class GetMealTypesResponse
{
    public IEnumerable<MealType>? MealTypes { get; set; }
}