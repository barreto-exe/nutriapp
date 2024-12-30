using AutoMapper;
using nutriapp.business.Users;
using nutriapp.business.WaterConsumed;
using nutriapp.business.WaterMeasures;
using nutriapp.core.Entities;
using WaterConsumedEntity = nutriapp.core.Entities.WaterConsumed;

namespace nutriapp.business.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<CreateWaterMeasureCommand, WaterMeasure>();
        CreateMap<CreateWaterConsumedCommand, WaterConsumedEntity>();

        CreateMap<WaterMeasure, GetWaterMeasureResponse>();
    }
}