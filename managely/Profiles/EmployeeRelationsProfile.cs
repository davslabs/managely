using AutoMapper;
using Managely.Domain.Models;
using Managely.Models.ViewModel;

namespace Managely.Profiles;

public class EmployeeRelationsProfile : Profile
{
    public EmployeeRelationsProfile()
    {
        CreateMap<Employee, EmployeeRelationsViewModel>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
            .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl))
            .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.JobPosition, opt => opt.MapFrom(src => src.JobPosition.Description))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Description))
            .ForMember(
                dest => dest.ReportTo,
                opt =>
                {
                    opt.MapFrom(src => $"{src.ReportsToId}");
                    opt.PreCondition(src => src.ReportsToId != null);
                });
    }
}