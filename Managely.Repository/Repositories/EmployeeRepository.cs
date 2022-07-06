using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Repository.Shared;
using Microsoft.EntityFrameworkCore;

namespace Managely.Repository.Repositories
{
    public class EmployeeRepository: GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context): base(context) { }
        
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include(e => e!.Role).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetRelatedEmployees(Guid employeeId) => 
            await _context.Employees
                .Where(e => e!.ReportsToId.Equals(employeeId)).Include(e => e!.Role)
                .ToListAsync();

        public async Task<Employee?> GetEmployeeById(Guid employeeId) =>
            await _context.Employees.Include(e => e!.Role)
                .FirstOrDefaultAsync(e => e!.EmployeeId.Equals(employeeId));

        public async Task<List<TimeOff>> GetEmployeeTimeOff(Guid employeeId)
        {
            Employee? employee = await _context.Employees.Include(e => e.EmployeeTimeOffs)
                .FirstOrDefaultAsync(e => e!.EmployeeId.Equals(employeeId));
            
            List<TimeOff> employeeTimeOffs = new List<TimeOff>();
            foreach (EmployeeTimeOff employeeTimeOff in employee.EmployeeTimeOffs)
            {
                employeeTimeOffs.Add((await _context.TimeOffs.FirstOrDefaultAsync(t => t.TimeOffId.Equals(employeeTimeOff.TimeOffId)))!);
            }

            return employeeTimeOffs;
        }

    }
}
