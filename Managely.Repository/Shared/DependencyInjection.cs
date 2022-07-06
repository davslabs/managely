using Managely.Domain.Interfaces;
using Managely.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Managely.Repository.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<ITimeOffRepository, TimeOffRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IJobPositionRepository, JobPositionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    "Data Source=localhost; Initial Catalog = Managely; User Id=sa; Password=<My-secret-pw@?>"));

            return services;
        }
    }
}
