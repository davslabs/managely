using Managely.Domain.Models;

namespace Managely.Domain.Interfaces;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    public Task<Department?> GetByValue(DepartmentName department);
}