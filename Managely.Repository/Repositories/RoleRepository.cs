using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Repository.Shared;
using Microsoft.EntityFrameworkCore;

namespace Managely.Repository.Repositories
{
    public class RoleRepository: GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context): base(context) { }
        
        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetByValue(RoleName role)
        {
            return await _context.Roles.Where(r => r.Name.Equals(role)).FirstOrDefaultAsync();
        }
        
        public async Task<List<RolePermission>> GetRolePermissions(RoleName role) => 
            await _context.RolePermissions
                .Include("Role")
                .Include("Permission")
                .Where(p => p.Role.Name.Equals(role)).ToListAsync();
    }
}
