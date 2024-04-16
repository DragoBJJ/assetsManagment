using Assets.Infrastructure.Extensions;
using Assets.Application.Extensions;
using Assets.Infrastructure.Seeders;
using Assets.Domain.Entities;
using Assets.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AssetsDbContext>();


var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IAssetSeeders>();

await seeder.Seed();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
