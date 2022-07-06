using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Repository.Shared;

namespace Managely.Repository.Repositories
{
    public class TimeOffRepository: GenericRepository<TimeOff>, ITimeOffRepository
    {
        public TimeOffRepository(ApplicationDbContext context): base(context) { }
    }
}
