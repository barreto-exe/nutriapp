using MediatR;

namespace nutriapp.business.WaterConsumed;

public class CreateWaterConsumedCommand : IRequest<CreateWaterConsumedResponse>
{
    public int User { get; set; }
    public double Quantity { get; set; }
    public int MeasureType { get; set; }
}