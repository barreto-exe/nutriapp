using MediatR;

namespace nutriapp.business.FoodAtFridge;

public class GetFoodAtFridgeCommand : IRequest<GetFoodAtFridgeResponse>
{
    public int User { get; set; }
    public DateTime Date { get; set; }
}