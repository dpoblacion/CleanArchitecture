using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations;

internal class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.Ignore(e => e.DomainEvents);

        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
