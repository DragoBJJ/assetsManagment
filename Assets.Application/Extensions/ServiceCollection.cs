using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Assets.Application.Extensions
{
    public static class ServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)

        {
            var applicationAssembly = typeof(ServiceCollection).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));
            services.AddAutoMapper(applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();
    }
        }
}
