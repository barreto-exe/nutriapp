using AutoMapper;
using nutriapp.business.FoodsConsumed;
using nutriapp.business.FoodTypeGroupGoal;
using nutriapp.business.MealTypes;
using nutriapp.business.FoodTypeGoal;
using nutriapp.business.Users;
using nutriapp.business.WaterConsumed;
using nutriapp.business.WaterMeasures;
using nutriapp.core.Entities;
using GroupUnitMenuEntity = nutriapp.core.Entities.GroupUnitMenu;
using UnitMenuEntity = nutriapp.core.Entities.UnitMenu;
using WaterConsumedEntity = nutriapp.core.Entities.WaterConsumed;

namespace nutriapp.business.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //Commands to Entities
        CreateMap<CreateUserCommand, User>();
        CreateMap<CreateWaterMeasureCommand, WaterMeasure>();
        CreateMap<CreateWaterConsumedCommand, WaterConsumedEntity>();
        CreateMap<CreateMealTypeCommand, MealType>();
        CreateMap<CreateFoodTypeGroupGoalCommand, GroupUnitMenuEntity>();
        CreateMap<CreateFoodTypeGoalCommand, UnitMenuEntity>();
        CreateMap<CreateFoodConsumedCommand, FoodConsumed>();

        //Entities to Models
        CreateMap<FoodTypeGroup, models.FoodTypeGroup>();
        CreateMap<GroupUnitMenuEntity, models.GroupUnitMenu>()
            .ForMember(dest => dest.MealType, opt => opt.MapFrom(src => src.MealTypeNavigation))
            .ForMember(dest => dest.FoodTypeGroup, opt => opt.MapFrom(src => src.FoodTypeGroupNavigation));
        CreateMap<MealType, models.MealType>()
            .ForMember(dest => dest.FoodTypeGroupMenu, opt => opt.MapFrom(src => src.GroupUnitMenus));
        CreateMap<GroupUnitMenuEntity, models.FoodTypeGroupQuantity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FoodTypeGroupNavigation.Name));
        CreateMap<WaterMeasure, models.WaterMeasure>();
        CreateMap<UnitMenuEntity, models.FoodTypeQuantity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FoodTypeNavigation.Name));
    }
}