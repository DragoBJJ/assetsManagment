using Assets.Domain;
using Microsoft.EntityFrameworkCore;

namespace Assets.Infrastructure;
internal class AssetsDbContext : DbContext

{
  internal DbSet<Asset> Assets { get; set; }
  internal DbSet<Material> Material { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer();
  }
}
