using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Assets.Application.Users;
using static Assets.Application.Users.IUserContext;

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
