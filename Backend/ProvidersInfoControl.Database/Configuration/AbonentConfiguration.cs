using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Database.Configuration;

public class AbonentConfiguration : IEntityTypeConfiguration<Abonent>
{
    public void Configure(EntityTypeBuilder<Abonent> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Address).IsUnique();
        builder.Property(x => x.Address).IsRequired();
    }
}