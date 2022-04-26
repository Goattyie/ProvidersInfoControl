using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProvidersInfoControl.Database.Configuration;
using ProvidersInfoControl.Domain.Models;

namespace ProvidersInfoControl.Database;

public class PicDbContext : DbContext
{
    public PicDbContext(DbContextOptions<PicDbContext> options) : base(options) { }
    
    public DbSet<OwnType> OwnTypes { get; set; }
    public DbSet<AbonentType> AbonentTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OwnTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AbonentTypeConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}