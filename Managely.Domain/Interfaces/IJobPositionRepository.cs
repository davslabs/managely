using Managely.Domain.Models;

namespace Managely.Domain.Interfaces;

public interface IJobPositionRepository: IGenericRepository<JobPosition>
{
    public Task<JobPosition?> GetByValue(JobPositionName jobPosition);
}