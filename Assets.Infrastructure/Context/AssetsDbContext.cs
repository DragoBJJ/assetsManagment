using Assets.Domain;
using Assets.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assets.Infrastructure;
public class AssetsDbContext(DbContextOptions<AssetsDbContext> options) : IdentityDbContext<User>(options)

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
