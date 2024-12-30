using nutriapp.business.Base;
using nutriapp.business.Interfaces;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.Services;

public class WaterMeasureService : IWaterMeasureService
{
    private readonly IUnitOfWork unitOfWork;

    public WaterMeasureService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(WaterMeasure waterMeasure)
    {
        waterMeasure.UpdatedDate = DateTime.Now;

        await unitOfWork.WaterMeasureRepository.AddAsync(waterMeasure);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task<WaterMeasure> GetWaterMeasureByUserIdAsync(int userId)
    {
        var waterMeasure = unitOfWork.WaterMeasureRepository
        .GetAllIncluding(x => x.UserNavigation)
            .Where(x => x.UserNavigation.Id == userId)
            .OrderByDescending(x => x.UpdatedDate)
            .Take(1)
            .FirstOrDefault();

        return waterMeasure;
    }
}