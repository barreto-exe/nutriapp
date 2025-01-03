﻿using AutoMapper;
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
using FoodMenuMeasureEntity = nutriapp.core.Entities.FoodMenuMeasure;
using FoodAtFridgeEntity = nutriapp.core.Entities.FoodAtFridge;
using nutriapp.business.FoodMenuMeasure;
using nutriapp.business.FoodAtFridge;
using nutriapp.business.Auth;

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
        CreateMap<CreateFoodMenuMeasureCommand, FoodMenuMeasureEntity>();
        CreateMap<CreateFoodAtFridgeCommand, FoodAtFridgeEntity>();
        CreateMap<RegisterCommand, User>();

        //Entities to Models
        CreateMap<FoodTypeGroup, models.FoodTypeGroup>();
        CreateMap<GroupUnitMenuEntity, models.FoodTypeGroupGoalDetail>()
            .ForMember(dest => dest.MealType, opt => opt.MapFrom(src => src.MealTypeNavigation))
            .ForMember(dest => dest.FoodTypeGroup, opt => opt.MapFrom(src => src.FoodTypeGroupNavigation));
        CreateMap<MealType, models.MealType>()
            .ForMember(dest => dest.FoodGroupGoals, opt => opt.MapFrom(src => src.GroupUnitMenus));
        CreateMap<GroupUnitMenuEntity, models.FoodTypeGroupGoal>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FoodTypeGroupNavigation.Name));
        CreateMap<WaterMeasure, models.WaterMeasure>();
        CreateMap<UnitMenuEntity, models.FoodTypeGoal>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FoodTypeNavigation.Name));
        CreateMap<core.Entities.FoodMenuMeasure, models.FoodGoal>()
            .ForMember(dest => dest.Food, opt => opt.MapFrom(src => src.FoodNavigation.Name))
            .ForMember(dest => dest.MeasureType, opt => opt.MapFrom(src => src.MeasureTypeNavigation.Abbreviation))
            .ForMember<string>(dest => dest.CookedMeasureType, opt => opt.MapFrom(src => src.CookedMeasureTypeNavigation.Abbreviation))
            .ForMember<string>(dest => dest.PracticalMeasureType, opt => opt.MapFrom(src => src.PracticalMeasureTypeNavigation.Abbreviation));
    }
}