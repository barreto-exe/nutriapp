using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.WaterMeasures;

public class CreateWaterMeasureCommand : IRequest<CreateWaterMeasureResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public double Quantity { get; set; }
    public int MeasureType { get; set; }
}
