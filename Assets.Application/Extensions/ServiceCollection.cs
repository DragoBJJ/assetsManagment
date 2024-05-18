using Microsoft.Extensions.DependencyInjection;
using Assets.Application.Assets;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Assets.Application.Extensions
{
    public static class ServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)

        {
            var applicationAssembly = typeof(ServiceCollection).Assembly;

            services.AddScoped<IAssetsService, AssetsService>();

            services.AddAutoMapper(applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();
    }
        }
}
