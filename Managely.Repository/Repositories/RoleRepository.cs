using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Repository.Shared;
using Microsoft.EntityFrameworkCore;

namespace Managely.Repository.Repositories
{
    public class RoleRepository: GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context): base(context) { }

        public async Task<Role?> GetByValue(RoleName role)
        {
            return await _context.Roles.Where(r => r.Name.Equals(role)).FirstOrDefaultAsync();
        }
    }
}
