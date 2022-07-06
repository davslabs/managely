
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Repository.Shared;

namespace Managely.Repository.Repositories
{
    public class PermissionRepository: GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context) : base(context) { }

    }
}
