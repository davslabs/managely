using AutoMapper;
using Managely.Domain.Models;
using Managely.Models.ViewModel;

namespace Managely.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeProfileViewModel>()
                .ForMember(
                    dest => dest.DisplayName,
                    opt => opt.MapFrom(src => $"{src.DisplayName}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Phone,
                    opt => opt.MapFrom(src => $"{src.Phone}")
                )
                .ForMember(
                    dest => dest.Location,
                    opt => opt.MapFrom(src => $"{src.Location}")
                )
                .ForMember(
                    dest => dest.Role,
                    opt => opt.MapFrom(src => $"{src.Role.Name}")
                );
        }
    }
}
