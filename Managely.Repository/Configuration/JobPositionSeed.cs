using Managely.Domain.Models;

namespace Managely.Repository.Configuration;

public class JobPositionSeed
{
    public static ICollection<JobPosition> Get()
    {
        return new List<JobPosition>()
        {
            new()
            {
                JobPositionId = Guid.NewGuid(),
                Name = JobPositionName.Head,
                Description = "Lider",
            },
            new()
            {
                JobPositionId = Guid.NewGuid(),
                Name = JobPositionName.Manager,
                Description = "Gerente",
            },
            new()
            {
                JobPositionId = Guid.NewGuid(),
                Name = JobPositionName.Staff,
                Description = "Staff",
            },
            new()
            {
                JobPositionId = Guid.NewGuid(),
                Name = JobPositionName.CEO,
                Description = "CEO",
            },
        };
    }
}