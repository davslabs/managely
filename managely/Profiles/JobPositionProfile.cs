using AutoMapper;
using Managely.Domain.Models;
using Managely.Models.ViewModel;

namespace Managely.Profiles;

public class JobPositionProfile : Profile
{
    public JobPositionProfile()
    {
        CreateMap<JobPosition, JobPositionViewModel>()
            .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.JobPositionName,
                opt => opt.MapFrom(src => src.Name));
    }
    
}