using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Repository.Shared;
using Microsoft.EntityFrameworkCore;

namespace Managely.Repository.Repositories
{
    public class EmployeeRepository: GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context): base(context) { }
        
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees                
                .Include("Role")
                .Include("EmployeeTimeOffs")
                .Include("JobPosition")
                .Include("Department")
                .ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesRelationships()
        {
            return await _context.Employees
                .Include("JobPosition")
                .Include("Department")
                .Include("ReportsTo")
                .ToListAsync();
        }

        public async Task<List<Employee>> GetRelatedEmployees(Guid employeeId) => 
            await _context.Employees
                .Where(e => e!.ReportsToId.Equals(employeeId))                
                .Include("JobPosition")
                .Include("Department")
                .Include("ReportsTo")
                .ToListAsync();

        public async Task<Employee?> GetEmployeeById(Guid employeeId) =>
            await _context.Employees
                .Include("Role")
                .Include("EmployeeTimeOffs")
                .Include("JobPosition")
                .Include("Department")
                .Include("ReportsTo")
                .FirstOrDefaultAsync(e => e!.EmployeeId.Equals(employeeId));

        public async Task<Employee?> GetEmployeeByEmail(string email) =>
            await _context.Employees
                .Include("Role")
                .FirstOrDefaultAsync(e => e!.Email.ToLower().Equals(email.ToLower().Trim()));
        
        public async Task<ICollection<TimeOff>> GetEmployeeTimeOff(Guid employeeId)
        {
            //Get all time offs from employee
            var employeeTimeOffs =
                await _context.EmployeeTimeOffs
                    .Include("Employee")
                    .Include("TimeOff")
                    .Where(et => et.EmployeeId.Equals(employeeId))
                    .ToListAsync();
            
            return employeeTimeOffs.Select(et => et.TimeOff).ToList();
        }

        public async Task<List<Employee>> GetEmployeesByDepartment(Guid departmentId)
        {
            List<Employee> employeesByDepartment =
                await _context.Employees
                    .Include("Role")
                    .Include("EmployeeTimeOffs")
                    .Include("JobPosition")
                    .Include("Department")
                    .Where(e => e!.DepartmentId.Equals(departmentId))
                    .ToListAsync();

            return employeesByDepartment;
        }

    }
}
