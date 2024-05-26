using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Assets.Application.User;
using static Assets.Application.User.IUserContext;

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

            services.AddScoped<IUserContext, UserContext>();
            services.AddHttpContextAccessor();

    }
        }
}
