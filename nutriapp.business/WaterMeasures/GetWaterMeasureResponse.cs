using nutriapp.business.Base;
using nutriapp.models;

namespace nutriapp.business.WaterMeasures;

public class GetWaterMeasureResponse : BaseCommandResponse
{
    public WaterMeasure? WaterMeasure { get; set; }
}