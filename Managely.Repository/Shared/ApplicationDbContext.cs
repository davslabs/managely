using Managely.Domain.Models;
using Managely.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Managely.Repository.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<Employee?> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<TimeOff> TimeOffs { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<EmployeeTimeOff> EmployeeTimeOffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ICollection<Role> roles = RoleSeed.Get();
            ICollection<Permission> permissions = PermissionSeed.Get();

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<Permission>().HasData(permissions);
            
            //Seteo para rol Admin y Manager, todos los permisos
            List<RolePermission> rolePermissions = new List<RolePermission>();
            foreach (var permission in permissions)
            {
                rolePermissions.Add(new RolePermission
                {
                    RolePermissionId = Guid.NewGuid(),
                    RoleId = roles.FirstOrDefault(r => r.Name.Equals(RoleName.Admin))!.RoleId,
                    PermissionId = permission.PermissionId
                });
                rolePermissions.Add(new RolePermission
                {
                    RolePermissionId = Guid.NewGuid(),
                    RoleId = roles.FirstOrDefault(r => r.Name.Equals(RoleName.Manager))!.RoleId,
                    PermissionId = permission.PermissionId
                });
            }
            
            //Seteo para rol solo lectura para Staff
            rolePermissions.Add(new RolePermission
            {
                RolePermissionId = Guid.NewGuid(),
                RoleId = roles.FirstOrDefault(r => r.Name.Equals(RoleName.Staff))!.RoleId,
                PermissionId = permissions.FirstOrDefault(p => p.Name.Equals(PermissionName.Read))!.PermissionId
            });

            modelBuilder.Entity<RolePermission>().HasData(rolePermissions);
        }
    }
}
