using WaterConsumedEntity = nutriapp.core.Entities.WaterConsumed;

namespace nutriapp.business.Interfaces;

public interface IWaterConsumedService
{
    IEnumerable<WaterConsumedEntity> GetWaterConsumedToday(int userId);
    Task CreateWaterConsumedAsync(WaterConsumedEntity waterConsumed);
}