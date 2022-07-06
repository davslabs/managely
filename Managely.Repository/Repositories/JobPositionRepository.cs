using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Repository.Shared;
using Microsoft.EntityFrameworkCore;

namespace Managely.Repository.Repositories;

public class JobPositionRepository: GenericRepository<JobPosition>, IJobPositionRepository
{
    public JobPositionRepository(ApplicationDbContext context) : base(context) { }

    public async Task<JobPosition?> GetByValue(JobPositionName jobPosition)
    {
        return await _context.JobPositions.FirstOrDefaultAsync(x => x.Name.Equals(jobPosition));
    }
}