using MediatR;

namespace nutriapp.business.MealTypes;

public class UpdateMealTypeCommand : IRequest<UpdateMealTypeResponse>
{
    public int Meal { get; set; }
    public int User { get; set; }
    public required string Name { get; set; }
}
