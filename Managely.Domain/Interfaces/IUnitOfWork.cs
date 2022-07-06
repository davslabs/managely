using System;

namespace Managely.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IRoleRepository Roles { get; }
        IPermissionRepository Permissions { get; set; }
        ITimeOffRepository TimeOffs { get; set; }
        IDepartmentRepository Departments { get; set; }
        
        IJobPositionRepository JobPositions { get; set; }
        int Complete();
    }
}
