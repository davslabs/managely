using Managely.Domain.Models;

namespace Managely.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Employee>> GetRelatedEmployees(Guid employeeId);
        Task<Employee?> GetEmployeeById(Guid employeeId);
        Task<ICollection<TimeOff>> GetEmployeeTimeOff(Guid employeeId);
        Task<List<Employee>> GetEmployeesByDepartment(Guid departmentId);
    }
}
