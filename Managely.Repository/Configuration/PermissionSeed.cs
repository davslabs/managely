using Managely.Domain.Models;

namespace Managely.Repository.Configuration
{
    public static class PermissionSeed
    {
        public static ICollection<Permission> Get()
        {
            return new List<Permission>
            {
                new()
                {
                    PermissionId = Guid.NewGuid(),
                    Name = PermissionName.Create
                },
                new()
                {
                    PermissionId = Guid.NewGuid(),
                    Name = PermissionName.Update,
                },
                new()
                {
                    PermissionId = Guid.NewGuid(),
                    Name = PermissionName.Read
                },
                new()
                {
                    PermissionId = Guid.NewGuid(),
                    Name = PermissionName.Delete
                }
            };
        }
    }
}
