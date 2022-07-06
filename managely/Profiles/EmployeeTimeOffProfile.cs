using AutoMapper;
using Managely.Domain.Models;
using Managely.Models.ViewModel;

namespace Managely.Profiles
{
    public class EmployeeTimeOffProfile: Profile
    {
        public EmployeeTimeOffProfile()
        {
            CreateMap<TimeOff, EmployeeTimeOffViewModel>()
                .ForMember(
                    dest => dest.Reason,
                    opt => opt.MapFrom(src => $"{src.Reason}")
                )
                .ForMember(
                    dest => dest.FromDate,
                    opt => opt.MapFrom(src => $"{src.FromDate}")
                )
                .ForMember(
                    dest => dest.ThruDate,
                    opt => opt.MapFrom(src => $"{src.ThruDate}")
                );
        }
    }
}

