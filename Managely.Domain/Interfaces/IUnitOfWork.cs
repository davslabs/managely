using System;

namespace Managely.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IRoleRepository Roles { get; }
        IPermissionRepository Permissions { get; set; }
        ITimeOffRepository TimeOff { get; set; }
        int Complete();
    }
}
