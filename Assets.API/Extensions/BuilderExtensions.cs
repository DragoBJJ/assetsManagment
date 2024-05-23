using Assets.API.Middlewares;
using Assets.Domain.Entities;
using Assets.Infrastructure;
using Microsoft.OpenApi.Models;

namespace Assets.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddPresentation(this IServiceCollection services)
        {

            services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AssetsDbContext>();

            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<TotalExecutedTimeMiddleware>();

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme, Id =  "bearerAuth"
                },
            },
            []
        }
    });
            });
            services.AddEndpointsApiExplorer();
        }

    }
}
