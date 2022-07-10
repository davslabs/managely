using Managely.Domain.Models;

namespace Managely.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<Employee>> GetAllEmployees();
        Task<List<Employee>> GetAllEmployeesRelationships();
        Task<List<Employee>> GetRelatedEmployees(Guid employeeId);
        Task<Employee?> GetEmployeeById(Guid employeeId);
        Task<Employee?> GetEmployeeByEmail(string email);
        Task<ICollection<TimeOff>> GetEmployeeTimeOff(Guid employeeId);
        Task<List<Employee>> GetEmployeesByDepartment(Guid departmentId);
    }
}
