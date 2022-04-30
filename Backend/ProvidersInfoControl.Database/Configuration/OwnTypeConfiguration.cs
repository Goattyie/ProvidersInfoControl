using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Database.Configuration;

public class OwnTypeConfiguration : IEntityTypeConfiguration<OwnType>
{
    public void Configure(EntityTypeBuilder<OwnType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20);
        builder.HasMany(x => x.Firms)
            .WithOne(m => m.OwnType)
            .HasForeignKey(k => k.OwnTypeId);
    }
}