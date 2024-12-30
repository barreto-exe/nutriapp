using nutriapp.core.Entities;

namespace nutriapp.business.Interfaces;

public interface IWaterMeasureService
{
    Task CreateAsync(WaterMeasure waterMeasure);
    Task<WaterMeasure> GetWaterMeasureByUserIdAsync(int userId);
}