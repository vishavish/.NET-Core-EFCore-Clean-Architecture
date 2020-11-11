using DeviceAssigment.Application.Common.Interfaces;
using DeviceAssignment.Domain.Common;
using DeviceAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceAssignment.Infrastracture.Persistence
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTime _dateTIme;

        public AppDbContext(DbContextOptions options, IDateTime dateTime)
            : base(options)
        {
            _dateTIme = dateTime;
        }

        public DbSet<Employee> Employees { get ; set; }
        public DbSet<Device> Devices { get ; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTIme.Now;
                        entry.Entity.CreatedBy = "1";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTIme.Now;
                        entry.Entity.LastModifiedBy = "1";
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
