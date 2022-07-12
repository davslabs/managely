using AutoMapper;
using Managely.Domain.Models;
using Managely.Models.ViewModel;

namespace Managely.Profiles;

public class CollaboratorProfile : Profile
{
    public CollaboratorProfile()
    {
        CreateMap<Employee, CollaboratorViewModel>()
            .ForMember(dest => dest.EmployeeId,
                opt => opt.MapFrom(src => $"{src.EmployeeId}"))
            .ForMember(dest => dest.DisplayName,
                opt => opt.MapFrom(src => $"{src.DisplayName}"))
            .ForMember(dest => dest.AvatarUrl,
                opt => opt.MapFrom(src => $"{src.AvatarUrl}"))
            .ForMember(dest => dest.JobPosition,
                opt => opt.MapFrom(src => $"{src.JobPosition.Description}"))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => $"{src.Department.Description}"));
    }
}