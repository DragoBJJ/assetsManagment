using Microsoft.Extensions.DependencyInjection;
using Assets.Application.Assets;

namespace Assets.Application.Extensions
{
    public static class ServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)

        {
            services.AddScoped<IAssetsService, AssetsService>();
            services.AddAutoMapper(typeof(ServiceCollection).Assembly);
    }
        }
}
