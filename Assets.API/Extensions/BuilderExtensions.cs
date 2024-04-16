using Assets.Domain.Entities;
using Assets.Infrastructure;
using Microsoft.OpenApi.Models;

namespace Assets.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
   
            builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AssetsDbContext>();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
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
            builder.Services.AddEndpointsApiExplorer();
        }

    }
}
