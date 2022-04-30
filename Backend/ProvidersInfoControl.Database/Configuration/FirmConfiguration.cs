using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Database.Configuration;

public class FirmConfiguration : IEntityTypeConfiguration<Firm>
{
    public void Configure(EntityTypeBuilder<Firm> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(40);
        builder.Property(x => x.Telephone).HasMaxLength(15);
        builder.Property(x => x.Address).HasMaxLength(30);
    }
}