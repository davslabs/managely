using Managely.Domain.Models;

namespace Managely.Domain.Interfaces;

public interface IJobPositionRepository: IGenericRepository<JobPosition>
{
    Task<List<JobPosition>> GetAllJobPositions();
    Task<JobPosition?> GetByValue(JobPositionName jobPosition);
}