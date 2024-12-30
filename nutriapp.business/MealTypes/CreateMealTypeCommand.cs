using MediatR;

namespace nutriapp.business.MealTypes;

public class CreateMealTypeCommand : IRequest<CreateMealTypeResponse>
{
    public int User { get; set; }
    public required string Name { get; set; }
}