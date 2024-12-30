using MediatR;

namespace nutriapp.business.WaterMeasures;

public class GetWaterMeasureCommand : IRequest<GetWaterMeasureResponse>
{
    public int UserId { get; set; }
}
