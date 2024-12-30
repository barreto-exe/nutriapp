using nutriapp.core.Entities;
using nutriapp.infrastructure.Data;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly NutriAppContext context;
    private readonly IRepository<Food> foodRepository;
    private readonly IRepository<FoodAtFridge> foodAtFridgeRepository;
    private readonly IRepository<FoodConsumed> foodConsumedRepository;
    private readonly IRepository<FoodMenuMeasure> foodMenuMeasureRepository;
    private readonly IRepository<FoodType> foodTypeRepository;
    private readonly IRepository<FoodTypeGroup> foodTypeGroupRepository;
    private readonly IRepository<GroupUnitMenu> groupUnitMenuRepository;
    private readonly IRepository<MealType> mealTypeRepository;
    private readonly IRepository<MeasureType> measureTypeRepository;
    private readonly IRepository<UnitMenu> unitMenuRepository;
    private readonly IRepository<User> userRepository;
    private readonly IRepository<WaterMeasure> waterMeasureRepository;

    public UnitOfWork(NutriAppContext context)
    {
        this.context = context;
    }

    public IRepository<Food> FoodRepository => foodRepository ?? new BaseRepository<Food>(context);
    public IRepository<FoodAtFridge> FoodAtFridgeRepository => foodAtFridgeRepository ?? new BaseRepository<FoodAtFridge>(context);
    public IRepository<FoodConsumed> FoodConsumedRepository => foodConsumedRepository ?? new BaseRepository<FoodConsumed>(context);
    public IRepository<FoodMenuMeasure> FoodMenuMeasureRepository => foodMenuMeasureRepository ?? new BaseRepository<FoodMenuMeasure>(context);
    public IRepository<FoodType> FoodTypeRepository => foodTypeRepository ?? new BaseRepository<FoodType>(context);
    public IRepository<FoodTypeGroup> FoodTypeGroupRepository => foodTypeGroupRepository ?? new BaseRepository<FoodTypeGroup>(context);
    public IRepository<GroupUnitMenu> GroupUnitMenuRepository => groupUnitMenuRepository ?? new BaseRepository<GroupUnitMenu>(context);
    public IRepository<MealType> MealTypeRepository => mealTypeRepository ?? new BaseRepository<MealType>(context);
    public IRepository<MeasureType> MeasureTypeRepository => measureTypeRepository ?? new BaseRepository<MeasureType>(context);
    public IRepository<UnitMenu> UnitMenuRepository => unitMenuRepository ?? new BaseRepository<UnitMenu>(context);
    public IRepository<User> UserRepository => userRepository ?? new BaseRepository<User>(context);
    public IRepository<WaterMeasure> WaterMeasureRepository => waterMeasureRepository ?? new BaseRepository<WaterMeasure>(context);

    public void Dispose()
    {
        context?.Dispose();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}