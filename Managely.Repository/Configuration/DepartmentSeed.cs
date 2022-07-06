using Managely.Domain.Models;

namespace Managely.Repository.Configuration;

public static class DepartmentSeed
{
    public static ICollection<Department> Get()
    {
        return new List<Department>
        {
            new()
            {
                DepartmentId = Guid.NewGuid(),
                Name = DepartmentName.IT,
                Description = "IT",
            },
            new()
            {
                DepartmentId = Guid.NewGuid(),
                Name = DepartmentName.Finance,
                Description = "Finanzas",
            },
            new()
            {
                DepartmentId = Guid.NewGuid(),
                Name = DepartmentName.Marketing,
                Description = "Marketing",
            },
            new()
            {
                DepartmentId = Guid.NewGuid(),
                Name = DepartmentName.Sales,
                Description = "Ventas",
            },
            new()
            {
                DepartmentId = Guid.NewGuid(),
                Name = DepartmentName.HumanResources,
                Description = "Recursos Humanos",
            },
            new()
            {
                DepartmentId = Guid.NewGuid(),
                Name = DepartmentName.CustomerService,
                Description = "Servicio al Cliente",
            },
            new()
            {
                DepartmentId = Guid.NewGuid(),
                Name = DepartmentName.Board,
                Description = "Comité de Gobernación",
            },
        };
    }
}