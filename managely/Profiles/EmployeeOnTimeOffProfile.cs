using AutoMapper;
using Managely.Domain.Models;
using Managely.Models.DTO;

namespace Managely.Profiles;

public class EmployeeOnTimeOffProfile : Profile
{
    public EmployeeOnTimeOffProfile()
    {
        CreateMap<EmployeeTimeOff, EmployeeOnTimeOffDto>()
            .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.Employee.AvatarUrl))
            .ForMember(dest => dest.FromDate, opt => opt.MapFrom(src => src.TimeOff.FromDate))
            .ForMember(dest => dest.ThruDate, opt => opt.MapFrom(src => src.TimeOff.ThruDate));
    }
}