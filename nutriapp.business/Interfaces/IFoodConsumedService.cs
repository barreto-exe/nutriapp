using nutriapp.models;

namespace nutriapp.business.Interfaces;

public interface IFoodConsumedService
{
    Task<List<FoodConsumed>> GetFoodConsumedAsync(int userId, DateTime date, CancellationToken cancellationToken);
}