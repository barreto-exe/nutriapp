using nutriapp.business.Base;

namespace nutriapp.business.WaterConsumed;

public class GetWaterConsumedResponse : BaseCommandResponse
{
    public double LitersLeft { get; set; }
    public double LitersConsumedToday { get; set; }
}