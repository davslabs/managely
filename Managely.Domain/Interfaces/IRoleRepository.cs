using Managely.Domain.Models;

namespace Managely.Domain.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<List<Role>> GetAllRoles();
        Task<Role?> GetByValue(RoleName role);
        Task<List<RolePermission>> GetRolePermissions(RoleName role);
    }
}
