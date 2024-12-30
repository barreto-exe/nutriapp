using nutriapp.core.Entities;

namespace nutriapp.infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Food> FoodRepository { get; }
    IRepository<FoodAtFridge> FoodAtFridgeRepository { get; }
    IRepository<FoodConsumed> FoodConsumedRepository { get; }
    IRepository<FoodMenuMeasure> FoodMenuMeasureRepository { get; }
    IRepository<FoodType> FoodTypeRepository { get; }
    IRepository<FoodTypeGroup> FoodTypeGroupRepository { get; }
    IRepository<GroupUnitMenu> GroupUnitMenuRepository { get; }
    IRepository<MealType> MealTypeRepository { get; }
    IRepository<MeasureType> MeasureTypeRepository { get; }
    IRepository<UnitMenu> UnitMenuRepository { get; }
    IRepository<User> UserRepository { get; }
    IRepository<WaterMeasure> WaterMeasureRepository { get; }
    IRepository<WaterConsumed> WaterConsumedRepository { get; }

    void SaveChanges();
    Task SaveChangesAsync();
}