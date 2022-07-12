using Managely.Domain.Models;

namespace Managely.Domain.Interfaces;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    Task<List<Department>> GetAllDepartments();
    public Task<Department?> GetByValue(DepartmentName department);
}