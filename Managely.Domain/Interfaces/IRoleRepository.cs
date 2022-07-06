using Managely.Domain.Models;

namespace Managely.Domain.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public Task<Role?> GetByValue(RoleName role);
    }
}
