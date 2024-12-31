using AutoMapper;
using nutriapp.business.GroupUnitMenu;
using nutriapp.business.MealTypes;
using nutriapp.business.Users;
using nutriapp.business.WaterConsumed;
using nutriapp.business.WaterMeasures;
using nutriapp.core.Entities;
using WaterConsumedEntity = nutriapp.core.Entities.WaterConsumed;
using GroupUnitMenuEntity = nutriapp.core.Entities.GroupUnitMenu;

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
        CreateMap<WaterMeasure, models.WaterMeasure>();
        CreateMap<MealType, models.MealType>();
    }
}