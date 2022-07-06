using Managely.Domain.Interfaces;

namespace Managely.Repository.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IEmployeeRepository Employees { get; }
        public IRoleRepository Roles { get; }
        public IPermissionRepository Permissions { get; set;}
        public ITimeOffRepository TimeOff { get; set; }

        public UnitOfWork(ApplicationDbContext appDbContext,
            IEmployeeRepository employeeRepository,
            IRoleRepository roleRepository,
            IPermissionRepository permissionRepository,
            ITimeOffRepository timeOffRepository)
        {
            this._context = appDbContext;

            this.Employees = employeeRepository;
            this.Roles = roleRepository;
            this.Permissions = permissionRepository;
            this.TimeOff = timeOffRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
