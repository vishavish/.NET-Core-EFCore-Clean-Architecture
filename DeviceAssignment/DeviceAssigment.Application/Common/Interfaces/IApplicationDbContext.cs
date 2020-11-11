using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeviceAssigment.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<DeviceAssignment.Domain.Entities.Employee> Employees { get; set; }
        DbSet<DeviceAssignment.Domain.Entities.Device> Devices { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}