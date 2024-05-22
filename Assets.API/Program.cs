using Assets.Infrastructure.Extensions;
using Assets.Application.Extensions;
using Assets.Domain.Entities;
using Assets.API.Extensions;
using Assets.Infrastructure.Seeders;
using Serilog;
using Serilog.Formatting.Compact;


var builder = WebApplication.CreateBuilder(args);

new CompactJsonFormatter();

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)
);


var app = builder.Build();


var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<IAssetSeeders>();
await seeder.Seed();


app.UseSwagger();
app.UseSwaggerUI();


app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.MapGroup("api/identity/").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
