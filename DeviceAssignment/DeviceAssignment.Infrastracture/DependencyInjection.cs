using DeviceAssigment.Application.Common.Interfaces;
using DeviceAssigment.Application.Device.Interfaces;
using DeviceAssigment.Application.Employee.Interfaces;
using DeviceAssignment.Infrastracture.Persistence;
using DeviceAssignment.Infrastracture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceAssignment.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
