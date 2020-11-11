using DeviceAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceAssignment.Infrastracture.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired();

            builder.Property(e => e.Position)
                .IsRequired();

            builder.Property(e => e.MobileNo)
                .IsRequired();

            builder.Property(e => e.EmploymentDate)
                .IsRequired();
        }
    }
}
