using AutoMapper;
using nutriapp.business.Users;
using nutriapp.business.WaterMeasures;
using nutriapp.core.Entities;

namespace nutriapp.business.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<CreateWaterMeasureCommand, WaterMeasure>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserId));

        CreateMap<WaterMeasure, GetWaterMeasureResponse>();
    }
}