using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Database.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Login)
            .IsUnique();
        builder.Property(x => x.Login)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(150);
    }
}