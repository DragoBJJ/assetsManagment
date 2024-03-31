
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
            services.AddDbContext<AssetsDbContext>(options=> options.UseSqlServer(connectionString));
            services.AddScoped<IAssetSeeders, AssetSeeders>();
        }
    }
}
