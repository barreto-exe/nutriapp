using nutriapp.business.Interfaces;
using nutriapp.infrastructure.Interfaces;
using WaterConsumedEntity = nutriapp.core.Entities.WaterConsumed;

namespace nutriapp.business.Services;

public class WaterConsumedService : IWaterConsumedService
{
    private readonly IUnitOfWork unitOfWork;

    public WaterConsumedService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task CreateWaterConsumedAsync(WaterConsumedEntity waterConsumed)
    {
        await unitOfWork.WaterConsumedRepository.AddAsync(waterConsumed);
        await unitOfWork.SaveChangesAsync();
    }

    public IEnumerable<WaterConsumedEntity> GetWaterConsumedToday(int userId)
    {
        var waterConsumed = unitOfWork.WaterConsumedRepository
            .GetAllIncluding("UserNavigation", "MeasureTypeNavigation")
            .Where(x => x.User == userId && x.CreatedDate.Date == DateTime.Today.Date)
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        return waterConsumed;
    }
}