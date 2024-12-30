using MediatR;

namespace nutriapp.business.MealTypes;

public class GetMealTypesCommand : IRequest<GetMealTypesResponse>
{
    public int User { get; set; }
}