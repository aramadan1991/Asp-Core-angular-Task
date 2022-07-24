using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;


namespace Persistence
{
    public static class PersistenceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(
    configuration.GetConnectionString("SqlServerConnection"),
    b => b.MigrationsAssembly(typeof(EmployeeContext).Assembly.FullName)));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}