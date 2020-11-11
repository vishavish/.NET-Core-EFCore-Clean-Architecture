using DeviceAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceAssignment.Infrastracture.Persistence.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.Property(d => d.Name)
                .IsRequired();

            builder.Property(d => d.Description)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
