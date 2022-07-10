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
                .ForMember(dest => dest.EmployeeId,
                    opt => opt.MapFrom(src => $"{src.EmployeeId}")
                )
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => $"{src.LastName}")
                )
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
                    dest => dest.Department,
                    opt => opt.MapFrom(src => $"{src.Department.Description}")
                )
                .ForMember(
                    dest => dest.JobPosition,
                    opt => opt.MapFrom(src => $"{src.JobPosition.Description}")
                )
                .ForMember(
                    dest => dest.Role,
                    opt => opt.MapFrom(src => $"{src.Role.Description}")
                )
                .ForMember(
                    dest => dest.ReportsTo,
                    opt =>
                    {
                        opt.MapFrom(src => $"{src.ReportsTo.DisplayName}");
                        opt.PreCondition(src => src.ReportsToId != null);
                });
        }
    }
}
