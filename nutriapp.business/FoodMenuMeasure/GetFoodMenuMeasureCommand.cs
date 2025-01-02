using MediatR;

namespace nutriapp.business.FoodMenuMeasure;

public class GetFoodMenuMeasureCommand : IRequest<GetFoodMenuMeasureResponse>
{
    public int User { get; set; }
    public DateTime Date { get; set; }
}