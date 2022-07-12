using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Repository.Shared;
using Microsoft.EntityFrameworkCore;

namespace Managely.Repository.Repositories;

public class DepartmentRepository: GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context) { }
    
    public async Task<List<Department>> GetAllDepartments()
    {
        return await _context.Departments.ToListAsync();
    }
    public async Task<Department?> GetByValue(DepartmentName department)
    {
        return await _context.Departments.Where(d => d.Name.Equals(department)).FirstOrDefaultAsync();
    }
}
