using AutoMapper;
using Managely.Domain.Models;
using Managely.Models.ViewModel;

namespace Managely.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleViewModel>()
            .ForMember(dest => dest.Description, opt 
                => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.RoleName, opt 
                => opt.MapFrom(src => src.Name));
    }
}