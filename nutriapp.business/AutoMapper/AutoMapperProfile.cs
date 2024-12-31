using AutoMapper;
using nutriapp.business.GroupUnitMenu;
using nutriapp.business.MealTypes;
using nutriapp.business.Users;
using nutriapp.business.WaterConsumed;
using nutriapp.business.WaterMeasures;
using nutriapp.core.Entities;
using GroupUnitMenuEntity = nutriapp.core.Entities.GroupUnitMenu;
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
        CreateMap<CreateGroupUnitMenuCommand, GroupUnitMenuEntity>();

        //Entities to Models
        CreateMap<FoodTypeGroup, models.FoodTypeGroup>();
        CreateMap<GroupUnitMenuEntity, models.GroupUnitMenu>()
            .ForMember(dest => dest.MealType, opt => opt.MapFrom(src => src.MealTypeNavigation))
            .ForMember(dest => dest.FoodTypeGroup, opt => opt.MapFrom(src => src.FoodTypeGroupNavigation));
        CreateMap<MealType, models.MealType>()
            .ForMember(dest => dest.Quantities, opt => opt.MapFrom(src => src.GroupUnitMenus));
        CreateMap<GroupUnitMenuEntity, models.FoodTypeGroupQuantity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FoodTypeGroupNavigation.Name));
        CreateMap<WaterMeasure, models.WaterMeasure>();
    }
}