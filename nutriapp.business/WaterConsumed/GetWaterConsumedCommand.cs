using MediatR;

namespace nutriapp.business.WaterConsumed;

public class GetWaterConsumedCommand : IRequest<GetWaterConsumedResponse>
{
    public int User { get; set; }
}