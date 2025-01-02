using nutriapp.core.Entities;
using nutriapp.models;
using static nutriapp.business.Services.FoodAnalyticsService;

namespace nutriapp.business.Interfaces;

public interface IFoodAnalyticsService
{
    Task<List<FoodUnitEquivalent>> GetFoodSumEquivalentAsync(FoodDataSource repositoryType, int userId, DateTime date, CancellationToken cancellationToken);
}