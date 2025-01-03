using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.WaterMeasures;

public class GetWaterMeasureCommand : IRequest<GetWaterMeasureResponse>
{
    [JsonIgnore]
    public int User { get; set; }
}
