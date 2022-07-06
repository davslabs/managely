using Managely.Domain.Models;

namespace Managely.Repository.Configuration
{
    public static class RoleSeed
    {
        public static ICollection<Role> Get()
        {
            return new List<Role>()
            {
                new()
                {
                    RoleId = Guid.NewGuid(),
                    Description = "Admin",
                    Name = RoleName.Admin
                },
                new()
                {
                    RoleId = Guid.NewGuid(),
                    Description = "Manager",
                    Name = RoleName.Manager,
                },
                new()
                {
                    RoleId = Guid.NewGuid(),
                    Description = "Staff",
                    Name = RoleName.Staff
                }
            };
        }
    }
}
