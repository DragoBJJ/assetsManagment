using Assets.Domain;
using Microsoft.EntityFrameworkCore;

namespace Assets.Infrastructure;
internal class AssetsDbContext(DbContextOptions<AssetsDbContext> options) : DbContext(options)

{
    internal DbSet<Asset> Assets { get; set; }
     internal DbSet<Material> Materials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Asset>().OwnsOne(r => r.Address);
        modelBuilder.Entity<Asset>().HasMany(r => r.Materials).WithOne().HasForeignKey(m=> m.AssetId);
    }
}
