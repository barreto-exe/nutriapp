using AutoMapper;
using nutriapp.business.Users;
using nutriapp.core.Entities;

namespace nutriapp.business.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserCommand, User>();
           
    }
}