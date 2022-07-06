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
                    Description = "Crear",
                    Name = PermissionName.Create
                },
                new()
                {
                    PermissionId = Guid.NewGuid(),
                    Description = "Editar",
                    Name = PermissionName.Update,
                },
                new()
                {
                    PermissionId = Guid.NewGuid(),
                    Description = "Leer",
                    Name = PermissionName.Read
                },
                new()
                {
                    PermissionId = Guid.NewGuid(),
                    Description = "Eliminar",
                    Name = PermissionName.Delete
                }
            };
        }
    }
}
