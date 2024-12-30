using MediatR;

namespace nutriapp.business.WaterMeasures;

public class CreateWaterMeasureCommand : IRequest<CreateWaterMeasureResponse>
{
    public int UserId { get; set; }
    public double Quantity { get; set; }
    public int MeasureType { get; set; }
}
