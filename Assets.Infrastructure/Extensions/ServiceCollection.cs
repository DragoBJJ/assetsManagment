
using Assets.Domain.Repositories;
using Assets.Infrastructure.Repositories;
using Assets.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assets.Infrastructure.Extensions
{
    public static class ServiceCollection
    {
         public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)

        {
            var connectionString = configuration.GetConnectionString("AssetDB");
            services.AddDbContext<AssetsDbContext>(options =>
            options.UseSqlServer(connectionString).EnableSensitiveDataLogging()
            .EnableSensitiveDataLogging()
            ); ;




            services.AddScoped<IAssetSeeders, AssetSeeders>();
            services.AddScoped<IAssetRepository, AssetRepository>();
        }
    }
}
