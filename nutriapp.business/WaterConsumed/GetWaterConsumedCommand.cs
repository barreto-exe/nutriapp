using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.WaterConsumed;

public class GetWaterConsumedCommand : IRequest<GetWaterConsumedResponse>
{
    [JsonIgnore]
    public int User { get; set; }
}