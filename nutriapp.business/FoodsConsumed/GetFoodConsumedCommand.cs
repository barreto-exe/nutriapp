using MediatR;

namespace nutriapp.business.FoodsConsumed;

public class GetFoodConsumedCommand : IRequest<GetFoodConsumedResponse>
{
    public int User { get; set; }
    public DateTime Date { get; set; }
}
