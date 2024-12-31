using nutriapp.business.Base;

namespace nutriapp.business.WaterConsumed;

public class GetWaterConsumedResponse : BaseCommandResponse
{
    public double MililitersLeft { get; set; }
    public double MililitersConsumedToday { get; set; }
}